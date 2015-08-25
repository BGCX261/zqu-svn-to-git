using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// 业务逻辑类sr_Periodicals 的摘要说明。
	/// </summary>
	public class sr_Periodicals
	{
		private readonly ZQUSR.DAL.sr_Periodicals dal=new ZQUSR.DAL.sr_Periodicals();
		public sr_Periodicals()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_PID)
		{
			return dal.Exists(PK_PID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZQUSR.Model.sr_Periodicals model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_Periodicals model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_PID)
		{
			
			dal.Delete(PK_PID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Periodicals GetModel(int PK_PID)
		{
			
			return dal.GetModel(PK_PID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ZQUSR.Model.sr_Periodicals GetModelByCache(int PK_PID)
		{
			
			string CacheKey = "sr_PeriodicalsModel-" + PK_PID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_PID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_Periodicals)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZQUSR.Model.sr_Periodicals> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZQUSR.Model.sr_Periodicals> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_Periodicals> modelList = new List<ZQUSR.Model.sr_Periodicals>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_Periodicals model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_Periodicals();
					if(dt.Rows[n]["PK_PID"].ToString()!="")
					{
						model.PK_PID=int.Parse(dt.Rows[n]["PK_PID"].ToString());
					}
					model.ISSN=dt.Rows[n]["ISSN"].ToString();
					model.QikanKey=dt.Rows[n]["QikanKey"].ToString();
					model.QikanName=dt.Rows[n]["QikanName"].ToString();
					model.QikanEngName=dt.Rows[n]["QikanEngName"].ToString();
					model.XueKe=dt.Rows[n]["XueKe"].ToString();
					if(dt.Rows[n]["QIF"].ToString()!="")
					{
						model.QIF=decimal.Parse(dt.Rows[n]["QIF"].ToString());
					}
					model.JiBie=dt.Rows[n]["JiBie"].ToString();
					if(dt.Rows[n]["LevelFactor"].ToString()!="")
					{
						model.LevelFactor=decimal.Parse(dt.Rows[n]["LevelFactor"].ToString());
					}
					model.Extra1=dt.Rows[n]["Extra1"].ToString();
					model.Extra2=dt.Rows[n]["Extra2"].ToString();
					model.Extra3=dt.Rows[n]["Extra3"].ToString();
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
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法


        #region 根据用户输入的关键字检索数据库返回期刊名称（智能匹配检索）
        /// <summary>
        /// 根据用户输入的关键字检索数据库返回期刊名称（智能匹配检索）——By Jianguo Fung
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataSet GetQikanNameByKey(string key)
        {
            return dal.GetQikanNameByKey(key);
        } 
        #endregion

        #region 根据期刊号返回期刊名称
        /// <summary>
        ///  根据期刊号返回期刊名称   －By Jianguo Fung
        /// </summary>
        /// <param name="ISSN"></param>
        /// <returns></returns>
        public string GetQikanNameByISSN(string ISSN)
        {
            return dal.GetQikanNameByISSN(ISSN);
        } 
        #endregion

        #region 学术论文：根据刊物名称(QikanName)返回对应的影响因子(QIF)、级别(JiBie)和级别分系数(LevelFactor) 
        /// <summary>
        /// 学术论文：根据刊物名称(QikanName)返回对应的影响因子(QIF)、级别(JiBie)和级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        public ZQUSR.Model.sr_Periodicals GetLunwenJiBieByQikanName(string QikanName)
        {
            return dal.GetLunwenJiBieByQikanName(QikanName);
        } 
        #endregion

        #region 返回数据列表(1：返回SCI/SSCI数据；2：返回非SCI/SSCI数据)
        /// <summary>
        /// 返回数据列表(1：返回SCI/SSCI数据；2：返回非SCI/SSCI数据) －By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetDatByKey(int key)
        {
            return dal.GetDatByKey(key);
        }
        #endregion

        #region 更新级别和级别分系数
        /// <summary>
        /// 更新级别和级别分系数 －By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateJiBie(ZQUSR.Model.sr_Periodicals model)
        {
            dal.UpdateJiBie(model);
        }
        #endregion

        #region 更新影响因子
        /// <summary>
        /// 更新影响因子  －By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateQIF(ZQUSR.Model.sr_Periodicals model)
        {
            dal.UpdateQIF(model);
        }
        #endregion

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录（QikanKey/QikanName）－By Jianguo Fung
        /// </summary>
        public bool Exists(ZQUSR.Model.sr_Periodicals model)
        {
            return dal.Exists(model);
        }
        #endregion
	}
}

