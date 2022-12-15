using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class ItemClassManager
    {
        #region "查"
        /// <summary>
        /// 以餐點種類過濾菜單，不輸入則顯示全部
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<ItemClass> GetCatBreedList(string keyword)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<ItemClass> query;
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query =
                            from item in contextModel.ItemClasses
                            where item.Class.Contains(keyword)
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.ItemClasses
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatBreedManager.GetCatBreedList", ex);
                throw;
            }
        }

        /// <summary>
        /// 輸入ItemClassID取得餐點種類(ItemClassID,Class)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ItemClass GetItemCalss(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.ItemClasses
                        where item.ItemClassID == id
                        select item;

                    //取得Cat所有資料
                    var itemClass = query.FirstOrDefault();

                    //檢查是否存在
                    if (itemClass != null)
                        return itemClass;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("ItemClassManager.GetCatBreed", ex);
                throw;
            }
        }
        #endregion
    }
}