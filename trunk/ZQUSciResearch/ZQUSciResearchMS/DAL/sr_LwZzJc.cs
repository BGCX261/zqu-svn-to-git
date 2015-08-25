using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_LwZzJc。
	/// </summary>
	public class sr_LwZzJc
	{
		public sr_LwZzJc()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PK_LZID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_LwZzJc");
			strSql.Append(" where PK_LZID=@PK_LZID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_LZID", SqlDbType.NVarChar,50)};
			parameters[0].Value = PK_LZID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ZQUSR.Model.sr_LwZzJc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_LwZzJc(");
			strSql.Append("PK_LZID,FK_UserID,BigSort,SmallSort,Type,Title,AddTime,Unit,Source,PublishTime,Number1,Number2,Rank,Population,AllAuthor,SchoolSign,State,StateUnit,Word,Remark,AuditState,JiBie,LevelFactor,PerScore,Rewards,Bounty,ShiFa,Extra1,Extra2,Extra3,Extra4,Extra5)");
			strSql.Append(" values (");
			strSql.Append("@PK_LZID,@FK_UserID,@BigSort,@SmallSort,@Type,@Title,@AddTime,@Unit,@Source,@PublishTime,@Number1,@Number2,@Rank,@Population,@AllAuthor,@SchoolSign,@State,@StateUnit,@Word,@Remark,@AuditState,@JiBie,@LevelFactor,@PerScore,@Rewards,@Bounty,@ShiFa,@Extra1,@Extra2,@Extra3,@Extra4,@Extra5)");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_LZID", SqlDbType.NVarChar,16),
					new SqlParameter("@FK_UserID", SqlDbType.NVarChar,10),
					new SqlParameter("@BigSort", SqlDbType.NVarChar,10),
					new SqlParameter("@SmallSort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Unit", SqlDbType.NVarChar,100),
					new SqlParameter("@Source", SqlDbType.NVarChar,30),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@Number1", SqlDbType.NVarChar,20),
					new SqlParameter("@Number2", SqlDbType.NVarChar,20),
					new SqlParameter("@Rank", SqlDbType.Int,4),
					new SqlParameter("@Population", SqlDbType.Int,4),
					new SqlParameter("@AllAuthor", SqlDbType.NVarChar,60),
					new SqlParameter("@SchoolSign", SqlDbType.NVarChar,10),
					new SqlParameter("@State", SqlDbType.NVarChar,100),
					new SqlParameter("@StateUnit", SqlDbType.NVarChar,100),
					new SqlParameter("@Word", SqlDbType.Float,8),
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
			parameters[0].Value = model.PK_LZID;
			parameters[1].Value = model.FK_UserID;
			parameters[2].Value = model.BigSort;
			parameters[3].Value = model.SmallSort;
			parameters[4].Value = model.Type;
			parameters[5].Value = model.Title;
			parameters[6].Value = model.AddTime;
			parameters[7].Value = model.Unit;
			parameters[8].Value = model.Source;
			parameters[9].Value = model.PublishTime;
			parameters[10].Value = model.Number1;
			parameters[11].Value = model.Number2;
			parameters[12].Value = model.Rank;
			parameters[13].Value = model.Population;
			parameters[14].Value = model.AllAuthor;
			parameters[15].Value = model.SchoolSign;
			parameters[16].Value = model.State;
			parameters[17].Value = model.StateUnit;
			parameters[18].Value = model.Word;
			parameters[19].Value = model.Remark;
			parameters[20].Value = model.AuditState;
			parameters[21].Value = model.JiBie;
			parameters[22].Value = model.LevelFactor;
			parameters[23].Value = model.PerScore;
			parameters[24].Value = model.Rewards;
			parameters[25].Value = model.Bounty;
			parameters[26].Value = model.ShiFa;
			parameters[27].Value = model.Extra1;
			parameters[28].Value = model.Extra2;
			parameters[29].Value = model.Extra3;
			parameters[30].Value = model.Extra4;
			parameters[31].Value = model.Extra5;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_LwZzJc model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_LwZzJc set ");
			strSql.Append("FK_UserID=@FK_UserID,");
			strSql.Append("BigSort=@BigSort,");
			strSql.Append("SmallSort=@SmallSort,");
			strSql.Append("Type=@Type,");
			strSql.Append("Title=@Title,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("Source=@Source,");
			strSql.Append("PublishTime=@PublishTime,");
			strSql.Append("Number1=@Number1,");
			strSql.Append("Number2=@Number2,");
			strSql.Append("Rank=@Rank,");
			strSql.Append("Population=@Population,");
			strSql.Append("AllAuthor=@AllAuthor,");
			strSql.Append("SchoolSign=@SchoolSign,");
			strSql.Append("State=@State,");
			strSql.Append("StateUnit=@StateUnit,");
			strSql.Append("Word=@Word,");
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
			strSql.Append(" where PK_LZID=@PK_LZID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_LZID", SqlDbType.NVarChar,16),
					new SqlParameter("@FK_UserID", SqlDbType.NVarChar,10),
					new SqlParameter("@BigSort", SqlDbType.NVarChar,10),
					new SqlParameter("@SmallSort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Unit", SqlDbType.NVarChar,100),
					new SqlParameter("@Source", SqlDbType.NVarChar,30),
					new SqlParameter("@PublishTime", SqlDbType.DateTime),
					new SqlParameter("@Number1", SqlDbType.NVarChar,20),
					new SqlParameter("@Number2", SqlDbType.NVarChar,20),
					new SqlParameter("@Rank", SqlDbType.Int,4),
					new SqlParameter("@Population", SqlDbType.Int,4),
					new SqlParameter("@AllAuthor", SqlDbType.NVarChar,60),
					new SqlParameter("@SchoolSign", SqlDbType.NVarChar,10),
					new SqlParameter("@State", SqlDbType.NVarChar,100),
					new SqlParameter("@StateUnit", SqlDbType.NVarChar,100),
					new SqlParameter("@Word", SqlDbType.Float,8),
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
			parameters[0].Value = model.PK_LZID;
			parameters[1].Value = model.FK_UserID;
			parameters[2].Value = model.BigSort;
			parameters[3].Value = model.SmallSort;
			parameters[4].Value = model.Type;
			parameters[5].Value = model.Title;
			parameters[6].Value = model.AddTime;
			parameters[7].Value = model.Unit;
			parameters[8].Value = model.Source;
			parameters[9].Value = model.PublishTime;
			parameters[10].Value = model.Number1;
			parameters[11].Value = model.Number2;
			parameters[12].Value = model.Rank;
			parameters[13].Value = model.Population;
			parameters[14].Value = model.AllAuthor;
			parameters[15].Value = model.SchoolSign;
			parameters[16].Value = model.State;
			parameters[17].Value = model.StateUnit;
			parameters[18].Value = model.Word;
			parameters[19].Value = model.Remark;
			parameters[20].Value = model.AuditState;
			parameters[21].Value = model.JiBie;
			parameters[22].Value = model.LevelFactor;
			parameters[23].Value = model.PerScore;
			parameters[24].Value = model.Rewards;
			parameters[25].Value = model.Bounty;
			parameters[26].Value = model.ShiFa;
			parameters[27].Value = model.Extra1;
			parameters[28].Value = model.Extra2;
			parameters[29].Value = model.Extra3;
			parameters[30].Value = model.Extra4;
			parameters[31].Value = model.Extra5;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string PK_LZID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_LwZzJc ");
			strSql.Append(" where PK_LZID=@PK_LZID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_LZID", SqlDbType.NVarChar,50)};
			parameters[0].Value = PK_LZID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_LwZzJc GetModel(string PK_LZID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_LZID,FK_UserID,BigSort,SmallSort,Type,Title,AddTime,Unit,Source,PublishTime,Number1,Number2,Rank,Population,AllAuthor,SchoolSign,State,StateUnit,Word,Remark,AuditState,JiBie,LevelFactor,PerScore,Rewards,Bounty,ShiFa,Extra1,Extra2,Extra3,Extra4,Extra5 from sr_LwZzJc ");
			strSql.Append(" where PK_LZID=@PK_LZID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_LZID", SqlDbType.NVarChar,50)};
			parameters[0].Value = PK_LZID;

			ZQUSR.Model.sr_LwZzJc model=new ZQUSR.Model.sr_LwZzJc();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.PK_LZID=ds.Tables[0].Rows[0]["PK_LZID"].ToString();
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
				model.Number1=ds.Tables[0].Rows[0]["Number1"].ToString();
				model.Number2=ds.Tables[0].Rows[0]["Number2"].ToString();
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
				model.State=ds.Tables[0].Rows[0]["State"].ToString();
				model.StateUnit=ds.Tables[0].Rows[0]["StateUnit"].ToString();
				if(ds.Tables[0].Rows[0]["Word"].ToString()!="")
				{
					model.Word=decimal.Parse(ds.Tables[0].Rows[0]["Word"].ToString());
				}
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
			strSql.Append("select PK_LZID,FK_UserID,BigSort,SmallSort,Type,Title,AddTime,Unit,Source,PublishTime,Number1,Number2,Rank,Population,AllAuthor,SchoolSign,State,StateUnit,Word,Remark,AuditState,JiBie,LevelFactor,PerScore,Rewards,Bounty,ShiFa,Extra1,Extra2,Extra3,Extra4,Extra5 ");
			strSql.Append(" FROM sr_LwZzJc ");
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
			strSql.Append(" PK_LZID,FK_UserID,BigSort,SmallSort,Type,Title,AddTime,Unit,Source,PublishTime,Number1,Number2,Rank,Population,AllAuthor,SchoolSign,State,StateUnit,Word,Remark,AuditState,JiBie,LevelFactor,PerScore,Rewards,Bounty,ShiFa,Extra1,Extra2,Extra3,Extra4,Extra5 ");
			strSql.Append(" FROM sr_LwZzJc ");
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
			parameters[0].Value = "sr_LwZzJc";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法

        #region 返回学术论文/学术著作/教材数据列表（教师角色）
        /// <summary>
        /// 返回学术论文/学术著作/教材数据列表（教师角色）     ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetLwZzJcByJs(ZQUSR.Model.sr_LwZzJc model)
        {
            string userID = model.FK_UserID;
            string smallSort = model.SmallSort;
            string strSql = "select * from sr_LwZzJc where FK_UserID='" + userID + "' and SmallSort='" + smallSort + "' order by PK_LZID desc";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region  返回类别的汇总 （秘书角色）
        /// <summary>
        /// 根据类别的汇总返回获得数据列表(统计每个类别的次数)
        /// </summary>
        public string GetNumBySortCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(SmallSort)as counts");
            strSql.Append(" FROM sr_LwZzJc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = new DataSet();
            ds=DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count != 0)
            {
                return ds.Tables[0].Rows[0]["counts"].ToString();
            }
            else
            {
                return "找不到数据";
            }
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
            string strSql = "update sr_LwZzJc set AuditState=@AuditState where PK_LZID=@PK_LZID";
            SqlParameter[] parameters = {
					new SqlParameter("@AuditState", SqlDbType.NVarChar,10),
                    new SqlParameter("@PK_LZID", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = state;
            parameters[1].Value = LZID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 更新审核状态（审核不通过）
        /// <summary>
        /// 更新审核状态（审核不通过）  －By Jianguo Fung
        /// </summary>
        /// <param name="LZID"></param>
        /// <param name="state"></param>
        public void UpdateAuditState(string LZID, string state, string reason)
        {
            string strSql = "update sr_LwZzJc set AuditState=@AuditState,Extra1=@Extra1 where PK_LZID=@PK_LZID";
            SqlParameter[] parameters = {
					new SqlParameter("@AuditState", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,200),
                    new SqlParameter("@PK_LZID", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = state;
            parameters[1].Value = reason;
            parameters[2].Value = LZID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 更新级别分系数、级别、个人得分
        /// <summary>
        /// 更新级别分系数、级别、个人得分
        /// </summary>
        /// <param name="model"></param>
        public void UpdateJiBie(ZQUSR.Model.sr_LwZzJc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_LwZzJc set ");
            strSql.Append("JiBie=@JiBie,");
            strSql.Append("LevelFactor=@LevelFactor,");
            strSql.Append("PerScore=@PerScore ");
            strSql.Append(" where PK_LZID=@PK_LZID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_LZID", SqlDbType.NVarChar,16),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@PerScore", SqlDbType.Float,8)};
            parameters[0].Value = model.PK_LZID;
            parameters[1].Value = model.JiBie;
            parameters[2].Value = model.LevelFactor ;
            parameters[3].Value = model.PerScore;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        } 
        #endregion
	}
}

