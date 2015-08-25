using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// 业务逻辑类sr_Evaluate 的摘要说明。
	/// </summary>
	public class sr_Evaluate
	{
		private readonly ZQUSR.DAL.sr_Evaluate dal=new ZQUSR.DAL.sr_Evaluate();
		public sr_Evaluate()
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
		public bool Exists(int PK_EID)
		{
			return dal.Exists(PK_EID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZQUSR.Model.sr_Evaluate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_Evaluate model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_EID)
		{
			
			dal.Delete(PK_EID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Evaluate GetModel(int PK_EID)
		{
			
			return dal.GetModel(PK_EID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ZQUSR.Model.sr_Evaluate GetModelByCache(int PK_EID)
		{
			
			string CacheKey = "sr_EvaluateModel-" + PK_EID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_EID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_Evaluate)objModel;
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
		public List<ZQUSR.Model.sr_Evaluate> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZQUSR.Model.sr_Evaluate> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_Evaluate> modelList = new List<ZQUSR.Model.sr_Evaluate>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_Evaluate model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_Evaluate();
					if(dt.Rows[n]["PK_EID"].ToString()!="")
					{
						model.PK_EID=int.Parse(dt.Rows[n]["PK_EID"].ToString());
					}
					model.Sort=dt.Rows[n]["Sort"].ToString();
					model.Type=dt.Rows[n]["Type"].ToString();
					model.Source=dt.Rows[n]["Source"].ToString();
					model.Grade=dt.Rows[n]["Grade"].ToString();
					model.AwardGrade=dt.Rows[n]["AwardGrade"].ToString();
					if(dt.Rows[n]["Funds1"].ToString()!="")
					{
						model.Funds1=decimal.Parse(dt.Rows[n]["Funds1"].ToString());
					}
					if(dt.Rows[n]["Funds2"].ToString()!="")
					{
						model.Funds2=decimal.Parse(dt.Rows[n]["Funds2"].ToString());
					}
					model.JiBie=dt.Rows[n]["JiBie"].ToString();
					if(dt.Rows[n]["LevelFactor"].ToString()!="")
					{
						model.LevelFactor=decimal.Parse(dt.Rows[n]["LevelFactor"].ToString());
                        //model.LevelFactor = dt.Rows[n]["LevelFactor"].ToString();  //--by caiyuying
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


        #region 专利成果：返回级别和级别分系数
        /// <summary>
        /// 专利成果：根据专利类型(Type)和专利等级(Source)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetZhuanLiJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            return dal.GetZhuanLiJiBie(AchievementModel);
        } 
        #endregion

        #region 科技鉴定成果：返回级别和级别分系数
        /// <summary>
        /// 科技鉴定成果：根据鉴定部门(Unit)和鉴定类型(Type)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetKJJDJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            return dal.GetKJJDJiBie(AchievementModel);
        } 
        #endregion

        #region 根据类别返回鉴定部门（科技鉴定成果）、成果来源（社科鉴定成果）、著作来源（学术著作）
        /// <summary>
        /// 根据类别返回鉴定部门（科技鉴定成果）、成果来源（社科鉴定成果）、著作来源（学术著作）    ——By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <returns></returns>
        public DataSet GetSourceByClass(string strClass)
        {
            return dal.GetSourceByClass(strClass);
        } 
        #endregion

        #region 根据大类别（获奖成果）返回获奖成果类别（教学成果类/理工类/社科类）
        /// <summary>
        /// 根据大类别（获奖成果）返回获奖成果类别（教学成果类/理工类/社科类） ——By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <returns></returns>
        public DataSet GetHuoJiangType(string strClass)
        {
            return dal.GetHuoJiangType(strClass);
        } 
        #endregion

        #region 根据类别返回获奖级别（获奖成果）
        /// <summary>
        /// 根据类别返回获奖级别（获奖成果）   ——By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <returns></returns>
        public DataSet GetHouJiangGrade(string strClass)
        {
            return dal.GetHouJiangGrade(strClass);
        } 
        #endregion

        #region 根据类别返回鉴定等级（社科鉴定成果）
		/// <summary>
        /// 根据类别返回鉴定等级（社科鉴定成果）   ——By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <returns></returns>
        public DataSet GetGradeByClass(string strClass)
        {
            return dal.GetGradeByClass(strClass);
        } 
	#endregion

        #region 根据类别和类型返回来源（科研项目/项目申报）
        /// <summary>
        /// 根据类别和类型返回来源（科研项目/项目申报）   ——By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <param name="strType"></param>
        /// <returns></returns>
        public DataSet GetSourceBySortType(string strClass, string strType)
        {
            return dal.GetSourceBySortType(strClass, strType);
        } 
        #endregion  

        #region  社科鉴定成果：返回级别和级别分系数
        /// <summary>
        /// 社科鉴定成果：根据成果来源(Source)和鉴定等级(Grade)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetSKJDJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            return dal.GetSKJDJiBie(AchievementModel);
        } 
        #endregion

        #region 科技应用成果：返回级别和级别分系数
        /// <summary>
        /// 科技应用成果：根据成果来源（Source）返回对应的级别（JiBie）和级别分系数（LevelFactor） ——By Jianguo Fung
        /// </summary>
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetKJYYJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            return dal.GetKJYYJiBie(AchievementModel);
        } 
        #endregion

        #region 软科学成果：返回级别和级别分系数
        /// <summary>
        /// 软科学成果：根据采纳部门（Unit）返回对应的级别（JiBie）和级别分系数（LevelFactor） ——By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetRuanKeXueJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            return dal.GetRuanKeXueJiBie(AchievementModel);
        } 
        #endregion

        #region 获奖成果：返回级别和级别分系数
        /// <summary>
        /// 获奖成果：根据获奖级别(Source)和获奖等级(Grade)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetHuoJiangJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            return dal.GetHuoJiangJiBie(AchievementModel);
        } 
        #endregion

        #region 根据大类别返回类型（学术著作/专利成果）
        /// <summary>
        /// 根据大类别(Sort)返回类型(Type)（学术著作/专利成果）   ——By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <returns></returns>
        public DataSet GetTypeBySort(string strClass)
        {
            return dal.GetTypeBySort(strClass);
        }
        #endregion

        #region 学术著作：返回级别和级别分系数
        /// <summary>
        /// 学术著作：根据来源(Source)和著作类型(Type)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        /// </summary>
        /// <param name="LZJModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetZhuZuoJiBie(ZQUSR.Model.sr_LwZzJc LZJModel)
        {
            return dal.GetZhuZuoJiBie(LZJModel);
        } 
        #endregion

        #region 科研项目：返回级别和级别分系数
        /// <summary>
        /// 科研项目：根据项目类型(Type)和项目来源(Source)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        /// </summary>
        /// <param name="ProjectModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetXiangMuJiBie(ZQUSR.Model.sr_Project ProjectModel)
        {
            return dal.GetXiangMuJiBie(ProjectModel);
        }
        #endregion

        #region 科研项目：返回级别和级别分系数
        /// <summary>
        /// 科研项目：根据申报项目类型(Type)、项目来源(Source)和申报情况(Grade)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        /// <param name="ProjectModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetShenBaoJiBie(ZQUSR.Model.sr_Project ProjectModel)
        {
            return dal.GetShenBaoJiBie(ProjectModel);
        }
        #endregion

        #region 根据类别返回评定标准
        /// <summary>
        /// 根据类别返回评定标准   ——By Jianguo Fung
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        public DataSet GetEvaluateBySort(string sort)
        {
            return dal.GetEvaluateBySort(sort);
        }
        #endregion

        #region 更新级别和级别分系数（评定标准）
        /// <summary>
        /// 更新级别和级别分系数（评定标准）－By Jianguo Fung
        /// </summary>
        public void UpdateJiBie(ZQUSR.Model.sr_Evaluate model)
        {
            dal.UpdateJiBie(model);
        }
        #endregion

        #region 是否存在该记录（学术著作/科技鉴定成果/科研项目）
        /// <summary>
        /// 是否存在该记录(Sort/Type/Source)（学术著作/科技鉴定成果/科研项目）  ——By Jianguo Fung
        /// </summary>
        public bool ExistsTypeSource(ZQUSR.Model.sr_Evaluate model)
        {
            return dal.ExistsTypeSource(model);
        }
        #endregion

        #region 是否存在该记录（专利成果）
        /// <summary>
        /// 是否存在该记录(Sort/Type) （专利成果） ——By Jianguo Fung
        /// </summary>
        public bool ExistsType(ZQUSR.Model.sr_Evaluate model)
        {
            return dal.ExistsType(model);
        }
        #endregion

        #region 是否存在该记录（社科鉴定成果）
        /// <summary>
        /// 是否存在该记录(Sort/Source/Grade)（社科鉴定成果）  ——By Jianguo Fung
        /// </summary>
        public bool ExistsSourceGrade(ZQUSR.Model.sr_Evaluate model)
        {
            return dal.ExistsSourceGrade(model);
        }
        #endregion

        #region 是否存在该记录（科技应用成果/软科学成果）
        /// <summary>
        /// 是否存在该记录(Sort/Source)（科技应用成果/软科学成果）  ——By Jianguo Fung
        /// </summary>
        public bool ExistsSource(ZQUSR.Model.sr_Evaluate model)
        {
            return dal.ExistsSource(model);
        }
        #endregion

        #region 是否存在该记录（获奖成果）
        /// <summary>
        /// 是否存在该记录(Sort/Type/Grade/AwardGrade)（获奖成果）  ——By Jianguo Fung
        /// </summary>
        public bool ExistsTypeGradeAwardGrade(ZQUSR.Model.sr_Evaluate model)
        {
            return dal.ExistsTypeGradeAwardGrade(model);
        }
        #endregion

        #region 是否存在该记录（项目申报）
        /// <summary>
        /// 是否存在该记录(Sort/Type/Source/Source)（项目申报）  ——By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsTypeSourceGrade(ZQUSR.Model.sr_Evaluate model)
        {
            return dal.ExistsTypeSourceGrade(model);
        }
        #endregion
	}
}

