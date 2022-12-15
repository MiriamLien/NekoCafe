using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class PermissionsManager
    {
        /// <summary>
        /// 透過 id 取得權限
        /// </summary>
        /// <returns></returns>
        public ALModel GetPermissions(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Accounts
                        join item2 in contextModel.MemberInfos
                        on item.AccountID equals item2.AccountID
                        where item.AccountID == id
                        select new ALModel
                        {
                            AccountID = item.AccountID,
                            Account = item.Account1,
                            Level = item2.Level
                        };

                    var list = query.FirstOrDefault();

                    if (list != null)
                        return list;
                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("PermissionsManager.GetPermissions", ex);
                throw;
            }

        }

        /// <summary>
        /// 取得Permissions權限管理所有清單(AccountID, Account, Level)
        /// </summary>
        /// <returns></returns>
        public List<ALModel> GetPermissionsList()
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Accounts
                        join item2 in contextModel.MemberInfos
                        on item.AccountID equals item2.AccountID
                        select new ALModel
                        {
                            AccountID = item.AccountID,
                            Account = item.Account1,
                            Level = item2.Level
                        };

                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("PermissionsManager.GetPermissionsList", ex);
                throw;
            }

        }

        public List<ALModel> GetPermissionsList(string keyword)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    IQueryable<ALModel> query;
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query =
                        from item in contextModel.Accounts
                        join item2 in contextModel.MemberInfos
                        on item.AccountID equals item2.AccountID
                        where item.Account1.Contains(keyword)
                        select new ALModel
                        {
                            AccountID = item.AccountID,
                            Account = item.Account1,
                            Level = item2.Level
                        };
                    }
                    else
                    {
                        query =
                        from item in contextModel.Accounts
                        join item2 in contextModel.MemberInfos
                        on item.AccountID equals item2.AccountID
                        select new ALModel
                        {
                            AccountID = item.AccountID,
                            Account = item.Account1,
                            Level = item2.Level
                        };
                    }

                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("PermissionsManager.GetPermissionsList", ex);
                throw;
            }

        }

        /// <summary>
        /// 修改權限
        /// </summary>
        /// <param name="permissions"></param>
        public void UpdatePermissions(ALModel permissions)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Accounts.Where(i => i.Account1 == permissions.Account);

                    //取得資料
                    var updatePermissions = query.FirstOrDefault();

                    //檢查是否存在
                    if (updatePermissions != null)
                    {
                        updatePermissions.AccountID = permissions.AccountID;
                        updatePermissions.Account1 = permissions.Account;
                        updatePermissions.MemberInfo.Level = permissions.Level;
                    }
                    else
                        throw new Exception("此帳號不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("PermissionsManager.UpdatePermissions", ex);
                throw;
            }
        }
    }
}