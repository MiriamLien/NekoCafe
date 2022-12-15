using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class MemberManager
    {
        private ReservationManager _mgrReservation = new ReservationManager(); 

        /// <summary>
        /// 取得所有或以姓名作附加查詢條件的客戶資料
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public List<MemberInfo> GetMemberInfoList(string keyname)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<MemberInfo> query;
                    if (!string.IsNullOrWhiteSpace(keyname))
                    {
                        query =
                            from item in contextModel.MemberInfos
                            where item.Name.Contains(keyname)
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.MemberInfos
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("MemberManager.GetMemberInfoList", ex);
                throw;
            }
        }

        /// <summary>
        /// 輸入name取得客戶資料清單(AccountID,Name,Sex,Phone,Mail,Level)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<MemberInfo> GetMember(string name)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.MemberInfos
                        where item.Name == name
                        select item;

                    //取得所有資料
                    var list = query.ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MemberManager.GetMember", ex);
                throw;
            }
        }

        /// <summary>
        /// 輸入ID取得客戶資料(AccountID,Name,Sex,Phone,Mail,Level)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MemberInfo GetMember(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.MemberInfos
                        where item.AccountID == id
                        select item;

                    //取得Account所有資料
                    var memberInfo = query.FirstOrDefault();

                    //檢查是否存在
                    if (memberInfo != null)
                        return memberInfo;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MemberManager.GetMember", ex);
                throw;
            }
        }

        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="member"></param>
        public void CreateMember(int newID,MemberInfoModel member)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立要新增的帳戶資料
                    var newMember = new MemberInfo()
                    {
                        AccountID = newID,
                        Name = member.Name,
                        Sex = member.Sex,
                        Phone = member.Phone,
                        Mail = member.Mail
                    };

                    //將新資料插入EF的集合中
                    contextModel.MemberInfos.Add(newMember);
                    
                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MemberManager.CreateMember", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改客戶資料
        /// </summary>
        /// <param name="member"></param>
        public void UpdateMember(MemberInfoModel member)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.MemberInfos.Where(item => item.AccountID == member.AccountID);

                    //取得資料
                    var memberInfo = query.FirstOrDefault();

                    //檢查是否存在
                    if (memberInfo != null)
                    {
                        memberInfo.Name = member.Name;
                        memberInfo.Phone = member.Phone;
                        memberInfo.Mail = member.Mail;
                        memberInfo.Level = member.Level;
                    }

                    else
                        throw new Exception("此會員資料不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MemberManager.UpdateMember", ex);
                throw;
            }
        }

        /// <summary>
        /// 將客戶資料從資料庫移除
        /// </summary>
        /// <param name="member"></param>
        public void DeleteMember(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.MemberInfos.Where(item => item.AccountID == id);

                    //取得資料
                    var memberInfo = query.FirstOrDefault();

                    //檢查是否存在
                    if (memberInfo != null)
                        contextModel.MemberInfos.Remove(memberInfo);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MemberManager.DeleteMember", ex);
                throw;
            }
        }

        /// <summary>
        /// 輸入AccountID取得使用者會員等級
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public int LevelSelector(int accountID)
        {
            List<MRModel> list = this._mgrReservation.GetOrderListForAccountInfo(accountID);
            
            var query =
                        from item in list
                        group item by item.AccountID into g
                        select g.Sum(i => i.Spending);
            
            int Spending;
            if (query.ToList() == null)
                return 0;
            
            foreach (var item in query.ToList())
            {
                Spending = item;

                if (Spending > 4000)
                    return 3;
                if (Spending > 2500)
                    return 2;
                if (Spending > 1500)
                    return 1;
            }
            return 0;
        }
    }
}