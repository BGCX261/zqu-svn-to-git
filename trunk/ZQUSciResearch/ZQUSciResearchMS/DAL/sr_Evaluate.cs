using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_Evaluate。
	/// </summary>
	public class sr_Evaluate
	{
		public sr_Evaluate()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_EID", "sr_Evaluate"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_EID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Evaluate");
			strSql.Append(" where PK_EID=@PK_EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_EID", SqlDbType.Int,4)};
			parameters[0].Value = PK_EID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZQUSR.Model.sr_Evaluate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Evaluate(");
			strSql.Append("Sort,Type,Source,Grade,AwardGrade,Funds1,Funds2,JiBie,LevelFactor,Extra1,Extra2)");
			strSql.Append(" values (");
			strSql.Append("@Sort,@Type,@Source,@Grade,@AwardGrade,@Funds1,@Funds2,@JiBie,@LevelFactor,@Extra1,@Extra2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Source", SqlDbType.NVarChar,30),
					new SqlParameter("@Grade", SqlDbType.NVarChar,20),
					new SqlParameter("@AwardGrade", SqlDbType.NVarChar,5),
					new SqlParameter("@Funds1", SqlDbType.Float,8),
					new SqlParameter("@Funds2", SqlDbType.Float,8),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.Sort;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Source;
			parameters[3].Value = model.Grade;
			parameters[4].Value = model.AwardGrade;
			parameters[5].Value = model.Funds1;
			parameters[6].Value = model.Funds2;
			parameters[7].Value = model.JiBie;
			parameters[8].Value = model.LevelFactor;
			parameters[9].Value = model.Extra1;
			parameters[10].Value = model.Extra2;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据      //--modify by caiyuying 2011--1-20
		/// </summary>
		public void Update(ZQUSR.Model.sr_Evaluate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Evaluate set ");
			//strSql.Append("Sort=@Sort,");
			strSql.Append("Type=@Type,");
			strSql.Append("Source=@Source,");
			strSql.Append("Grade=@Grade,");
			strSql.Append("AwardGrade=@AwardGrade,");
			strSql.Append("Funds1=@Funds1,");
			strSql.Append("Funds2=@Funds2,");
			strSql.Append("JiBie=@JiBie,");
			strSql.Append("LevelFactor=@LevelFactor,");
			strSql.Append("Extra1=@Extra1,");
			strSql.Append("Extra2=@Extra2");
			strSql.Append(" where PK_EID=@PK_EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_EID", SqlDbType.Int,4),
					//new SqlParameter("@Sort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Source", SqlDbType.NVarChar,30),
					new SqlParameter("@Grade", SqlDbType.NVarChar,20),
					new SqlParameter("@AwardGrade", SqlDbType.NVarChar,5),
					new SqlParameter("@Funds1", SqlDbType.Float,8),
					new SqlParameter("@Funds2", SqlDbType.Float,8),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.PK_EID;
			//parameters[1].Value = model.Sort;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Source;
			parameters[3].Value = model.Grade;
			parameters[4].Value = model.AwardGrade;
			parameters[5].Value = model.Funds1;
			parameters[6].Value = model.Funds2;
			parameters[7].Value = model.JiBie;
			parameters[8].Value = model.LevelFactor;
			parameters[9].Value = model.Extra1;
			parameters[10].Value = model.Extra2;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_EID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Evaluate ");
			strSql.Append(" where PK_EID=@PK_EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_EID", SqlDbType.Int,4)};
			parameters[0].Value = PK_EID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Evaluate GetModel(int PK_EID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_EID,Sort,Type,Source,Grade,AwardGrade,Funds1,Funds2,JiBie,LevelFactor,Extra1,Extra2 from sr_Evaluate ");
			strSql.Append(" where PK_EID=@PK_EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_EID", SqlDbType.Int,4)};
			parameters[0].Value = PK_EID;

			ZQUSR.Model.sr_Evaluate model=new ZQUSR.Model.sr_Evaluate();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_EID"].ToString()!="")
				{
					model.PK_EID=int.Parse(ds.Tables[0].Rows[0]["PK_EID"].ToString());
				}
				model.Sort=ds.Tables[0].Rows[0]["Sort"].ToString();
				model.Type=ds.Tables[0].Rows[0]["Type"].ToString();
				model.Source=ds.Tables[0].Rows[0]["Source"].ToString();
				model.Grade=ds.Tables[0].Rows[0]["Grade"].ToString();
				model.AwardGrade=ds.Tables[0].Rows[0]["AwardGrade"].ToString();
				if(ds.Tables[0].Rows[0]["Funds1"].ToString()!="")
				{
					model.Funds1=decimal.Parse(ds.Tables[0].Rows[0]["Funds1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Funds2"].ToString()!="")
				{
					model.Funds2=decimal.Parse(ds.Tables[0].Rows[0]["Funds2"].ToString());
				}
				model.JiBie=ds.Tables[0].Rows[0]["JiBie"].ToString();
				if(ds.Tables[0].Rows[0]["LevelFactor"].ToString()!="")
				{
					model.LevelFactor=decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                    //model.LevelFactor = ds.Tables[0].Rows[0]["LevelFactor"].ToString();   //--by caiyuying
                }
				model.Extra1=ds.Tables[0].Rows[0]["Extra1"].ToString();
				model.Extra2=ds.Tables[0].Rows[0]["Extra2"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PK_EID,Sort,Type,Source,Grade,AwardGrade,Funds1,Funds2,JiBie,LevelFactor,Extra1,Extra2 ");
			strSql.Append(" FROM sr_Evaluate ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" PK_EID,Sort,Type,Source,Grade,AwardGrade,Funds1,Funds2,JiBie,LevelFactor,Extra1,Extra2 ");
			strSql.Append(" FROM sr_Evaluate ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "sr_Evaluate";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法

        #region 专利成果：返回级别和级别分系数
        /// <summary>
        /// 专利成果：根据专利类型(Type)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetZhuanLiJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Type=@Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,10)};
            parameters[0].Value = AchievementModel.Type;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.JiBie = ds.Tables[0].Rows[0]["JiBie"].ToString();
                if (ds.Tables[0].Rows[0]["LevelFactor"].ToString() != "")
                {
                    model.LevelFactor = decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Type=@Type and Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = AchievementModel.Type;
            parameters[1].Value = AchievementModel.Unit;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.JiBie = ds.Tables[0].Rows[0]["JiBie"].ToString();
                if (ds.Tables[0].Rows[0]["LevelFactor"].ToString() != "")
                {
                    model.LevelFactor = decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
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
            string strSql = "select distinct Source from sr_Evaluate where Sort='"+ strClass +"'";
            return DbHelperSQL.Query(strSql.ToString());
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
            string strSql = "select distinct Type from sr_Evaluate where Sort='" + strClass + "'";
            return DbHelperSQL.Query(strSql.ToString());
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
            string strSql = "select distinct Grade from sr_Evaluate where Type='" + strClass + "'";
            return DbHelperSQL.Query(strSql.ToString());
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
            string strSql = "select distinct Type from sr_Evaluate where Sort='" + strClass + "'";
            return DbHelperSQL.Query(strSql.ToString());
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
            string strSql = "select distinct Source from sr_Evaluate where Sort='" + strClass + "' and Type='" + strType + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }  
        #endregion
        
        #region 社科鉴定成果：返回级别和级别分系数
		/// <summary>
        /// 社科鉴定成果：根据成果来源(Source)和鉴定等级(Grade)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetSKJDJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Source=@Source and Type=@Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@Source", SqlDbType.NVarChar,30),
                    new SqlParameter("@Type", SqlDbType.NVarChar,10)};
            parameters[0].Value = AchievementModel.Source;
            parameters[1].Value = AchievementModel.Grade;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.JiBie = ds.Tables[0].Rows[0]["JiBie"].ToString();
                if (ds.Tables[0].Rows[0]["LevelFactor"].ToString() != "")
                {
                    model.LevelFactor = decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }  
        #endregion

        #region 科技应用成果：返回级别和级别分系数
        /// <summary>
        /// 科技应用成果：根据成果来源（Source）返回对应的级别（JiBie）和级别分系数（LevelFactor） ——By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetKJYYJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = AchievementModel.Source;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.JiBie = ds.Tables[0].Rows[0]["JiBie"].ToString();
                if (ds.Tables[0].Rows[0]["LevelFactor"].ToString() != "")
                {
                    model.LevelFactor = decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = AchievementModel.Unit;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.JiBie = ds.Tables[0].Rows[0]["JiBie"].ToString();
                if (ds.Tables[0].Rows[0]["LevelFactor"].ToString() != "")
                {
                    model.LevelFactor = decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        } 
        #endregion

        #region 获奖成果：返回级别和级别分系数
        /// <summary>
        /// 获奖成果：根据(Type/Source/Grade)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetHuoJiangJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Type=@Type and Grade=@Source and AwardGrade=@Grade ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Source", SqlDbType.NVarChar,30),
                    new SqlParameter("@Grade", SqlDbType.NVarChar,20)};
            parameters[0].Value = AchievementModel.Type;
            parameters[1].Value = AchievementModel.Source;
            parameters[2].Value = AchievementModel.Grade;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.JiBie = ds.Tables[0].Rows[0]["JiBie"].ToString();
                if (ds.Tables[0].Rows[0]["LevelFactor"].ToString() != "")
                {
                    model.LevelFactor = decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
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
            string strSql = "select distinct Type from sr_Evaluate where Sort='" + strClass + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 学术著作：返回级别和级别分系数
        /// <summary>
        /// 学术著作：根据来源(Source)和著作类型(Type)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetZhuZuoJiBie(ZQUSR.Model.sr_LwZzJc LZJModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Type=@Type and Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = LZJModel.Type;
            parameters[1].Value = LZJModel.Source;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.JiBie = ds.Tables[0].Rows[0]["JiBie"].ToString();
                if (ds.Tables[0].Rows[0]["LevelFactor"].ToString() != "")
                {
                    model.LevelFactor = decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 科研项目：返回级别和级别分系数
        /// <summary>
        /// 科研项目：根据项目类型(Type)和项目来源(Source)返回对应的级别(JiBie)及级别分系数(LevelFactor)     ——By caiyuying
        /// </summary>
        /// <param name="ProjectModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetXiangMuJiBie(ZQUSR.Model.sr_Project ProjectModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Sort=@Sort and Type=@Type and Source=@Source ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Sort",SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = ProjectModel.SmallSort;
            parameters[1].Value = ProjectModel.Type;
            parameters[2].Value = ProjectModel.Source;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.JiBie = ds.Tables[0].Rows[0]["JiBie"].ToString();
                if (ds.Tables[0].Rows[0]["LevelFactor"].ToString() != "")
                {
                    model.LevelFactor = decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Sort=@Sort and Type=@Type and Source=@Source and Grade=@Grade ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Sort",SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30),
                    new SqlParameter("@Grade", SqlDbType.NVarChar,20)};
            parameters[0].Value = ProjectModel.SmallSort;
            parameters[1].Value = ProjectModel.Type;
            parameters[2].Value = ProjectModel.Source;
            parameters[3].Value = ProjectModel.ReviewState;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.JiBie = ds.Tables[0].Rows[0]["JiBie"].ToString();
                if (ds.Tables[0].Rows[0]["LevelFactor"].ToString() != "")
                {
                    model.LevelFactor = decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
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
            string strSql = "select * from sr_Evaluate where Sort='" + sort + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 更新级别和级别分系数（评定标准）
        /// <summary>
        /// 更新级别和级别分系数（评定标准）－By Jianguo Fung
        /// </summary>
        public void UpdateJiBie(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_Evaluate set ");
            strSql.Append("JiBie=@JiBie,");
            strSql.Append("LevelFactor=@LevelFactor ");
            strSql.Append(" where PK_EID=@PK_EID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_EID", SqlDbType.Int,4),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8)};
            parameters[0].Value = model.PK_EID;
            parameters[1].Value = model.JiBie;
            parameters[2].Value = model.LevelFactor;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        } 
        #endregion

        #region 是否存在该记录（学术著作/科技鉴定成果/科研项目）
        /// <summary>
        /// 是否存在该记录(Sort/Type/Source)（学术著作/科技鉴定成果/科研项目）  ——By Jianguo Fung
        /// </summary>
        public bool ExistsTypeSource(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Type=@Type and ");
            strSql.Append(" Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Source;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        } 
        #endregion

        #region 是否存在该记录（专利成果）
        /// <summary>
        /// 是否存在该记录(Sort/Type) （专利成果） ——By Jianguo Fung
        /// </summary>
        public bool ExistsType(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Type=@Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Type", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Type;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region 是否存在该记录（社科鉴定成果）
        /// <summary>
        /// 是否存在该记录(Sort/Source/Grade)（社科鉴定成果）  ——By Jianguo Fung
        /// </summary>
        public bool ExistsSourceGrade(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Source=@Source and ");
            strSql.Append(" Grade=@Grade ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30),
                    new SqlParameter("@Grade", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Source;
            parameters[2].Value = model.Grade;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region 是否存在该记录（科技应用成果/软科学成果）
        /// <summary>
        /// 是否存在该记录(Sort/Source)（科技应用成果/软科学成果）  ——By Jianguo Fung
        /// </summary>
        public bool ExistsSource(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Source;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region 是否存在该记录（获奖成果）
        /// <summary>
        /// 是否存在该记录(Sort/Type/Grade/AwardGrade)（获奖成果）  ——By Jianguo Fung
        /// </summary>
        public bool ExistsTypeGradeAwardGrade(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Type=@Type and ");
            strSql.Append(" Grade=@Grade and ");
            strSql.Append(" AwardGrade=@AwardGrade ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Grade", SqlDbType.NVarChar,20),
                    new SqlParameter("@AwardGrade", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Grade;
            parameters[3].Value = model.AwardGrade;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Type=@Type and ");
            strSql.Append(" Source=@Source and ");
            strSql.Append(" Grade=@Grade ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30),
                    new SqlParameter("@Grade", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Source;
            parameters[3].Value = model.Grade;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        } 
        #endregion
	}
}

