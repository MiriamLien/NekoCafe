using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace NekoCafe.Managers
{
    public class BulletinManager
    {
        #region 增刪修查
        /// <summary>
        /// 透過 id 取得消息
        /// </summary>
        /// <returns></returns>
        public Bulletin GetBulletin(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Bulletins
                        where item.BulletinID == id
                        select item;

                    var news = query.FirstOrDefault();

                    if (news != null)
                        return news;
                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("BulletinManager.GetBulletin", ex);
                throw;
            }
        }

        /// <summary>
        /// 以公告標題過濾公告，不輸入則顯示全部
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Bulletin> GetBulletinList(string keyword)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<Bulletin> query;
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query =
                            from item in contextModel.Bulletins
                            where item.Title.Contains(keyword)
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.Bulletins
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("BulletinManager.GetBulletinList", ex);
                throw;
            }
        }

        /// <summary>
        /// 以公告標題過濾公告，不輸入則顯示全部
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<BPModel> GetBPList(string keyword)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    var query1 =
                       from item in contextModel.Items
                       join item2 in contextModel.ItemClasses
                       on item.ItemClassID equals item2.ItemClassID
                       where item2.Class == "おすすめ"
                       select new
                       {
                           ID = item.ItemID,
                           Name = item.Name,
                           Price = item.Price,
                           Class = item2.Class
                       };

                    var a = query1.ToList();

                    var query2 =
                       from item3 in contextModel.Bulletins
                       join item4 in contextModel.Pictures
                       on item3.PicID equals item4.PicID
                       where item3.Title.Contains("おすすめ")
                       select new
                       {
                           ID = item3.BulletinID,
                           Title = item3.Title,
                           PicRoute = item4.PicRoute
                       };

                    var b = query2.ToList();

                    var query3 =
                       from item in a
                       join item2 in b
                       on item.ID equals item2.ID - 21
                       select new BPModel
                       {
                           Name = item.Name,
                           Price = item.Price,
                           Title = item2.Title,
                           PicRoute = item2.PicRoute
                       };

                    //組合，並取回結果
                    var list = query3.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("BulletinManager.GetBPList", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得指定標題的內容資料
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Bulletin> GetBulletin(string keyword)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Bulletins
                        where item.Title == keyword
                        select item;

                    //取得資料
                    var list = query.ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("BulletinManager.GetBulletin", ex);
                throw;
            }
        }

        /// <summary>
        /// 建立新公告
        /// </summary>
        /// <param name="item"></param>
        public void CreateBulletin(BulletinModel item)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立新訂單
                    var newBulletin = new Bulletin()
                    {
                        CreateDate = item.CreateDate,
                        Title = item.Title,
                        Content = item.Content,
                        PicID = item.PicID
                    };

                    //將新資料插入EF的集合中
                    contextModel.Bulletins.Add(newBulletin);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("BulletinManager.CreateBulletin", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改公告
        /// </summary>
        /// <param name="item"></param>
        public void UpdateBulletin(BulletinModel item)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Bulletins.Where(i => i.BulletinID == item.BulletinID);

                    //取得資料
                    var updateBulletin = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateBulletin != null)
                    {
                        updateBulletin.CreateDate = item.CreateDate;
                        updateBulletin.Title = item.Title;
                        updateBulletin.Content = item.Content;
                        updateBulletin.PicID = item.PicID;
                    }
                    else
                        throw new Exception("此公告不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("BulletinManager.UpdateBulletin", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除公告
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBulletin(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Bulletins.Where(i => i.BulletinID == id);

                    //取得資料
                    var deleteBulletin = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteBulletin != null)
                        contextModel.Bulletins.Remove(deleteBulletin);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("BulletinManager.DeleteBulletin", ex);
                throw;
            }
        }
        #endregion

        public List<Bulletin> RemoveNewsInTitle(List<Bulletin> bulletins)
        {
            var list = new List<Bulletin>();
            foreach (var item in bulletins)
            {
                var news = new Bulletin()
                {
                    BulletinID = item.BulletinID,
                    CreateDate = item.CreateDate,
                    Title = item.Title.Substring(5),
                    Content = item.Content,
                    PicID = item.PicID
                };
                list.Add(news);
            }
            return list;
        }

        public List<ArticleModel> AnalyzeContent_img(List<Bulletin> contentOnly)
        {
            var bulletin = new List<ArticleModel>();
            foreach (var item in contentOnly)
            {
                var article = new ArticleModel();
                bool isIMG = Regex.IsMatch(item.Content, @"^@img") && Regex.IsMatch(item.Content, @"@img$");
                if (isIMG)
                {
                    article.Word = null;
                    article.Picture = item.Content.Replace("@img", "").Trim();
                }
                else
                {
                    article.Word = item.Content;
                    article.Picture = null;
                }
                bulletin.Add(article);
            }
            return bulletin;
        }

        public List<Bulletin> AnalyzeContent_newLine(List<Bulletin> bulletin)
        {
            string content;
            content = bulletin[0].Content;
            string[] sArray = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            List<Bulletin> list = new List<Bulletin>();
            foreach (var item in sArray)
            {
                Bulletin contentOnly = new Bulletin()
                {
                    Content = item.Trim()
                };
                list.Add(contentOnly);
            }
            return list;
        }
    }
}