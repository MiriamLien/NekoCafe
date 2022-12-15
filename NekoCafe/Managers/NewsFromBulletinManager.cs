using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class NewsFromBulletinManager
    {
        /// <summary>
        /// 取得消息清單
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Bulletin> GetNewsList(string keyword)
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
                            where item.Content.Contains(keyword)
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
                Logger.WriteLog("NewsFromBulletinManager.GetNewsList", ex);
                throw;
            }
        }

        #region
        /// <summary>
        /// 新增消息
        /// </summary>
        /// <param name="news"></param>
        public void CreateNews(BulletinModel news)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立要新增的貓咪資料
                    var newNews = new Bulletin()
                    {
                        BulletinID = news.BulletinID
                    };

                    //將新資料插入EF的集合中
                    contextModel.Bulletins.Add(newNews);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("BulletinManager.CreateNews", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改消息
        /// </summary>
        /// <param name="news"></param>
        public void UpdateNews(BulletinModel news)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Bulletins.Where(i => i.BulletinID == news.BulletinID);

                    //取得資料
                    var updateNews = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateNews != null)
                        updateNews.BulletinID = news.BulletinID;
                    else
                        throw new Exception("此欄位ID不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("BulletinManager.UpdateNews", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除消息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteNews(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Bulletins.Where(i => i.BulletinID == id);

                    //取得資料
                    var deleteNews = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteNews != null)
                        contextModel.Bulletins.Remove(deleteNews);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("BulletinManager.DeleteNews", ex);
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 透過 id 取得消息
        /// </summary>
        /// <returns></returns>
        public Bulletin GetNews(int id)
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
                Logger.WriteLog("BulletinManager.GetNews", ex);
                throw;
            }
        }
    }
}