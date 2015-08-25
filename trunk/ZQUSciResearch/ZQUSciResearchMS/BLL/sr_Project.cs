using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// 业务逻辑类sr_Project 的摘要说明。
	/// </summary>
	public class sr_Project
	{
		private readonly ZQUSR.DAL.sr_Project dal=new ZQUSR.DAL.sr_Project();
		public sr_Project()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PK_PID)
		{
			return dal.Exists(PK_PID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ZQUSR.Model.sr_Project model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_Project model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string PK_PID)
		{
			
			dal.Delete(PK_PID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Project GetModel(string PK_PID)
		{
			
			return dal.GetModel(PK_PID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ZQUSR.Model.sr_Project GetModelByCache(string PK_PID)
		{
			
			string CacheKey = "sr_ProjectModel-" + PK_PID;
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
			return (ZQUSR.Model.sr_Project)objModel;
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
		public List<ZQUSR.Model.sr_Project> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZQUSR.Model.sr_Project> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_Project> modelList = new List<ZQUSR.Model.sr_Project>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_Project model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_Project();
					model.PK_PID=dt.Rows[n]["PK_PID"].ToString();
					model.FK_UserID=dt.Rows[n]["FK_UserID"].ToString();
					model.BigSort=dt.Rows[n]["BigSort"].ToString();
					model.SmallSort=dt.Rows[n]["SmallSort"].ToString();
					model.Type=dt.Rows[n]["Type"].ToString();
					model.Title=dt.Rows[n]["Title"].ToString();
					if(dt.Rows[n]["AddTime"].ToString()!="")
					{
						model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
					}
					model.Source=dt.Rows[n]["Source"].ToString();
					if(dt.Rows[n]["PublishTime1"].ToString()!="")
					{
						model.PublishTime1=DateTime.Parse(dt.Rows[n]["PublishTime1"].ToString());
					}
					if(dt.Rows[n]["PublishTime2"].ToString()!="")
					{
						model.PublishTime2=DateTime.Parse(dt.Rows[n]["PublishTime2"].ToString());
					}
					if(dt.Rows[n]["Anchorperson"].ToString()!="")
					{
						model.Anchorperson=int.Parse(dt.Rows[n]["Anchorperson"].ToString());
					}
					model.ReviewState=dt.Rows[n]["ReviewState"].ToString();
					if(dt.Rows[n]["Population"].ToString()!="")
					{
						model.Population=int.Parse(dt.Rows[n]["Population"].ToString());
					}
					model.AllAuthor=dt.Rows[n]["AllAuthor"].ToString();
					model.SchoolSign=dt.Rows[n]["SchoolSign"].ToString();
					model.Remark=dt.Rows[n]["Remark"].ToString();
					model.AuditState=dt.Rows[n]["AuditState"].ToString();
					model.JiBie=dt.Rows[n]["JiBie"].ToString();
					if(dt.Rows[n]["LevelFactor"].ToString()!="")
					{
						model.LevelFactor=decimal.Parse(dt.Rows[n]["LevelFactor"].ToString());
					}
					if(dt.Rows[n]["PerScore"].ToString()!="")
					{
						model.PerScore=decimal.Parse(dt.Rows[n]["PerScore"].ToString());
					}
					if(dt.Rows[n]["Rewards"].ToString()!="")
					{
						model.Rewards=decimal.Parse(dt.Rows[n]["Rewards"].ToString());
					}
					if(dt.Rows[n]["Bounty"].ToString()!="")
					{
						model.Bounty=decimal.Parse(dt.Rows[n]["Bounty"].ToString());
					}
					if(dt.Rows[n]["ShiFa"].ToString()!="")
					{
						model.ShiFa=decimal.Parse(dt.Rows[n]["ShiFa"].ToString());
					}
					if(dt.Rows[n]["Funds1"].ToString()!="")
					{
						model.Funds1=decimal.Parse(dt.Rows[n]["Funds1"].ToString());
					}
					if(dt.Rows[n]["Funds2"].ToString()!="")
					{
						model.Funds2=decimal.Parse(dt.Rows[n]["Funds2"].ToString());
					}
					if(dt.Rows[n]["Funds3"].ToString()!="")
					{
						model.Funds3=decimal.Parse(dt.Rows[n]["Funds3"].ToString());
					}
					model.Extra1=dt.Rows[n]["Extra1"].ToString();
					model.Extra2=dt.Rows[n]["Extra2"].ToString();
					model.Extra3=dt.Rows[n]["Extra3"].ToString();
					model.Extra4=dt.Rows[n]["Extra4"].ToString();
					model.Extra5=dt.Rows[n]["Extra5"].ToString();
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

        #region 更新一条数据的审核状态   --by caiyuying 2011-01-23
        /// <summary>
        /// 更新一条数据的审核状态   --by caiyuying 2011-01-23
        /// </summary>
        /// <param name="model"></param>
        public void UpdateState(ZQUSR.Model.sr_Project model)
        {
            dal.UpdateState(model);
        }
        #endregion

        #region 返回科研项目数据列表（教师角色）
        /// <summary>
        /// 返回科研项目数据列表（教师角色）     ——By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet GetProject(ZQUSR.Model.sr_Project model)
        {
            return dal.GetProject(model);
        }
        #endregion

        #region 根据类别的统计次数返回数据列表(秘书角色)
        /// <summary>
        /// 根据类别的统计次数返回数据列表    ——By caiyuying
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public string GetNumBySortCount(string strWhere)
        {
            return dal.GetNumBySortCount(strWhere);
        }
        #endregion

        #region 更新审核状态（审核通过）
        /// <summary>
        /// 更新审核状态（审核通过）  －By Jianguo Fung
        /// </summary>
        /// <param name="PID"></param>
        /// <param name="state"></param>
        public void UpdateAuditState(string PID, string state)
        {
            dal.UpdateAuditState(PID, state);
        }
        #endregion

        #region 更新审核状态并填写原因(审核不通过)
        /// <summary>
        /// 更新审核状态(审核不通过)  －By Jianguo Fung
        /// </summary>
        /// <param name="PID"></param>
        /// <param name="state"></param>
        public void UpdateAuditState(string PID, string state, string reason)
        {
            dal.UpdateAuditState(PID, state, reason);
        }
        #endregion

        #region 更新级别分系数、级别、个人得分
        /// <summary>
        /// 更新级别分系数、级别、个人得分
        /// </summary>
        /// <param name="model"></param>
        public void UpdateJiBie(ZQUSR.Model.sr_Project model)
        {
            dal.UpdateJiBie(model);
        }
        #endregion
	}
}

