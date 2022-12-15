using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class PictureManager
    {
        #region "增刪修查"
        /// <summary>
        /// 以路徑過濾圖片，不輸入則顯示全部
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Picture> GetPictureList(string keyword)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<Picture> query;
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query =
                            from item in contextModel.Pictures
                            where item.PicRoute.Contains(keyword)
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.Pictures
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("PictureManager.GetPictureList", ex);
                throw;
            }
        }

        /// <summary>
        /// 輸入PicID取得圖片資訊(PicID,PicRoute)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Picture GetPicRoute(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Pictures
                        where item.PicID == id
                        select item;

                    //取得Cat所有資料
                    var cat = query.FirstOrDefault();

                    //檢查是否存在
                    if (cat != null)
                        return cat;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("PictureManager.GetPicRoute", ex);
                throw;
            }
        }

        /// <summary>
        /// 新增圖片
        /// </summary>
        /// <param name="pic"></param>
        public void CreatePicture(PictureModel pic)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立要新增的貓咪資料
                    var picture = new Picture()
                    {
                        PicRoute = pic.PicRoute
                    };

                    //將新資料插入EF的集合中
                    contextModel.Pictures.Add(picture);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("PictureManager.CreatePicture", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除圖片
        /// </summary>
        /// <param name="breed"></param>
        public void DeletePicture(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Pictures.Where(item => item.PicID == id);

                    //取得資料
                    var deletePic = query.FirstOrDefault();

                    //檢查是否存在
                    if (deletePic != null)
                        contextModel.Pictures.Remove(deletePic);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("PictureManager.DeletePicture", ex);
                throw;
            }
        }
        #endregion
    }
}