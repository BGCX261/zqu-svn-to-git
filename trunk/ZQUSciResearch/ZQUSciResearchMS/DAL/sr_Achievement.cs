using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_Achievement。
	/// </summary>
	public class sr_Achievement
	{
		public sr_Achievement()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PK_AID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Achievement");
			strSql.Append(" where PK_AID=@PK_AID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_AID", SqlDbType.NVarChar,50)};
			parameters[0].Value = PK_AID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ZQUSR.Model.sr_Achievement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Achievement(");
			strSql.Append("PK_AID,FK_UserID,BigSort,SmallSort,Type,Title,AddTime,Unit,Source,PublishTime,Number,Rank,Population,AllAuthor,SchoolSign,Grade,Remark,AuditState,JiBie,LevelFactor,PerScore,Rewards,Bounty,ShiFa,Extra1,Extra2,Extra3,Extra4,Extra5)");
			strSql.Append(" values (");
			strSql.Append("@PK_AID,@FK_UserID,@BigSort,@SmallSort,@Type,@Title,@AddTime,@Unit,@Source,@PublishTime,@Number,@Rank,@Population,@AllAuthor,@SchoolSign,@Grade,@Remark,@AuditState,@JiBie,@LevelFactor,@PerScore,@Rewards,@Bounty,@ShiFa,@Extra1,@Extra2,@Extra3,@Extra4,@Extra5)");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_AID", SqlDbType.NVarChar,16),
					new SqlParameter("@FK_UserID", SqlDbType.NVarChar,10),
					new SqlParameter("@BigSort", SqlDbType.NVarChar,10),
					new SqlParameter("@SmallSort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Unit", SqlDbType.NVarChar,20),
					new SqlParameter("@Source", SqlDbType.NVarChar,70),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@Number", SqlDbType.NVarChar,15),
					new SqlParameter("@Rank", SqlDbType.Int,4),
					new SqlParameter("@Population", SqlDbType.Int,4),
					new SqlParameter("@AllAuthor", SqlDbType.NVarChar,60),
					new SqlParameter("@SchoolSign", SqlDbType.NVarChar,10),
					new SqlParameter("@Grade", SqlDbType.NVarChar,20),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@AuditState", SqlDbType.NVarChar,10),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@PerScore", SqlDbType.Float,8),
					new SqlParameter("@Rewards", SqlDbType.Float,8),
					new SqlParameter("@Bounty", SqlDbType.Float,8),
					new SqlParameter("@ShiFa", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra3", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra4", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra5", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.PK_AID;
			parameters[1].Value = model.FK_UserID;
			parameters[2].Value = model.BigSort;
			parameters[3].Value = model.SmallSort;
			parameters[4].Value = model.Type;
			parameters[5].Value = model.Title;
			parameters[6].Value = model.AddTime;
			parameters[7].Value = model.Unit;
			parameters[8].Value = model.Source;
			parameters[9].Value = model.PublishTime;
			parameters[10].Value = model.Number;
			parameters[11].Value = model.Rank;
			parameters[12].Value = model.Population;
			parameters[13].Value = model.AllAuthor;
			parameters[14].Value = model.SchoolSign;
			parameters[15].Value = model.Grade;
			parameters[16].Value = model.Remark;
			parameters[17].Value = model.AuditState;
			parameters[18].Value = model.JiBie;
			parameters[19].Value = model.LevelFactor;
			parameters[20].Value = model.PerScore;
			parameters[21].Value = model.Rewards;
			parameters[22].Value = model.Bounty;
			parameters[23].Value = model.ShiFa;
			parameters[24].Value = model.Extra1;
			parameters[25].Value = model.Extra2;
			parameters[26].Value = model.Extra3;
			parameters[27].Value = model.Extra4;
			parameters[28].Value = model.Extra5;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_Achievement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Achievement set ");
			strSql.Append("FK_UserID=@FK_UserID,");
			strSql.Append("BigSort=@BigSort,");
			strSql.Append("SmallSort=@SmallSort,");
			strSql.Append("Type=@Type,");
			strSql.Append("Title=@Title,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("Source=@Source,");
			strSql.Append("PublishTime=@PublishTime,");
			strSql.Append("Number=@Number,");
			strSql.Append("Rank=@Rank,");
			strSql.Append("Population=@Population,");
			strSql.Append("AllAuthor=@AllAuthor,");
			strSql.Append("SchoolSign=@SchoolSign,");
			strSql.Append("Grade=@Grade,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("AuditState=@AuditState,");
			strSql.Append("JiBie=@JiBie,");
			strSql.Append("LevelFactor=@LevelFactor,");
			strSql.Append("PerScore=@PerScore,");
			strSql.Append("Rewards=@Rewards,");
			strSql.Append("Bounty=@Bounty,");
			strSql.Append("ShiFa=@ShiFa,");
			strSql.Append("Extra1=@Extra1,");
			strSql.Append("Extra2=@Extra2,");
			strSql.Append("Extra3=@Extra3,");
			strSql.Append("Extra4=@Extra4,");
			strSql.Append("Extra5=@Extra5");
			strSql.Append(" where PK_AID=@PK_AID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_AID", SqlDbType.NVarChar,16),
					new SqlParameter("@FK_UserID", SqlDbType.NVarChar,10),
					new SqlParameter("@BigSort", SqlDbType.NVarChar,10),
					new SqlParameter("@SmallSort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Unit", SqlDbType.NVarChar,20),
					new SqlParameter("@Source", SqlDbType.NVarChar,70),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@Number", SqlDbType.NVarChar,15),
					new SqlParameter("@Rank", SqlDbType.Int,4),
					new SqlParameter("@Population", SqlDbType.Int,4),
					new SqlParameter("@AllAuthor", SqlDbType.NVarChar,60),
					new SqlParameter("@SchoolSign", SqlDbType.NVarChar,10),
					new SqlParameter("@Grade", SqlDbType.NVarChar,20),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@AuditState", SqlDbType.NVarChar,10),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@PerScore", SqlDbType.Float,8),
					new SqlParameter("@Rewards", SqlDbType.Float,8),
					new SqlParameter("@Bounty", SqlDbType.Float,8),
					new SqlParameter("@ShiFa", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra3", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra4", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra5", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.PK_AID;
			parameters[1].Value = model.FK_UserID;
			parameters[2].Value = model.BigSort;
			parameters[3].Value = model.SmallSort;
			parameters[4].Value = model.Type;
			parameters[5].Value = model.Title;
			parameters[6].Value = model.AddTime;
			parameters[7].Value = model.Unit;
			parameters[8].Value = model.Source;
			parameters[9].Value = model.PublishTime;
			parameters[10].Value = model.Number;
			parameters[11].Value = model.Rank;
			parameters[12].Value = model.Population;
			parameters[13].Value = model.AllAuthor;
			parameters[14].Value = model.SchoolSign;
			parameters[15].Value = model.Grade;
			parameters[16].Value = model.Remark;
			parameters[17].Value = model.AuditState;
			parameters[18].Value = model.JiBie;
			parameters[19].Value = model.LevelFactor;
			parameters[20].Value = model.PerScore;
			parameters[21].Value = model.Rewards;
			parameters[22].Value = model.Bounty;
			parameters[23].Value = model.ShiFa;
			parameters[24].Value = model.Extra1;
			parameters[25].Value = model.Extra2;
			parameters[26].Value = model.Extra3;
			parameters[27].Value = model.Extra4;
			parameters[28].Value = model.Extra5;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string PK_AID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Achievement ");
			strSql.Append(" where PK_AID=@PK_AID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_AID", SqlDbType.NVarChar,50)};
			parameters[0].Value = PK_AID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Achievement GetModel(string PK_AID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_AID,FK_UserID,BigSort,SmallSort,Type,Title,AddTime,Unit,Source,PublishTime,Number,Rank,Population,AllAuthor,SchoolSign,Grade,Remark,AuditState,JiBie,LevelFactor,PerScore,Rewards,Bounty,ShiFa,Extra1,Extra2,Extra3,Extra4,Extra5 from sr_Achievement ");
			strSql.Append(" where PK_AID=@PK_AID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_AID", SqlDbType.NVarChar,50)};
			parameters[0].Value = PK_AID;

			ZQUSR.Model.sr_Achievement model=new ZQUSR.Model.sr_Achievement();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.PK_AID=ds.Tables[0].Rows[0]["PK_AID"].ToString();
				model.FK_UserID=ds.Tables[0].Rows[0]["FK_UserID"].ToString();
				model.BigSort=ds.Tables[0].Rows[0]["BigSort"].ToString();
				model.SmallSort=ds.Tables[0].Rows[0]["SmallSort"].ToString();
				model.Type=ds.Tables[0].Rows[0]["Type"].ToString();
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
				}
				model.Unit=ds.Tables[0].Rows[0]["Unit"].ToString();
				model.Source=ds.Tables[0].Rows[0]["Source"].ToString();
				if(ds.Tables[0].Rows[0]["PublishTime"].ToString()!="")
				{
					model.PublishTime=DateTime.Parse(ds.Tables[0].Rows[0]["PublishTime"].ToString());
				}
				model.Number=ds.Tables[0].Rows[0]["Number"].ToString();
				if(ds.Tables[0].Rows[0]["Rank"].ToString()!="")
				{
					model.Rank=int.Parse(ds.Tables[0].Rows[0]["Rank"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Population"].ToString()!="")
				{
					model.Population=int.Parse(ds.Tables[0].Rows[0]["Population"].ToString());
				}
				model.AllAuthor=ds.Tables[0].Rows[0]["AllAuthor"].ToString();
				model.SchoolSign=ds.Tables[0].Rows[0]["SchoolSign"].ToString();
				model.Grade=ds.Tables[0].Rows[0]["Grade"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				model.AuditState=ds.Tables[0].Rows[0]["AuditState"].ToString();
				model.JiBie=ds.Tables[0].Rows[0]["JiBie"].ToString();
				if(ds.Tables[0].Rows[0]["LevelFactor"].ToString()!="")
				{
					model.LevelFactor=decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PerScore"].ToString()!="")
				{
					model.PerScore=decimal.Parse(ds.Tables[0].Rows[0]["PerScore"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rewards"].ToString()!="")
				{
					model.Rewards=decimal.Parse(ds.Tables[0].Rows[0]["Rewards"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Bounty"].ToString()!="")
				{
					model.Bounty=decimal.Parse(ds.Tables[0].Rows[0]["Bounty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ShiFa"].ToString()!="")
				{
					model.ShiFa=decimal.Parse(ds.Tables[0].Rows[0]["ShiFa"].ToString());
				}
				model.Extra1=ds.Tables[0].Rows[0]["Extra1"].ToString();
				model.Extra2=ds.Tables[0].Rows[0]["Extra2"].ToString();
				model.Extra3=ds.Tables[0].Rows[0]["Extra3"].ToString();
				model.Extra4=ds.Tables[0].Rows[0]["Extra4"].ToString();
				model.Extra5=ds.Tables[0].Rows[0]["Extra5"].ToString();
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
			strSql.Append("select PK_AID,FK_UserID,BigSort,SmallSort,Type,Title,AddTime,Unit,Source,PublishTime,Number,Rank,Population,AllAuthor,SchoolSign,Grade,Remark,AuditState,JiBie,LevelFactor,PerScore,Rewards,Bounty,ShiFa,Extra1,Extra2,Extra3,Extra4,Extra5 ");
			strSql.Append(" FROM sr_Achievement ");
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
			strSql.Append(" PK_AID,FK_UserID,BigSort,SmallSort,Type,Title,AddTime,Unit,Source,PublishTime,Number,Rank,Population,AllAuthor,SchoolSign,Grade,Remark,AuditState,JiBie,LevelFactor,PerScore,Rewards,Bounty,ShiFa,Extra1,Extra2,Extra3,Extra4,Extra5 ");
			strSql.Append(" FROM sr_Achievement ");
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
			parameters[0].Value = "sr_Achievement";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法


        #region 成果类新增
        /// <summary>
        /// 成果类新增      ——By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        public void AddAchievement(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sr_Achievement(");
            strSql.Append("PK_AID,FK_UserID,BigSort,SmallSort,Type,Title,AddTime,Unit,Source,PublishTime,Number,Rank,Population,AllAuthor,SchoolSign,Grade,Remark,JiBie,LevelFactor,PerScore)");
            strSql.Append(" values (");
            strSql.Append("@PK_AID,@FK_UserID,@BigSort,@SmallSort,@Type,@Title,@AddTime,@Unit,@Source,@PublishTime,@Number,@Rank,@Population,@AllAuthor,@SchoolSign,@Grade,@Remark,@JiBie,@LevelFactor,@PerScore)");
            SqlParameter[] parameters = {
                    new SqlParameter("@PK_AID", SqlDbType.NVarChar,16),
					new SqlParameter("@FK_UserID", SqlDbType.NVarChar,10),
					new SqlParameter("@BigSort", SqlDbType.NVarChar,10),
					new SqlParameter("@SmallSort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Unit", SqlDbType.NVarChar,20),
					new SqlParameter("@Source", SqlDbType.NVarChar,70),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@Number", SqlDbType.NVarChar,15),
					new SqlParameter("@Rank", SqlDbType.Int,4),
					new SqlParameter("@Population", SqlDbType.Int,4),
					new SqlParameter("@AllAuthor", SqlDbType.NVarChar,60),
					new SqlParameter("@SchoolSign", SqlDbType.NVarChar,10),
					new SqlParameter("@Grade", SqlDbType.NVarChar,20),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@PerScore", SqlDbType.Float,8)};
            parameters[0].Value = AchievementModel.PK_AID;
            parameters[1].Value = AchievementModel.FK_UserID;
            parameters[2].Value = AchievementModel.BigSort;
            parameters[3].Value = AchievementModel.SmallSort;
            parameters[4].Value = AchievementModel.Type;
            parameters[5].Value = AchievementModel.Title;
            parameters[6].Value = AchievementModel.AddTime;
            parameters[7].Value = AchievementModel.Unit;
            parameters[8].Value = AchievementModel.Source;
            parameters[9].Value = AchievementModel.PublishTime;
            parameters[10].Value = AchievementModel.Number;
            parameters[11].Value = AchievementModel.Rank;
            parameters[12].Value = AchievementModel.Population;
            parameters[13].Value = AchievementModel.AllAuthor;
            parameters[14].Value = AchievementModel.SchoolSign;
            parameters[15].Value = AchievementModel.Grade;
            parameters[16].Value = AchievementModel.Remark;
            parameters[17].Value = AchievementModel.JiBie;
            parameters[18].Value = AchievementModel.LevelFactor;
            parameters[19].Value = AchievementModel.PerScore;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion 

        #region 返回成果类数据列表（教师角色）
        /// <summary>
        /// 返回成果类数据列表（教师角色）     ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetAchievementByJs(ZQUSR.Model.sr_Achievement model)
        {
            string userID = model.FK_UserID;
            string smallSort = model.SmallSort;
            string strSql = "select * from sr_Achievement where FK_UserID='" + userID + "' and SmallSort='" + smallSort + "' order by PK_AID desc";
            return DbHelperSQL.Query(strSql.ToString());
        } 
        #endregion

        #region 返回成果类数据列表（秘书角色）
        /// <summary>
        /// 返回成果类数据列表（秘书角色）     ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetAchievementByMs(string userUnit)
        {
            string strSql = "select * from sr_viGetAchievement2 where UserUnit='" + userUnit + "' and AuditState not in('0') order by PK_AID desc";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 返回成果类数据列表（科员/处长角色）
        /// <summary>
        /// 返回成果类数据列表（科员/处长角色）     ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetAchievementByKy()
        {
            string strSql = "select * from sr_viGetAchievement3 where AuditState not in('0','1','2') order by PK_AID desc";
            return DbHelperSQL.Query(strSql.ToString());
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
            string strSql = "update sr_Achievement set AuditState=@AuditState where PK_AID=@PK_AID";
            SqlParameter[] parameters = {
					new SqlParameter("@AuditState", SqlDbType.NVarChar,10),
                    new SqlParameter("@PK_AID", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = state;
            parameters[1].Value = AID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
            string strSql = "update sr_Achievement set AuditState=@AuditState,Extra1=@Extra1 where PK_AID=@PK_AID";
            SqlParameter[] parameters = {
					new SqlParameter("@AuditState", SqlDbType.NVarChar,10),
                    new SqlParameter("@Extra1", SqlDbType.NVarChar,200),
                    new SqlParameter("@PK_AID", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = state;
            parameters[1].Value = reason;
            parameters[2].Value = AID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 根据成果编号删除一条记录
        /// <summary>
        /// 根据成果编号删除一条记录    ——By Jianguo Fung
        /// </summary>
        /// <param name="PK_AID"></param>
        public void DeleteZhuanLi(string PK_AID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sr_Achievement ");
            strSql.Append(" where PK_AID=@PK_AID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_AID", SqlDbType.NVarChar,50)};
            parameters[0].Value = PK_AID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        } 
        #endregion

        #region 返回数据列表（教师角色）
        /// <summary>
        /// 返回数据列表（教师角色）     ——By Jianguo Fung
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public DataSet GetDataByJiaoshi(string UserID, string strState)
        {
            string strSql = "SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByJiaoshi where FK_UserID='" + UserID + "' "+ strState +"";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByJiaoshi where FK_UserID='" + UserID + "' "+ strState +"";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Anchorperson,Source,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByJiaoshi where FK_UserID='" + UserID + "' "+ strState +"";
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 全部返回
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetListByJiaoshi(string UserID)
        {
            return GetDataByJiaoshi(UserID, "");
        }

        /// <summary>
        /// 返回全部数据
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetListByJiaoshiAudit(string UserID)
        {
            return GetDataByJiaoshi(UserID, "");
        }
        /// <summary>
        /// 返回未提交数据列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetListJiaoshiUncommit(string UserID)
        {
            return GetDataByJiaoshi(UserID, " and AuditState in('0')");
        }
        /// <summary>
        /// 返回审核数据列表（审核通过和不通过）
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetListJiaoshiAuditSituation(string UserID)
        {
            return GetDataByJiaoshi(UserID, " and AuditState not in('0')");
        }
        #endregion

        #region 按类别返回数据列表（教师角色）
        /// <summary>
        /// 返回数据列表（教师角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshibySort(string UserID,string strSort)
        {
            string strSql = "SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByJiaoshi where FK_UserID='" + UserID + "' and SmallSort='"+strSort+"'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByJiaoshi where FK_UserID='" + UserID + "' and SmallSort='" + strSort + "'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Anchorperson,Source,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByJiaoshi where FK_UserID='" + UserID + "' and SmallSort='" + strSort + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 按日期返回数据列表（教师角色）
        /// <summary>
        /// 返回数据列表（教师角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshibyDate(string UserID,string strStart, string strEnd)
        {
            string strSql = "SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByJiaoshi where FK_UserID='" + UserID + "'and  PublishTime>='"+strStart+"' and PublishTime<='"+strEnd+"'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByJiaoshi where FK_UserID='" + UserID + "' and  PublishTime>='" + strStart + "' and PublishTime<='" + strEnd + "'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Anchorperson,Source,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByJiaoshi where FK_UserID='" + UserID + "' and  PublishTime1>='" + strStart + "' and PublishTime1<='" + strEnd + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 按日期与审核状态返回数据列表（教师角色）
        /// <summary>
        /// 按日期与审核状态返回数据列表（教师角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshibyDateAudit(string UserID, string strStart, string strEnd,string strAuditState)
        {
            string strSql = "SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByJiaoshi where FK_UserID='" + UserID + "'and  AuditState in('"+strAuditState+"') and PublishTime>='" + strStart + "' and PublishTime<='" + strEnd + "'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByJiaoshi where FK_UserID='" + UserID + "' and  AuditState in('" + strAuditState + "') and PublishTime>='" + strStart + "' and PublishTime<='" + strEnd + "'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Anchorperson,Source,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByJiaoshi where FK_UserID='" + UserID + "' and  AuditState in('" + strAuditState + "') and PublishTime1>='" + strStart + "' and PublishTime1<='" + strEnd + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 按审核状态返回数据列表（教师角色）
        /// <summary>
        /// 按审核状态返回数据列表（教师角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshibyAudit(string UserID,string strAuditState)
        {
            string strSql = "SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByJiaoshi where FK_UserID='" + UserID + "'and  AuditState in('" + strAuditState + "') ";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByJiaoshi where FK_UserID='" + UserID + "' and  AuditState in('" + strAuditState + "')";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Anchorperson,Source,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByJiaoshi where FK_UserID='" + UserID + "' and  AuditState in('" + strAuditState + "') ";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 按报表格式返回数据列表（教师角色）
        /// <summary>
        /// 返回数据列表（教师角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByJiaoshiPrint(string UserID)
        {
            string strSql = "SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByJiaoshi where FK_UserID='" + UserID + "'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByJiaoshi where FK_UserID='" + UserID + "'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Anchorperson,Source,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByJiaoshi where FK_UserID='" + UserID + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion


        #region 返回数据列表（秘书角色）
        /// <summary>
        /// 条件函数（公用）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDataByMishu(string strWhere)
        {
            string strSql = "SELECT FK_UserID,UserName,SmallSort,PK_AID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByMishu " + strWhere + "";
            strSql += " UNION SELECT FK_UserID,UserName,SmallSort,PK_AID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByMiShu " + strWhere + "";
            strSql += " UNION SELECT FK_UserID,UserName,SmallSort,PK_AID,Title,Anchorperson,Source,PublishTime1 as PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByMishu " + strWhere + "";
            return DbHelperSQL.Query(strSql.ToString());
        }

        #region 根据类别汇总返回数据列表（秘书角色）
        /// <summary>
        /// 条件函数（公用）类别汇总
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string GetCountByMishuAch(string strWhere)
        {
            string strSql = "select count(SmallSort) as counts from sr_ViewGetAchievementByMishu "+ strWhere +" ";
            DataSet ds=DbHelperSQL.Query(strSql.ToString()); 
            if (ds.Tables.Count!=0)
            {
                return ds.Tables[0].Rows[0]["counts"].ToString();
            }
            return "0";
        }
        public string GetCountByMishuLw(string strWhere)
        {
            string strSql = "select count(SmallSort) as counts from sr_ViewLwZzJcByMiShu " + strWhere + " ";
            DataSet ds=DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables.Count != 0)
            {
                return ds.Tables[0].Rows[0]["counts"].ToString();
            }
            return "0";
        }
        public string GetCountByMishuPro(string strWhere)
        {
            string strSql = "select count(SmallSort) as counts from sr_ViewProjectByMishu " + strWhere + " ";
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables.Count != 0)
            {
                return ds.Tables[0].Rows[0]["counts"].ToString();
            }
            return "0";
        }
        #endregion
        /// <summary>
        /// 返回数据列表（秘书角色）
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishu(string UserUnit)
        {
            string strWhere = "where UserUnit='" + UserUnit + "'";
            return GetDataByMishu(strWhere);
        }

        /// <summary>
        /// 返回审核状态为5、7数据列表（秘书角色）
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuAuditPri(string UserUnit)
        {
            string strWhere = "where UserUnit='" + UserUnit + "' and AuditState in('5','7')";
            return GetDataByMishu(strWhere);
        }

        /// <summary>
        /// 按类别返回数据列表（秘书角色）  --by caiyuying
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuBySort(string UserUnit,string strSort)
        {
            string strWhere = "where UserUnit='" + UserUnit + "' and SmallSort='" + strSort + "'";
            return GetDataByMishu(strWhere);
        }

        /// <summary>
        /// 按日期返回数据列表（秘书角色）  --by caiyuying
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuByDate(string UserUnit, string strStart, string strEnd)
        {
            string strSql = "SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByJiaoshi where UserUnit='" + UserUnit + "' and  PublishTime>='" + strStart + "' and PublishTime<='" + strEnd + "'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByJiaoshi where UserUnit='" + UserUnit + "' and  PublishTime>='" + strStart + "' and PublishTime<='" + strEnd + "'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Anchorperson,Source,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByJiaoshi where UserUnit='" + UserUnit + "' and  PublishTime1>='" + strStart + "' and PublishTime1<='" + strEnd + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 按日期和审核状态返回数据列表（秘书角色）  --by caiyuying
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuByDateAudit(string UserUnit, string strStart, string strEnd)
        {
            string strSql = "SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByJiaoshi where UserUnit='" + UserUnit + "' and AuditState in('5','7')  and PublishTime>='" + strStart + "' and PublishTime<='" + strEnd + "'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByJiaoshi where UserUnit='" + UserUnit + "' and AuditState in('5','7') and PublishTime>='" + strStart + "' and PublishTime<='" + strEnd + "'";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Anchorperson,Source,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByJiaoshi where UserUnit='" + UserUnit + "' and  AuditState in('5','7') and PublishTime1>='" + strStart + "' and PublishTime1<='" + strEnd + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 按姓名返回数据列表（秘书角色）  --by caiyuying
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuByName(string UserUnit, string strName)
        {
            string strWhere = "where UserUnit='" + UserUnit + "' and UserName like '%"+ strName +"%'";
            return GetDataByMishu(strWhere);
        }

        /// <summary>
        /// 根据类别的汇总返回获得数据列表(统计每个类别的次数)
        /// </summary>
        public string GetNumBySortCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(SmallSort)as counts");
            strSql.Append(" FROM sr_Achievement ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = new DataSet();
            ds=DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count!=0)
            {
                return ds.Tables[0].Rows[0]["counts"].ToString();
            }
            else
            {
                return "找不到数据!";
            }
        }

        #region 按报表格式返回数据列表（秘书角色）
        /// <summary>
        /// 返回数据列表（秘书角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByMishuPrint(string UserUnit)
        {
            string strSql = "SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore from sr_ViewGetAchievementByJiaoshi where UserUnit='" + UserUnit + "' and  AuditState in (5,7)";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore from sr_ViewLwZzJcByJiaoshi where UserUnit='" + UserUnit + "' and  AuditState in (5,7)";
            strSql += " UNION SELECT UserName,SmallSort,PK_AID,FK_UserID,Title,Anchorperson,Source as Unit,PublishTime1,LevelFactor,JiBie,Perscore from sr_ViewProjectByJiaoshi where UserUnit='" + UserUnit + "' and  AuditState in (5,7)";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        /// <summary>
        /// 返回未审核列表
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuAudit(string UserUnit)
        {
            string strWhere = "where UserUnit='" + UserUnit + "' and AuditState in('1')";
            return GetDataByMishu(strWhere);
        }
        /// <summary>
        /// 返回已审核列表
        /// </summary>
        /// <param name="UserUnit"></param>
        /// <returns></returns>
        public DataSet GetListByMishuAudited(string UserUnit, string UserID)
        {
            string strWhere = "where UserUnit='" + UserUnit + "' and AuditState in('2','3') and FK_UserID<>'"+ UserID +"'";
            return GetDataByMishu(strWhere);
        }
        #endregion

        #region 返回数据列表（科员角色）
        /// <summary>
        /// 条件函数（公用）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDataByKeyuan(string strWhere)
        {
            string strSql = "SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByKeyuan " + strWhere + "";
            strSql += " UNION SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByKeyuan " + strWhere + "";
            strSql += " UNION SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Anchorperson,Source as Unit,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByKeyuan " + strWhere + "";
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 返回数据列表  ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuan()
        {
            return GetDataByKeyuan("");
        }

        /// <summary>
        /// 返回审核状态为5和7的数据列表  ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanAuditPri()
        {
            return GetDataByKeyuan(" where AuditState in('5','7')");
        }
        /// <summary>
        /// 根据类别返回数据列表  ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanBySort(string strSort)
        {
            string strwhere = "where SmallSort='" + strSort + "'";
            return GetDataByKeyuan(strwhere);
        }
        /// <summary>
        /// 根据学院返回数据列表  ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanByUnit(string strUnit)
        {
            string strwhere = "where UserUnit='" + strUnit + "'";
            return GetDataByKeyuan(strwhere);
        }
        /// <summary>
        /// 根据日期返回数据列表   ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanByDate(string strStart,string strEnd)
        {
            string strSql = "SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByKeyuan where PublishTime>='" + strStart + "' and PublishTime<='" + strEnd + "'";
            strSql += " UNION SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByKeyuan where PublishTime>='" + strStart + "' and PublishTime<='" + strEnd + "'";
            strSql += " UNION SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Anchorperson,Source,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByKeyuan where PublishTime1>='" + strStart + "' and PublishTime1<='" + strEnd + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据日期和审核状态(5\7)返回数据列表   ——By caiyuying（科员角色）
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanByDateAudit(string strStart, string strEnd)
        {
            string strSql = "SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByKeyuan where AuditState in('5','7') and PublishTime>='" + strStart + "' and PublishTime<='" + strEnd + "'";
            strSql += " UNION SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByKeyuan where AuditState in('5','7') and PublishTime>='" + strStart + "' and PublishTime<='" + strEnd + "'";
            strSql += " UNION SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Anchorperson,Source,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByKeyuan where AuditState in('5','7') and PublishTime1>='" + strStart + "' and PublishTime1<='" + strEnd + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据姓名返回数据列表   ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeyuanByName(string strName)
        {
            string strwhere = "where UserName like '%" + strName + "%'";
            return GetDataByKeyuan(strwhere);
        }
        /// <summary>
        /// 按报表格式返回数据列表（科员角色）     ——By caiyuying
        /// </summary>
        /// <returns></returns>
        public DataSet GetListByKeYuanPrint()
        {
            string strSql = "SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Rank,rtrim(ltrim(isnull(unit,'')+isnull(source,'')))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewGetAchievementByKeyuan where AuditState in (5,7)";
            strSql += " UNION SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Rank,rtrim(ltrim(isnull(unit,'')+'('+isnull(source,'')+')'))as Unit,PublishTime,LevelFactor,JiBie,Perscore,AuditState from sr_ViewLwZzJcByKeyuan where AuditState in (5,7)";
            strSql += " UNION SELECT UserName,UserUnit,PK_AID,SmallSort,PK_AID,Title,Anchorperson,Source,PublishTime1,LevelFactor,JiBie,Perscore,AuditState from sr_ViewProjectByKeyuan where AuditState in (5,7)";
            return DbHelperSQL.Query(strSql.ToString());
        }


       /// <summary>
       /// 返回未审核列表
       /// </summary>
       /// <returns></returns>
        public DataSet GetListByKeyuanAudit()
        {
            string strWhere = "where AuditState in('3')";
            return GetDataByKeyuan(strWhere);
        }

       /// <summary>
       /// 返回已审核列表
       /// </summary>
       /// <returns></returns>
        public DataSet GetListByKeyuanAudited()
        {
            string strWhere = "where AuditState in('4','5','6','7')";
            return GetDataByKeyuan(strWhere);
        }

        
        #endregion

        #region 更新级别分系数、级别、个人得分
        /// <summary>
        /// 更新级别分系数、级别、个人得分
        /// </summary>
        /// <param name="model"></param>
        public void UpdateJiBie(ZQUSR.Model.sr_Achievement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_Achievement set ");
            strSql.Append("JiBie=@JiBie,");
            strSql.Append("LevelFactor=@LevelFactor,");
            strSql.Append("PerScore=@PerScore ");
            strSql.Append(" where PK_AID=@PK_AID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_AID", SqlDbType.NVarChar,16),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@PerScore", SqlDbType.Float,8)};
            parameters[0].Value = model.PK_AID;
            parameters[1].Value = model.JiBie;
            parameters[2].Value = model.LevelFactor;
            parameters[3].Value = model.PerScore;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        } 
        #endregion
    }
}

