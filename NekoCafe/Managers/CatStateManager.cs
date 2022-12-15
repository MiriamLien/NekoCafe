using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class CatStateManager
    {
        #region "增刪修查"
        /// <summary>
        /// 以日期過濾貓咪狀態清單，不輸入日期則顯示全部，日期格式範例:"03 23 2022 12:15AM"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<CatState> GetCatStateList(string date)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<CatState> query;
                    if (!string.IsNullOrWhiteSpace(date))
                    {
                        query =
                            from item in contextModel.CatStates
                            where item.Date.ToString().Contains(date)
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.CatStates
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatStateManager.GetCatStateList", ex);
                throw;
            }
        }

        /// <summary>
        /// 取得特定CatStateID的資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CatState GetCatState(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.CatStates
                        where item.CatStateID == id
                        select item;


                    //組合，並取回結果
                    var list = query.FirstOrDefault();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatStateManager.GetCatStateList", ex);
                throw;
            }
        }

        /// <summary>
        /// 新增貓咪狀態
        /// </summary>
        /// <param name="catState"></param>
        public void CreateCatState(CatStateModel catState)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立要新增的貓咪資料
                    var newState = new CatState()
                    {
                        CatID = catState.CatID,
                        Date = catState.Date,
                        Work = catState.Work
                    };

                    //將新資料插入EF的集合中
                    contextModel.CatStates.Add(newState);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatStateManager.CreateCatState", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改貓咪狀態
        /// </summary>
        /// <param name="catState"></param>
        public void UpdateCatState(CatStateModel catState)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.CatStates.Where(i => i.CatStateID == catState.CatStateID);

                    //取得資料
                    var updateState = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateState != null)
                    {
                        updateState.CatID = catState.CatID;
                        updateState.Date = catState.Date;
                        updateState.Work = catState.Work;
                    }

                    else
                        throw new Exception("此貓咪狀態不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatStateManager.UpdateCatState", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除貓咪狀態
        /// </summary>
        /// <param name="catState"></param>
        public void DeleteCatState(CatStateModel catState)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.CatStates.Where(item => item.CatStateID == catState.CatStateID);

                    //取得資料
                    var deleteState = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteState != null)
                        contextModel.CatStates.Remove(deleteState);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatStateManager.DeleteCatState", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除所有CatID為id的狀態
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCatState(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.CatStates.Where(item => item.CatID == id);

                    //取得資料
                    var deleteState = query.ToList();

                    foreach (var item in deleteState)
                    {
                        contextModel.CatStates.Remove(item);
                    }

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatStateManager.DeleteCatState", ex);
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 以日期過濾貓咪狀態清單，不輸入日期則顯示全部，日期格式範例:"03 23 2022 12:15AM"
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<CCModel> GetCatStatusList(string txt)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<CCModel> query;
                    if (!string.IsNullOrWhiteSpace(txt))
                    {
                        query =
                           from item in contextModel.CatStates
                           join item2 in contextModel.Cats
                           on item.CatID equals item2.CatID
                           where item2.CatName.ToString().Contains(txt)
                           select new CCModel
                           {
                               CatStateID = item.CatStateID,
                               CatID = item.CatID,
                               CatName = item2.CatName,
                               Date = item.Date,
                               Work = item.Work
                           };
                    }
                    else
                    {
                        query =
                            from item in contextModel.CatStates
                            join item2 in contextModel.Cats
                            on item.CatID equals item2.CatID
                            select new CCModel
                            {
                                CatStateID = item.CatStateID,
                                CatID = item.CatID,
                                CatName = item2.CatName,
                                Date = item.Date,
                                Work = item.Work
                            };
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    return list;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatStateManager.GetCatStatusList", ex);
                throw;
            }
        }
    }
}