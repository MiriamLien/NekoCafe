using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class AccountManager
    {
        public bool TryLogin(string account, string password)
        {
            bool isAccountRight = false;
            bool isPasswordRight = false;

            Account member = this.GetAccount(account);

            if (member == null)
                return false;
            if (string.Compare(member.Account1, account, true) == 0)
                isAccountRight = true;
            if (member.Password == password)
                isPasswordRight = true;

            //檢查帳號密碼是否正確
            bool result = (isPasswordRight && isAccountRight);

            //帳密正確: 把值寫入Session
            //為避免bug把session流出，先把密碼清除
            if (result)
            {
                member.Password = null;
                //修改!!!!!
                HttpContext.Current.Session["MemberAccount"] = member;
            }

            return result;
        }

        /// <summary>
        /// 取得目前使用者是否登入
        /// </summary>
        /// <returns></returns>
        public bool IsLogined()
        {
            Account account = GetCurrentUser();
            return (account != null);
        }

        /// <summary>
        /// 取得目前使用者
        /// </summary>
        /// <returns></returns>
        public Account GetCurrentUser()
        {
            Account account = HttpContext.Current.Session["MemberAccount"] as Account;
            return account;
        }

        public void Logout()
        {
            HttpContext.Current.Session.Remove("MemberAccount");
        }

        #region "增刪修查"
        /// <summary>
        /// 取得所有或附加查詢條件的帳戶，及其所有資料
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Account> GetAccountList(string keyword)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<Account> query;
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query =
                            from item in contextModel.Accounts
                            where item.Account1.Contains(keyword)
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.Accounts
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("AccountManager.GetAccountList", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得帳戶資料(ID,Account,Password,CreateDate)
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Account GetAccount(string account)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Accounts
                        where item.Account1 == account
                        select item;

                    //取得Account所有資料
                    var memberAccount = query.FirstOrDefault();

                    //檢查是否存在
                    if (memberAccount != null)
                        return memberAccount;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("AccountManager.GetAccount", ex);
                throw;
            }
        }

        /// <summary>
        /// 輸入ID取得帳戶所有資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account GetAccount(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Accounts
                        where item.AccountID == id
                        select item;

                    //取得Account所有資料
                    var memberAccount = query.FirstOrDefault();

                    //檢查是否存在
                    if (memberAccount != null)
                        return memberAccount;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("AccountManager.GetAccount", ex);
                throw;
            }
        }

        /// <summary>
        /// 新增帳戶
        /// </summary>
        /// <param name="member"></param>
        public void CreateAccount(AccountModel member)
        {
            //判斷資料庫是否有相同的Account
            if (this.GetAccount(member.Account) != null)
                throw new Exception("已存在相同的帳號");

            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立要新增的帳戶資料
                    var newAccount = new Account()
                    {
                        Account1 = member.Account,
                        Password = member.Password,
                        CreateDate = DateTime.Now
                    };

                    //將新資料插入EF的集合中
                    contextModel.Accounts.Add(newAccount);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("AccountManager.CreateAccount", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改帳戶密碼
        /// </summary>
        /// <param name="member"></param>
        public void UpdateAccount(AccountModel member)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Accounts.Where(item => item.AccountID == member.AccountID);

                    //取得資料
                    var memberAccount = query.FirstOrDefault();

                    //檢查是否存在
                    if (memberAccount != null)
                        memberAccount.Account1 = member.Account;
                    else
                        throw new Exception("此帳號不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("AccountManager.UpdateAccount", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改帳戶密碼
        /// </summary>
        /// <param name="member"></param>
        public void UpdatePassword(AccountModel member)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Accounts.Where(item => item.AccountID == member.AccountID);

                    //取得資料
                    var memberAccount = query.FirstOrDefault();

                    //檢查是否存在
                    if (memberAccount != null)
                        memberAccount.Password = member.Password;
                    else
                        throw new Exception("此帳號不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("AccountManager.UpdateAccount", ex);
                throw;
            }
        }

        /// <summary>
        /// 將帳戶從資料庫移除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAccount(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Accounts.Where(item => item.AccountID == id);

                    //取得資料
                    var deleteAccount = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteAccount != null)
                        contextModel.Accounts.Remove(deleteAccount);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("AccountManager.DeleteAccount", ex);
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 取得會員或管理者帳號清單
        /// </summary>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        public List<ALModel> GetMemberORAdminList(bool isAdmin)
        {
            var accountList = new List<ALModel>();

            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    IQueryable<ALModel> query;
                    //組查詢條件
                    if (isAdmin)
                    {
                        query =
                            from item in contextModel.Accounts
                            join item2 in contextModel.MemberInfos
                            on item.AccountID equals item2.AccountID
                            where item2.Level == 4 || item2.Level == 10
                            select new ALModel
                            {
                                AccountID = item.AccountID,
                                Account = item.Account1,
                                Password = item.Password,
                                CreateDate = item.CreateDate,
                                Level = item2.Level
                            };
                    }
                    else
                    {
                        query =
                            from item in contextModel.Accounts
                            join item2 in contextModel.MemberInfos
                            on item.AccountID equals item2.AccountID
                            where item2.Level <= 3 || item2.Level == null
                            select new ALModel
                            {
                                AccountID = item.AccountID,
                                Account = item.Account1,
                                Password = item.Password,
                                CreateDate = item.CreateDate,
                                Level = item2.Level
                            };
                    }

                    //取得Account所有資料

                    List<ALModel> list = query.ToList();

                    //檢查是否存在
                    if (list != null)
                        return list;

                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("AccountManager.GetMemberORAdminList", ex);
                throw;
            }
        }
    }
}