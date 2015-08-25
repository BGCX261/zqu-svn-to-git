using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// 业务逻辑类sr_TotalScore 的摘要说明。
	/// </summary>
	public class sr_TotalScore
	{
		private readonly ZQUSR.DAL.sr_TotalScore dal=new ZQUSR.DAL.sr_TotalScore();
		public sr_TotalScore()
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
		public bool Exists(int PK_TID)
		{
			return dal.Exists(PK_TID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZQUSR.Model.sr_TotalScore model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_TotalScore model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_TID)
		{
			
			dal.Delete(PK_TID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_TotalScore GetModel(int PK_TID)
		{
			
			return dal.GetModel(PK_TID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ZQUSR.Model.sr_TotalScore GetModelByCache(int PK_TID)
		{
			
			string CacheKey = "sr_TotalScoreModel-" + PK_TID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_TID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_TotalScore)objModel;
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
		public List<ZQUSR.Model.sr_TotalScore> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZQUSR.Model.sr_TotalScore> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_TotalScore> modelList = new List<ZQUSR.Model.sr_TotalScore>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_TotalScore model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_TotalScore();
					if(dt.Rows[n]["PK_TID"].ToString()!="")
					{
						model.PK_TID=int.Parse(dt.Rows[n]["PK_TID"].ToString());
					}
					model.FK_UserID=dt.Rows[n]["FK_UserID"].ToString();
					model.Year=dt.Rows[n]["Year"].ToString();
					if(dt.Rows[n]["TotalScore"].ToString()!="")
					{
						model.TotalScore=decimal.Parse(dt.Rows[n]["TotalScore"].ToString());
					}
					if(dt.Rows[n]["TotalRewards"].ToString()!="")
					{
						model.TotalRewards=decimal.Parse(dt.Rows[n]["TotalRewards"].ToString());
					}
					model.Extra1=dt.Rows[n]["Extra1"].ToString();
					model.Extra2=dt.Rows[n]["Extra2"].ToString();
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
	}
}

