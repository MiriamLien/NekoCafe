using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class ItemManager
    {
        #region 增刪修查
        /// <summary>
        /// 以菜單品項名稱過濾菜單，不輸入則顯示全部
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Item> GetItemList(string keyname)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<Item> query;
                    if (!string.IsNullOrWhiteSpace(keyname))
                    {
                        query =
                            from item in contextModel.Items
                            where item.Name.Contains(keyname)
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.Items
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("ItemManager.GetItemList", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得指定ItemID的菜單品項資料
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public Item GetItem(int itemID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Items
                        where item.ItemID == itemID
                        select item;

                    //取得Item所有資料
                    var menuItem = query.FirstOrDefault();

                    //檢查是否存在
                    if (menuItem != null)
                        return menuItem;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("ItemManager.GetItem", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得指定ItemID的菜單品項資料價格
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public int GetItemPrice(int itemID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Items
                        where item.ItemID == itemID
                        select item.Price;

                    //取得Item所有資料
                    int price = query.First();
                    return price;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("ItemManager.GetItemPrice", ex);
                throw;
            }
        }

        /// <summary>
        /// 建立新菜單
        /// </summary>
        /// <param name="item"></param>
        public void CreateItem(ItemModel item)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立新訂單
                    var newItem = new Item()
                    {
                        Name = item.Name,
                        ItemClassID = item.ItemClassID,
                        Price = item.Price
                    };

                    //將新資料插入EF的集合中
                    contextModel.Items.Add(newItem);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("ItemManager.CreateItem", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改菜單
        /// </summary>
        /// <param name="item"></param>
        public void UpdateItem(ItemModel item)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Items.Where(i => i.ItemID == item.ItemID);

                    //取得資料
                    var updateItem = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateItem != null)
                    {
                        updateItem.Name = item.Name;
                        updateItem.ItemClassID = item.ItemClassID;
                        updateItem.Price = item.Price;
                    }

                    else
                        throw new Exception("此菜單品項不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("ItemManager.UpdateItem", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除菜單
        /// </summary>
        /// <param name="item"></param>
        public void DeleteItem(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Items.Where(i => i.ItemID == id);

                    //取得資料
                    var deleteItem = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteItem != null)
                        contextModel.Items.Remove(deleteItem);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("ItemManager.DeleteItem", ex);
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 取得各類菜單清單，咖啡(1)，茶類(2)，點心(3)，其他(4)
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<Item> GetItemClassList(int classID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Items
                        where item.ItemClassID == classID
                        select item;

                    var list = query.ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("ItemManager.GetItemClassList", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得品項名稱&價錢
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<ItemAndPriceModel> GetItemAndPriceList(int classID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                       from item in contextModel.Items
                       where item.ItemClassID == classID

                       select new ItemAndPriceModel
                       { 
                           ItemID = item.ItemID,
                           NamePrice = item.Name + "  $" + item.Price
                       };

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("ItemManager.GetItemAndPriceList", ex);
                throw;
            }
        }

        /// <summary>
        /// 透過 Title 取得消息
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public Bulletin GetPicRoute(string title)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Bulletins
                        where item.Title == title
                        select item;

                    var osuTitle = query.FirstOrDefault();

                    if (osuTitle != null)
                        return osuTitle;
                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("ItemManager.GetPicRoute", ex);
                throw;
            }

        }
    }
}