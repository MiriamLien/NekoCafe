using NekoCafe.CatCafe.ORM;
using NekoCafe.Helpers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NekoCafe.Managers
{
    public class CatBreedManager
    {
        #region "增刪修查"
        /// <summary>
        /// 以品種名稱過濾貓咪品種，不輸入日期則顯示全部
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<CatBreed> GetCatBreedList(string keyword)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    //取得所有或加查詢條件的帳戶
                    IQueryable<CatBreed> query;
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query =
                            from item in contextModel.CatBreeds
                            where item.Breed.Contains(keyword)
                            select item;
                    }
                    else
                    {
                        query =
                            from item in contextModel.CatBreeds
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
        /// 輸入CatBreedID取得貓咪品種(CatBreedID,Breed)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CatBreed GetCatBreed(int id)
        {
            try
            {
                using (ContextModel contextModel = new ContextModel())
                {
                    var query =
                        from item in contextModel.CatBreeds
                        where item.CatBreedID == id
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
                Logger.WriteLog("CatBreedManager.GetCatBreed", ex);
                throw;
            }
        }

        /// <summary>
        /// 新增貓咪品種
        /// </summary>
        /// <param name="catbreed"></param>
        public void CreateCatBreed(CatBreedModel breed)
        {
            try
            {
                //新增資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //建立要新增的貓咪資料
                    var newBreed = new CatBreed()
                    {
                        Breed = breed.Breed,
                    };

                    //將新資料插入EF的集合中
                    contextModel.CatBreeds.Add(newBreed);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatBreedManager.CreateCatBreed", ex);
                throw;
            }
        }

        /// <summary>
        /// 修改貓咪品種
        /// </summary>
        /// <param name="breed"></param>
        public void UpdateCatBreed(CatBreedModel breed)
        {
            try
            {
                //編輯資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.CatBreeds.Where(i => i.CatBreedID == breed.CatBreedID);

                    //取得資料
                    var updateBreed = query.FirstOrDefault();

                    //檢查是否存在
                    if (updateBreed != null)
                        updateBreed.Breed = breed.Breed;
                    else
                        throw new Exception("此品種不存在");

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatBreedManager.UpdateCatBreed", ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除貓咪品種
        /// </summary>
        /// <param name="breed"></param>
        public void DeleteCatBreed(CatBreedModel breed)
        {
            try
            {
                //刪除資料
                using (ContextModel contextModel = new ContextModel())
                {
                    //組查詢條件
                    var query = contextModel.CatBreeds.Where(item => item.CatBreedID == breed.CatBreedID);

                    //取得資料
                    var deleteBreed = query.FirstOrDefault();

                    //檢查是否存在
                    if (deleteBreed != null)
                        contextModel.CatBreeds.Remove(deleteBreed);

                    //確定存檔
                    contextModel.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("CatBreedManager.DeleteCatBreed", ex);
                throw;
            }
        }
        #endregion
    }
}