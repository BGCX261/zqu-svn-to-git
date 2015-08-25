using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// 业务逻辑类sr_Achievement 的摘要说明。
	/// </summary>
	public class sr_Achievement
	{
		private readonly ZQUSR.DAL.sr_Achievement dal=new ZQUSR.DAL.sr_Achievement();
		public sr_Achievement()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PK_AID)
		{
			return dal.Exists(PK_AID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ZQUSR.Model.sr_Achievement model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_Achievement model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string PK_AID)
		{
			
			dal.Delete(PK_AID);
		}

		/// <summary> 
        /// 得到一个对象实体 
		/// </summary>
		public ZQUSR.Model.sr_Achievement GetModel(string PK_AID)
		{
			
			return dal.GetModel(PK_AID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ZQUSR.Model.sr_Achievement GetModelByCache(string PK_AID)
		{
			
			string CacheKey = "sr_AchievementModel-" + PK_AID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_AID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_Achievement)objModel;
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
		public List<ZQUSR.Model.sr_Achievement> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZQUSR.Model.sr_Achievement> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_Achievement> modelList = new List<ZQUSR.Model.sr_Achievement>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_Achievement model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_Achievement();
					model.PK_AID=dt.Rows[n]["PK_AID"].ToString();
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
					model.Number=dt.Rows[n]["Number"].ToString();
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
					model.Grade=dt.Rows[n]["Grade"].ToString();
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

        #region  成果类新增
        /// <summary>
        /// 成果类新增      ——By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        public void AddAchievement(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            dal.AddAchievement(AchievementModel);
        } 
        #endregion

        #region 返回成果类数据列表（教师角色）
        /// <summary>
        /// 返回成果类数据列表（教师角色）     ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetAchievementByJs(ZQUSR.Model.sr_Achievement model)
        {
            return dal.GetAchievementByJs(model);
        } 
        #endregion

        #region 更新审核状态(审核通过)
        /// <summary>
        /// 更新审核状态(审核通过)  －By Jianguo Fung
        /// </summary>
        /// <param name="AID"></param>
        /// <param name="state"></param>
        public void UpdateAuditState(string AID, string state)
        {
            dal.UpdateAuditState(AID,state);
        }
        #endregion

        #region 更新审核状态并填写原因(审核不通过)
        /// <summary>
        /// 更新审核状态(审核不通过)  －By Jianguo Fung
        /// </summary>
        /// <param name="AID"></param>
        /// <param name="state"></param>
        public void UpdateAuditState(string AID, string state, string reason)
        {
            dal.UpdateAuditState(AID, state, reason);
        }
        #endregion

        #region 根据成果编号删除一条记录
        /// <summary>
        /// 根据成果编号删除一条记录    ——By Jianguo Fung
        /// </summary>
        /// <param name="PK_AID"></param>
        public void DeleteZhuanLi(string PK_AID)
        {
            dal.DeleteZhuanLi(PK_AID);
        } 
        #endregion

        #region 返回数据列表（教师角色）
        /// <summary>
        /// 返回全部数据列表     ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshi(string UserID)
        {
            return dal.GetListByJiaoshi(UserID);
        }
        /// <summary>
        /// 返回二审通过、终审通过的数据列表     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshiAudit(string UserID)
        {
            return dal.GetListByJiaoshiAudit(UserID);
        }
        /// <summary>
        /// 返回未提交数据列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetListJiaoshiUncommit(string UserID)
        {
            return dal.GetListJiaoshiUncommit(UserID);
        }
        /// <summary>
        /// 返回审核数据列表（审核通过和不通过）
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetListJiaoshiAuditSituation(string UserID)
        {
            return dal.GetListJiaoshiAuditSituation(UserID);
        }
        #endregion

        #region 按类别返回数据列表（教师角色）
        /// <summary>
        /// 返回数据列表（教师角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshibySort(string UserID,string strSort)
        {
            return dal.GetListByJiaoshibySort(UserID, strSort);
        }
        #endregion

        #region 按报表格式返回数据列表（教师角色）
        /// <summary>
        /// 返回数据列表（教师角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshiPrint(string UserID)
        {
            return dal.GetListByJiaoshiPrint(UserID);
        }
        #endregion

        #region 按日期返回数据列表（教师角色）
        /// <summary>
        /// 返回数据列表（教师角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshibyDate(string UserID,string strStart, string strEnd)
        {
            return dal.GetListByJiaoshibyDate(UserID,strStart, strEnd);
        }
        #endregion  

        #region 按日期返回数据列表（教师角色）
        /// <summary>
        /// 返回数据列表（教师角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshibyDateAudit(string UserID, string strStart, string strEnd,string strAuditState)
        {
            return dal.GetListByJiaoshibyDateAudit(UserID, strStart, strEnd,strAuditState);
        }
        #endregion

        #region 按审核返回数据列表（教师角色）
        /// <summary>
        /// 返回数据列表（教师角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshibyAudit(string UserID, string strAuditState)
        {
            return dal.GetListByJiaoshibyAudit(UserID, strAuditState);
        }
        #endregion

        #region 返回数据列表（秘书角色）
        /// <summary>
        /// 返回数据列表
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishu(string UserUnit)
        {
            return dal.GetListByMishu(UserUnit);
        }
        #endregion

        #region 返回数据列表（秘书角色）
        /// <summary>
        /// 返回审核状态为5、7的数据列表
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuAuditPri(string UserUnit)
        {
            return dal.GetListByMishuAuditPri(UserUnit);
        }
        #endregion

        #region 按类别返回数据列表（秘书角色）
        /// <summary>
        /// 返回数据列表    ——By caiyuying
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuBySort(string strUnit,string strSort)
        {
            return dal.GetListByMishuBySort(strUnit,strSort);
        }
        #endregion

        #region 按日期返回数据列表（秘书角色）
        /// <summary>
        /// 返回数据列表    ——By caiyuying
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuByDate(string strUnit,string strSart,string strEnd)
        {
            return dal.GetListByMishuByDate(strUnit,strSart,strEnd);
        }
        #endregion

        #region 按日期和审核状态返回数据列表（秘书角色）
        /// <summary>
        /// 返回数据列表    ——By caiyuying
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuByDateAudit(string strUnit, string strSart, string strEnd)
        {
            return dal.GetListByMishuByDateAudit(strUnit, strSart, strEnd);
        }
        #endregion

        #region 按姓名返回数据列表（秘书角色）
        /// <summary>
        /// 返回数据列表    ——By caiyuying
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuByName(string strUnit,string strName)
        {
            return dal.GetListByMishuByName(strUnit,strName);
        }
        #endregion

        #region 根据类别的统计次数返回数据列表（秘书角色）
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

        #region 按报表格式返回数据列表（秘书角色）
        /// <summary>
        /// 返回数据列表（教师角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByMishuPrint(string UserUnit)
        {
            return dal.GetListByMishuPrint(UserUnit);
        }
        #endregion

        #region 
        /// <summary>
        /// 返回未审核数据列表（秘书角色）
        /// </summary>
        /// <param name="userUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuAudit(string UserUnit)
        {
            return dal.GetListByMishuAudit(UserUnit);
        }
        #endregion

        #region
        /// <summary>
        /// 返回已审核数据列表（秘书角色）
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuAudited(string UserUnit, string UserID)
        {
            return dal.GetListByMishuAudited(UserUnit, UserID);
        }
        #endregion

        #region
        /// <summary>
        /// 返回各个类别的汇总数据列表（秘书角色）
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public string GetCountByMishuAch(string strWhere)
        {
            return dal.GetCountByMishuAch(strWhere);
        }
        public string GetCountByMishuLw(string strWhere)
        {
            return dal.GetCountByMishuLw(strWhere);
        }
        public string GetCountByMishuPro(string strWhere)
        {
            return dal.GetCountByMishuPro(strWhere);
        }
        #endregion

        #region
        /// <summary>
        /// 返回审核为5和7的数据列表，即二审通过或终审通过
        /// </summary>
        /// <param name="userUnit"></param>
        /// <returns></returns>
        public DataSet GetListByKeyuanAuditPri()
        {
            return dal.GetListByKeyuanAuditPri();
        }
        #endregion

        #region 返回数据列表（科员角色）
        /// <summary>
        /// 返回数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuan()
        {
            return dal.GetListByKeyuan();
        }
        #endregion 
  
        #region 按类别返回数据列表（科员角色）
        /// <summary>
        /// 返回数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanBySort(string strsort)
        {
            return dal.GetListByKeyuanBySort(strsort);
        }
        #endregion

        #region 按学院返回数据列表（科员角色）
        /// <summary>
        /// 返回数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanByUnit(string strunit)
        {
            return dal.GetListByKeyuanByUnit(strunit);
        }
        #endregion

        #region 按日期返回数据列表（科员角色）
        /// <summary>
        /// 返回数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanByDate(string start,string strend)
        {
            return dal.GetListByKeyuanByDate(start,strend);
        }
        #endregion

        #region 按日期和审核状态(5\7)返回数据列表（科员角色）
        /// <summary>
        /// 返回数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanByDateAudit(string start, string strend)
        {
            return dal.GetListByKeyuanByDateAudit(start, strend);
        }
        #endregion

        #region 按姓名返回数据列表（科员角色）
        /// <summary>
        /// 返回数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanByName(string strname)
        {
            return dal.GetListByKeyuanByName(strname);
        }
        #endregion

        #region 按报表格式返回数据列表（科员角色）
        /// <summary>
        /// 返回数据列表（科员角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanPrint()
        {
            return dal.GetListByKeYuanPrint();
        }
        #endregion

        #region
        /// <summary>
        /// 返回未审核数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanAudit()
        {
            return dal.GetListByKeyuanAudit();
        }
        #endregion

        #region 
        /// <summary>
        /// 返回已审核数据列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanAudited()
        {
            return dal.GetListByKeyuanAudited();
        }
        #endregion

        #region 更新级别分系数、级别、个人得分
        /// <summary>
        /// 更新级别分系数、级别、个人得分
        /// </summary>
        /// <param name="model"></param>
        public void UpdateJiBie(ZQUSR.Model.sr_Achievement model)
        {
            dal.UpdateJiBie(model);
        }
        #endregion
    }
}

