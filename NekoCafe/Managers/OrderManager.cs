using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class OrderManager
    {
        #region 增刪修查
        /// <summary>
        /// 以日期過濾訂單清單，不輸入日期則顯示全部，日期格式範例:"03 23 2022 12:15AM"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Order> GetOrderList(string date)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<Order> query;
                    if (!string.IsNullOrWhiteSpace(date))
                    {
                        query =
                            from item in contextModel.Orders
                            where item.Date.ToString().Contains(date)
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.Orders
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderManager.GetOrderList", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得指定OrderID訂單所有資料
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public Order GetOrder(int orderID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Orders
                        where item.OrderID == orderID
                        select item;

                    //取得Order所有資料
                    var order = query.FirstOrDefault();

                    //檢查是否存在
                    if (order != null)
                        return order;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderManager.GetOrder", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得最新一筆訂單
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public Order GetOrder()
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Orders
                        orderby item.OrderID descending
                        select item;

                    //取得Order所有資料
                    var order = query.FirstOrDefault();

                    //檢查是否存在
                    if (order != null)
                        return order;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderManager.GetOrder", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得指定AccountID最後一筆訂單所有資料
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public Order GetOrderID(int accountID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Orders
                        where item.AccountID == accountID
                        orderby item.OrderID descending
                        select item;

                    //取得Order所有資料
                    var order = query.FirstOrDefault(); //HERE!!

                    //檢查是否存在
                    if (order != null)
                        return order;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderManager.GetOrderID", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得指定AccountID最後一筆訂單所有資料
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<Order> GetOrderIDList(int accountID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Orders
                        where item.AccountID == accountID
                        select item;

                    //取得Order所有資料
                    var order = query.ToList();

                    return order;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderManager.GetOrderID", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得指定AccountID會員的所有訂單
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public List<Order> GetMemberOrderList(int accountID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Orders
                        where item.AccountID == accountID
                        select item;

                    //取得Order所有資料
                    var list = query.ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderManager.GetMemberOrderList", ex);
                throw;
            }
        }

        /// <summary>
        /// 建立新訂單
        /// </summary>
        /// <param name="order"></param>
        public void CreateOrder(OrderModel order)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立新訂單
                    var newOrder = new Order()
                    {
                        AccountID = order.AccountID,
                        Date = order.Date,
                        Time = order.Time,
                        NPR = order.NPR
                    };

                    //將新資料插入EF的集合中
                    contextModel.Orders.Add(newOrder);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderManager.CreateOrder", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改訂單
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrder(OrderModel order)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Orders.Where(item => item.OrderID == order.OrderID);

                    //取得資料
                    var updateOrder = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateOrder != null)
                    {
                        updateOrder.AccountID = order.AccountID;
                        updateOrder.Date = order.Date;
                        updateOrder.Time = order.Time;
                        updateOrder.NPR = order.NPR;
                    }

                    else
                        throw new Exception("此訂單不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderManager.UpdateOrder", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除訂單
        /// </summary>
        /// <param name="order"></param>
        public void DeleteOrder(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Orders.Where(item => item.OrderID == id);

                    //取得資料
                    var deleteorder = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteorder != null)
                        contextModel.Orders.Remove(deleteorder);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderManager.DeleteOrder", ex);
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 以日期過濾訂單清單，不輸入日期則顯示全部，日期格式範例:"03 23 2022 12:15AM"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<ORModel> GetORList(string date)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<ORModel> query;
                    if (!string.IsNullOrWhiteSpace(date))
                    {
                        query =
                            from item in contextModel.Orders
                            join item2 in contextModel.Reservations
                            on item.OrderID equals item2.OrderID
                            where item.Time.ToString().Contains(date)
                            select new ORModel
                            {
                                OrderID = item.OrderID,
                                AccountID = item.AccountID,
                                Date_Time = item.Time,
                                NPR = item.NPR,
                                Name = item2.Name,
                                Sex = item2.Sex,
                                Phone = item2.Phone,
                                Mail = item2.Mail,
                                Note = item2.Note
                            };
                    }
                    else
                    {
                        query =
                            from item in contextModel.Orders
                            join item2 in contextModel.Reservations
                            on item.OrderID equals item2.OrderID
                            select new ORModel
                            {
                                OrderID = item.OrderID,
                                AccountID = item.AccountID,
                                Date_Time = item.Time,
                                NPR = item.NPR,
                                Name = item2.Name,
                                Sex = item2.Sex,
                                Phone = item2.Phone,
                                Mail = item2.Mail,
                                Note = item2.Note
                            };
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderManager.GetORList", ex);
                throw;
            }
        }

        public List<ORModel> GetMonthORList(bool thisMonth)
        {
            var today = DateTime.Now;

            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    IQueryable<ORModel> query;
                    if (!thisMonth)
                    {
                        query =
                            from item in contextModel.Orders
                            join item2 in contextModel.Reservations
                            on item.OrderID equals item2.OrderID
                            where item.Time.Month < today.Month
                            select new ORModel
                            {
                                OrderID = item.OrderID,
                                AccountID = item.AccountID,
                                Date_Time = item.Time,
                                NPR = item.NPR,
                                Name = item2.Name,
                                Sex = item2.Sex,
                                Phone = item2.Phone,
                                Mail = item2.Mail,
                                Note = item2.Note
                            };
                    }
                    else
                    {
                        query =
                            from item in contextModel.Orders
                            join item2 in contextModel.Reservations
                            on item.OrderID equals item2.OrderID
                            where item.Time.Month == today.Month
                            select new ORModel
                            {
                                OrderID = item.OrderID,
                                AccountID = item.AccountID,
                                Date_Time = item.Time,
                                NPR = item.NPR,
                                Name = item2.Name,
                                Sex = item2.Sex,
                                Phone = item2.Phone,
                                Mail = item2.Mail,
                                Note = item2.Note
                            };
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("OrderManager.GetHisORList", ex);
                throw;
            }
        }

    }
}