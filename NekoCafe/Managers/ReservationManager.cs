using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class ReservationManager
    {
        /// <summary>
        /// 輸入ID取得顧客訂位紀錄(OrderID, Time, Spending)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<MRModel> GetOrderListForAccountInfo(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Orders
                        join item2 in contextModel.OrderItems
                        on item.OrderID equals item2.OrderID
                        group item2 by item into newgroup
                        where newgroup.Key.AccountID == id
                        select new 
                        {
                            OrderID = newgroup.Key.OrderID, 
                            Time = newgroup.Key.Time, 
                            NPR = newgroup.Key.NPR,
                            Spending = newgroup.Sum(i => i.Price) 
                        };

                    //取得Account所有資料
                    var reversationList = new List<MRModel>();
                    foreach (var item in query.ToList())
                    {
                        int discount = 0;
                        if (item.Spending > 0)
                            discount = 100;
                        else
                            discount = 0;
                        var reservation = new MRModel();
                        reservation.AccountID = id;
                        reservation.OrderID = item.OrderID;
                        reservation.Time = item.Time;
                        reservation.NPR = item.NPR;
                        reservation.Spending = item.Spending + (300 * item.NPR) - discount;

                        reversationList.Add(reservation);
                    }

                    //檢查是否存在
                    if (reversationList != null)
                        return reversationList;

                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("ReservationManager.UpdateMember", ex);
                throw;
            }

        }

        #region 增刪修查
        /// <summary>
        /// 以使用者名稱過濾訂位人清單，不輸入姓名則顯示全部
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Reservation> GetReservationList(string name)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<Reservation> query;
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        query =
                            from item in contextModel.Reservations
                            where item.Name.Contains(name)
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.Reservations
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("ReservationManager.GetReservationList", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得指定OrderID訂單的訂位人所有資料
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public Reservation GetReservation(int orderID)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Reservations
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
                Logger.WriteLog("ReservationManager.GetReservation", ex);
                throw;
            }
        }

        /// <summary>
        /// 建立訂位人
        /// </summary>
        /// <param name="newID"></param>
        /// <param name="reservation"></param>
        public void CreateReservation(int newID, ReservationModel reservation)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立新訂單
                    var newReservation = new Reservation()
                    {
                        OrderID = newID,
                        Name = reservation.Name,
                        Sex = reservation.Sex,
                        Phone = reservation.Phone,
                        Mail = reservation.Mail,
                        Note = reservation.Note
                    };

                    //將新資料插入EF的集合中
                    contextModel.Reservations.Add(newReservation);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("ReservationManager.CreateReservation", ex);
                throw;
            }
        }

        
        public void UpdateReservation(ReservationModel reservation)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Reservations.Where(item => item.OrderID == reservation.OrderID);

                    //取得資料
                    var updateReservaion = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateReservaion != null)
                    {
                        updateReservaion.Name = reservation.Name;
                        updateReservaion.Sex = reservation.Sex;
                        updateReservaion.Phone = reservation.Phone;
                        updateReservaion.Mail = reservation.Mail;
                        updateReservaion.Note = reservation.Note;
                    }

                    else
                        throw new Exception("此訂位人不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("ReservationManager.UpdateReservation", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除訂位人
        /// </summary>
        /// <param name="reservation"></param>
        public void DeleteReservation(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Reservations.Where(item => item.OrderID == id);

                    //取得資料
                    var deleteReservation = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteReservation != null)
                        contextModel.Reservations.Remove(deleteReservation);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("ReservationManager.DeleteReservation", ex);
                throw;
            }
        }
        #endregion
    }
}