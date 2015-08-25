using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// 业务逻辑类sr_LwZzJc 的摘要说明。
	/// </summary>
	public class sr_LwZzJc
	{
		private readonly ZQUSR.DAL.sr_LwZzJc dal=new ZQUSR.DAL.sr_LwZzJc();
		public sr_LwZzJc()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PK_LZID)
		{
			return dal.Exists(PK_LZID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ZQUSR.Model.sr_LwZzJc model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_LwZzJc model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string PK_LZID)
		{
			
			dal.Delete(PK_LZID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_LwZzJc GetModel(string PK_LZID)
		{
			
			return dal.GetModel(PK_LZID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ZQUSR.Model.sr_LwZzJc GetModelByCache(string PK_LZID)
		{
			
			string CacheKey = "sr_LwZzJcModel-" + PK_LZID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_LZID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_LwZzJc)objModel;
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
		public List<ZQUSR.Model.sr_LwZzJc> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZQUSR.Model.sr_LwZzJc> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_LwZzJc> modelList = new List<ZQUSR.Model.sr_LwZzJc>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_LwZzJc model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_LwZzJc();
					model.PK_LZID=dt.Rows[n]["PK_LZID"].ToString();
					model.FK_UserID=dt.Rows[n]["FK_UserID"].ToString();
					model.BigSort=dt.Rows[n]["BigSort"].ToString();
					model.SmallSort=dt.Rows[n]["SmallSort"].ToString();
					model.Type=dt.Rows[n]["Type"].ToString();
					model.Title=dt.Rows[n]["Title"].ToString();
					if(dt.Rows[n]["AddTime"].ToString()!="")
					{
						model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
					}
					model.Unit=dt.Rows[n]["Unit"].ToString();
					model.Source=dt.Rows[n]["Source"].ToString();
					if(dt.Rows[n]["PublishTime"].ToString()!="")
					{
						model.PublishTime=DateTime.Parse(dt.Rows[n]["PublishTime"].ToString());
					}
					model.Number1=dt.Rows[n]["Number1"].ToString();
					model.Number2=dt.Rows[n]["Number2"].ToString();
					if(dt.Rows[n]["Rank"].ToString()!="")
					{
						model.Rank=int.Parse(dt.Rows[n]["Rank"].ToString());
					}
					if(dt.Rows[n]["Population"].ToString()!="")
					{
						model.Population=int.Parse(dt.Rows[n]["Population"].ToString());
					}
					model.AllAuthor=dt.Rows[n]["AllAuthor"].ToString();
					model.SchoolSign=dt.Rows[n]["SchoolSign"].ToString();
					model.State=dt.Rows[n]["State"].ToString();
					model.StateUnit=dt.Rows[n]["StateUnit"].ToString();
					if(dt.Rows[n]["Word"].ToString()!="")
					{
						model.Word=decimal.Parse(dt.Rows[n]["Word"].ToString());
					}
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

        #region 返回学术论文/学术著作/教材数据列表（教师角色）     ——By Jianguo Fung
        /// <summary>
        /// 返回学术论文/学术著作/教材数据列表（教师角色）     ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetLwZzJcByJs(ZQUSR.Model.sr_LwZzJc model)
        {
            return dal.GetLwZzJcByJs(model);
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

        #region 更新审核状态(审核通过)
        /// <summary>
        /// 更新审核状态(审核通过)  －By Jianguo Fung
        /// </summary>
        /// <param name="LZID"></param>
        /// <param name="state"></param>
        public void UpdateAuditState(string LZID, string state)
        {
            dal.UpdateAuditState(LZID, state);
        }
        #endregion

        #region 更新审核状态并填写原因(审核不通过)
        /// <summary>
        /// 更新审核状态(审核不通过)  －By Jianguo Fung
        /// </summary>
        /// <param name="LZID"></param>
        /// <param name="state"></param>
        public void UpdateAuditState(string LZID, string state, string reason)
        {
            dal.UpdateAuditState(LZID, state, reason);
        }
        #endregion

        #region 更新级别分系数、级别、个人得分
        /// <summary>
        /// 更新级别分系数、级别、个人得分
        /// </summary>
        /// <param name="model"></param>
        public void UpdateJiBie(ZQUSR.Model.sr_LwZzJc model)
        {
            dal.UpdateJiBie(model);
        }
        #endregion
	}
}

