using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// 业务逻辑类sr_LevelScores 的摘要说明。
	/// </summary>
	public class sr_LevelScores
	{
		private readonly ZQUSR.DAL.sr_LevelScores dal=new ZQUSR.DAL.sr_LevelScores();
		public sr_LevelScores()
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
		public bool Exists(int PK_ID)
		{
			return dal.Exists(PK_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZQUSR.Model.sr_LevelScores model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_LevelScores model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_ID)
		{
			
			dal.Delete(PK_ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_LevelScores GetModel(int PK_ID)
		{
			
			return dal.GetModel(PK_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ZQUSR.Model.sr_LevelScores GetModelByCache(int PK_ID)
		{
			
			string CacheKey = "sr_LevelScoresModel-" + PK_ID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_ID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_LevelScores)objModel;
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
		public List<ZQUSR.Model.sr_LevelScores> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZQUSR.Model.sr_LevelScores> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_LevelScores> modelList = new List<ZQUSR.Model.sr_LevelScores>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_LevelScores model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_LevelScores();
					if(dt.Rows[n]["PK_ID"].ToString()!="")
					{
						model.PK_ID=int.Parse(dt.Rows[n]["PK_ID"].ToString());
					}
					model.JiBie=dt.Rows[n]["JiBie"].ToString();
					if(dt.Rows[n]["Score"].ToString()!="")
					{
						model.Score=int.Parse(dt.Rows[n]["Score"].ToString());
					}
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


        /// <summary>
        /// 根据级别返回对应的级别分    ——By Jianguo Fung
        /// </summary>
        /// <param name="JiBie"></param>
        /// <returns></returns>
        public int GetScoreByJiBie(string JiBie)
        {
            return dal.GetScoreByJiBie(JiBie);
        }

        /// <summary>
        /// 返回数据列表   ——By Jianguo Fung
        /// </summary>
        public DataSet GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 更新级别分数
        /// </summary>
        public void UpdateScore(ZQUSR.Model.sr_LevelScores model)
        {
            dal.UpdateScore(model);
        }
	}
}

