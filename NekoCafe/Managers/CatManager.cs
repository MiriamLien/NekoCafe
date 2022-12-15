using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class CatManager
    {
        #region "增刪修查"
        /// <summary>
        /// 以貓咪名稱過濾貓咪清單，不輸入日期則顯示全部
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<CatModel> GetCatList(string keyword)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<Cat> query;
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query =
                            from item in contextModel.Cats
                            where item.CatName.Contains(keyword)
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.Cats
                            select item;
                    }

                    //組合，並取回結果
                    var list = query.ToList();
                    var catlist = new List<CatModel>();
                    foreach (var item in list)
                    {
                        var cat = new CatModel()
                        {
                            CatID = item.CatID,
                            CatName = item.CatName,
                            Sex = item.Sex,
                            CatBreedID = item.CatBreedID,
                            Birth = item.Birth,
                            strBirth = item.Birth.ToString("yyyy-MM-dd"),
                            Contents = item.Contents
                        };
                        catlist.Add(cat);
                    }
                    return catlist;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatManager.GetCatList", ex);
                throw;
            }
        }

        /// <summary>
        /// 輸入CatID取得貓咪資料(CatID,CatName,Sex,Birth,Contents,CatBreedID)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cat GetCat(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Cats
                        where item.CatID == id
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
                Logger.WriteLog("CatManager.GetCat", ex);
                throw;
            }
        }

        /// <summary>
        /// 新增貓咪
        /// </summary>
        /// <param name="cat"></param>
        public void CreateCat(CatModel cat)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立要新增的貓咪資料
                    var newCat = new Cat()
                    {
                        CatName = cat.CatName,
                        Sex = cat.Sex,
                        Birth = cat.Birth,
                        Contents = cat.Contents,
                        CatBreedID = cat.CatBreedID
                    };

                    //將新資料插入EF的集合中
                    contextModel.Cats.Add(newCat);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatManager.CreateCat", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改貓咪
        /// </summary>
        /// <param name="cat"></param>
        public void UpdateCat(CatModel cat)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Cats.Where(i => i.CatID == cat.CatID);

                    //取得資料
                    var updateCat = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateCat != null)
                    {
                        updateCat.CatName = cat.CatName;
                        updateCat.Sex = cat.Sex;
                        updateCat.Birth = cat.Birth;
                        updateCat.Contents = cat.Contents;
                        updateCat.CatBreedID = cat.CatBreedID;
                    }
                    else
                        throw new Exception("此貓咪不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatManager.UpdateCat", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除貓咪
        /// </summary>
        /// <param name="cat"></param>
        public void DeleteCat(int id)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.Cats.Where(item => item.CatID == id);

                    //取得資料
                    var deleteCat = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteCat != null)
                        contextModel.Cats.Remove(deleteCat);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatManager.DeleteCat", ex);
                throw;
            }
        }
        #endregion

        public List<CCModel> GetCCList()
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Cats
                        join item2 in contextModel.CatBreeds
                        on item.CatBreedID equals item2.CatBreedID
                        select new CCModel
                        {
                            CatID = item.CatID,
                            CatName = item.CatName,
                            Sex = item.Sex,
                            Breed = item2.Breed,
                            Birth = item.Birth,
                            Contents = item.Contents
                        };

                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatManager.GetCCList", ex);
                throw;
            }
        }

        public List<CCModel> GetCCList(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.Cats
                        join item2 in contextModel.CatBreeds
                        on item.CatBreedID equals item2.CatBreedID
                        join item3 in contextModel.CatStates
                        on item.CatID equals item3.CatID
                        where item.CatID == id
                        orderby item3.Date descending
                        select new CCModel
                        {
                            CatID = item.CatID,
                            CatName = item.CatName,
                            Sex = item.Sex,
                            Breed = item2.Breed,
                            Birth = item.Birth,
                            Contents = item.Contents,
                            Work = item3.Work
                        };

                    var cc = query.FirstOrDefault();
                    var cclist = new List<CCModel>();
                    cclist.Add(cc);
                    var cclist2 = new List<CCModel>();

                    foreach (var item in cclist)
                    {
                        var cc2 = new CCModel()
                        {
                            CatID = item.CatID,
                            CatName = item.CatName,
                            Sex = item.Sex,
                            Breed = item.Breed,
                            Birth = item.Birth,
                            strBirth = item.Birth.ToString("D"),
                            Contents = item.Contents,
                            Work = item.Work
                        };
                        cclist2.Add(cc2);
                    }
                    return cclist2;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatManager.GetCCList", ex);
                throw;
            }
        }
    }
}