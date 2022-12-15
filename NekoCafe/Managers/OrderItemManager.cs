using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class OrderItemManager
    {
        private ItemManager _mgrItem = new ItemManager();

        #region 增刪修查
        /// <summary>
        /// 取得同一筆訂單的所有消費紀錄
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<OrderItem> GetOrderItemList(int orderID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.OrderItems
                        where item.OrderID == orderID
                        select item;

                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderItemManager.GetOrderItemList", ex);
                throw;
            }
        }

        /// <summary>
        /// 建立新訂單品項
        /// </summary>
        /// <param name="orderItem"></param>
        public void CreateOrderItem(OrderItemModel orderItem)
        {
            int price = this._mgrItem.GetItemPrice(orderItem.ItemID) * orderItem.Amount;

            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立新訂單
                    var newOrderItem = new OrderItem()
                    {
                        OrderID = orderItem.OrderID,
                        ItemID = orderItem.ItemID,
                        Amount = orderItem.Amount,
                        Price = price
                    };

                    //將新資料插入EF的集合中
                    contextModel.OrderItems.Add(newOrderItem);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderItemManager.CreateOrderItem", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改訂單品項
        /// </summary>
        /// <param name="orderItem"></param>
        public void UpdateOrderItem(OrderItemModel orderItem)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.OrderItems.Where(item => item.OrderItemID == orderItem.OrderItemID);

                    //取得資料
                    var updateOrderItem = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateOrderItem != null)
                    {
                        updateOrderItem.OrderID = orderItem.OrderID;
                        updateOrderItem.ItemID = orderItem.ItemID;
                        updateOrderItem.Amount = orderItem.Amount;
                        updateOrderItem.Price = orderItem.Price;
                    }

                    else
                        throw new Exception("此訂單品項不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderItemManager.UpdateOrderItem", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除訂單品項
        /// </summary>
        /// <param name="orderItem"></param>
        public void DeleteOrderItem(OrderItemModel orderItem)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.OrderItems.Where(item => item.OrderID == orderItem.OrderID);

                    //取得資料
                    var deleteorderItem = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteorderItem != null)
                        contextModel.OrderItems.Remove(deleteorderItem);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderItemManager.DeleteOrderItem", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除某訂單內所有訂單品項
        /// </summary>
        /// <param name="orderItem"></param>
        public void DeleteOrder(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.OrderItems.Where(item => item.OrderID == id);

                    //取得資料
                    var deleteorderItem = query.ToList();

                    foreach (var item in deleteorderItem)
                    {
                        if (item != null)
                            contextModel.OrderItems.Remove(item);
                    }

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderItemManager.DeleteOrder", ex);
                throw;
            }
        }
        #endregion

        public string[] AnalyzeText(string txt)
        {
            txt = txt.Trim();
            txt = txt.TrimEnd('&');
            string[] str = txt.Trim().Split('&');


            return str;
        }

        public List<OrderItem> BuildOIList (string[] id, string[] amount, string[] price)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            int i = 0;
            try
            {
                foreach (var item in id)
                {
                    OrderItem orItem = new OrderItem()
                    {
                        ItemID = Convert.ToInt32(id[i]),
                        Amount = Convert.ToInt32(amount[i]),
                        Price = Convert.ToInt32(price[i])
                    };
                    i++;
                    orderItems.Add(orItem);
                }
                return orderItems;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}