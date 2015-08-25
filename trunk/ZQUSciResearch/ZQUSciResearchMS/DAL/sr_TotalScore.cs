using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_TotalScore。
	/// </summary>
	public class sr_TotalScore
	{
		public sr_TotalScore()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_TID", "sr_TotalScore"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_TID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_TotalScore");
			strSql.Append(" where PK_TID=@PK_TID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_TID", SqlDbType.Int,4)};
			parameters[0].Value = PK_TID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZQUSR.Model.sr_TotalScore model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_TotalScore(");
			strSql.Append("FK_UserID,Year,TotalScore,TotalRewards,Extra1,Extra2)");
			strSql.Append(" values (");
			strSql.Append("@FK_UserID,@Year,@TotalScore,@TotalRewards,@Extra1,@Extra2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FK_UserID", SqlDbType.NVarChar,10),
					new SqlParameter("@Year", SqlDbType.NVarChar,4),
					new SqlParameter("@TotalScore", SqlDbType.Float,8),
					new SqlParameter("@TotalRewards", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.FK_UserID;
			parameters[1].Value = model.Year;
			parameters[2].Value = model.TotalScore;
			parameters[3].Value = model.TotalRewards;
			parameters[4].Value = model.Extra1;
			parameters[5].Value = model.Extra2;

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
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_TotalScore model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_TotalScore set ");
			strSql.Append("FK_UserID=@FK_UserID,");
			strSql.Append("Year=@Year,");
			strSql.Append("TotalScore=@TotalScore,");
			strSql.Append("TotalRewards=@TotalRewards,");
			strSql.Append("Extra1=@Extra1,");
			strSql.Append("Extra2=@Extra2");
			strSql.Append(" where PK_TID=@PK_TID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_TID", SqlDbType.Int,4),
					new SqlParameter("@FK_UserID", SqlDbType.NVarChar,10),
					new SqlParameter("@Year", SqlDbType.NVarChar,4),
					new SqlParameter("@TotalScore", SqlDbType.Float,8),
					new SqlParameter("@TotalRewards", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.PK_TID;
			parameters[1].Value = model.FK_UserID;
			parameters[2].Value = model.Year;
			parameters[3].Value = model.TotalScore;
			parameters[4].Value = model.TotalRewards;
			parameters[5].Value = model.Extra1;
			parameters[6].Value = model.Extra2;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_TID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_TotalScore ");
			strSql.Append(" where PK_TID=@PK_TID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_TID", SqlDbType.Int,4)};
			parameters[0].Value = PK_TID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_TotalScore GetModel(int PK_TID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_TID,FK_UserID,Year,TotalScore,TotalRewards,Extra1,Extra2 from sr_TotalScore ");
			strSql.Append(" where PK_TID=@PK_TID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_TID", SqlDbType.Int,4)};
			parameters[0].Value = PK_TID;

			ZQUSR.Model.sr_TotalScore model=new ZQUSR.Model.sr_TotalScore();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_TID"].ToString()!="")
				{
					model.PK_TID=int.Parse(ds.Tables[0].Rows[0]["PK_TID"].ToString());
				}
				model.FK_UserID=ds.Tables[0].Rows[0]["FK_UserID"].ToString();
				model.Year=ds.Tables[0].Rows[0]["Year"].ToString();
				if(ds.Tables[0].Rows[0]["TotalScore"].ToString()!="")
				{
					model.TotalScore=decimal.Parse(ds.Tables[0].Rows[0]["TotalScore"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TotalRewards"].ToString()!="")
				{
					model.TotalRewards=decimal.Parse(ds.Tables[0].Rows[0]["TotalRewards"].ToString());
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
			strSql.Append("select PK_TID,FK_UserID,Year,TotalScore,TotalRewards,Extra1,Extra2 ");
			strSql.Append(" FROM sr_TotalScore ");
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
			strSql.Append(" PK_TID,FK_UserID,Year,TotalScore,TotalRewards,Extra1,Extra2 ");
			strSql.Append(" FROM sr_TotalScore ");
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
			parameters[0].Value = "sr_TotalScore";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

