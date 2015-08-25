using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
    /// <summary>
    /// sr_ZhiCheng
    /// </summary>
    public partial class sr_ZhiCheng
    {
        private readonly ZQUSR.DAL.sr_ZhiCheng dal = new ZQUSR.DAL.sr_ZhiCheng();
        public sr_ZhiCheng()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists()
        {
            return dal.Exists();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZQUSR.Model.sr_ZhiCheng model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZQUSR.Model.sr_ZhiCheng model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PK_ZCID)
        {

            return dal.Delete(PK_ZCID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PK_ZCIDlist)
        {
            return dal.DeleteList(PK_ZCIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZQUSR.Model.sr_ZhiCheng GetModel(int PK_ZCID)
        {

            return dal.GetModel(PK_ZCID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ZQUSR.Model.sr_ZhiCheng GetModelByCache(int PK_ZCID)
        {

            string CacheKey = "sr_ZhiChengModel-" + PK_ZCID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(PK_ZCID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZQUSR.Model.sr_ZhiCheng)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZQUSR.Model.sr_ZhiCheng> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZQUSR.Model.sr_ZhiCheng> DataTableToList(DataTable dt)
        {
            List<ZQUSR.Model.sr_ZhiCheng> modelList = new List<ZQUSR.Model.sr_ZhiCheng>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZQUSR.Model.sr_ZhiCheng model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZQUSR.Model.sr_ZhiCheng();
                    if (dt.Rows[n]["PK_ZCID"].ToString() != "")
                    {
                        model.PK_ZCID = int.Parse(dt.Rows[n]["PK_ZCID"].ToString());
                    }
                    model.Grade = dt.Rows[n]["Grade"].ToString();
                    model.ZhiChengName = dt.Rows[n]["ZhiChengName"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}


