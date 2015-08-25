using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_Periods。
	/// </summary>
	public class sr_Periods
	{
		public sr_Periods()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_PID", "sr_Periods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_PID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Periods");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4)};
			parameters[0].Value = PK_PID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZQUSR.Model.sr_Periods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Periods(");
			strSql.Append("PeriName,StartTime,EndTime,Extra1,Extra2)");
			strSql.Append(" values (");
			strSql.Append("@PeriName,@StartTime,@EndTime,@Extra1,@Extra2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PeriName", SqlDbType.NVarChar,20),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.PeriName;
			parameters[1].Value = model.StartTime;
			parameters[2].Value = model.EndTime;
			parameters[3].Value = model.Extra1;
			parameters[4].Value = model.Extra2;

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
		public void Update(ZQUSR.Model.sr_Periods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Periods set ");
			strSql.Append("PeriName=@PeriName,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("Extra1=@Extra1,");
			strSql.Append("Extra2=@Extra2");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4),
					new SqlParameter("@PeriName", SqlDbType.NVarChar,20),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.PK_PID;
			parameters[1].Value = model.PeriName;
			parameters[2].Value = model.StartTime;
			parameters[3].Value = model.EndTime;
			parameters[4].Value = model.Extra1;
			parameters[5].Value = model.Extra2;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Periods ");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4)};
			parameters[0].Value = PK_PID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Periods GetModel(int PK_PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_PID,PeriName,StartTime,EndTime,Extra1,Extra2 from sr_Periods ");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4)};
			parameters[0].Value = PK_PID;

			ZQUSR.Model.sr_Periods model=new ZQUSR.Model.sr_Periods();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_PID"].ToString()!="")
				{
					model.PK_PID=int.Parse(ds.Tables[0].Rows[0]["PK_PID"].ToString());
				}
				model.PeriName=ds.Tables[0].Rows[0]["PeriName"].ToString();
				if(ds.Tables[0].Rows[0]["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
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
			strSql.Append("select PK_PID,PeriName,StartTime,EndTime,Extra1,Extra2 ");
			strSql.Append(" FROM sr_Periods ");
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
			strSql.Append(" PK_PID,PeriName,StartTime,EndTime,Extra1,Extra2 ");
			strSql.Append(" FROM sr_Periods ");
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
			parameters[0].Value = "sr_Periods";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法

        #region 返回数据列表
        /// <summary>
        /// 返回数据列表  －By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PK_PID,PeriName,StartTime,EndTime,Extra1,Extra2 ");
            strSql.Append(" FROM sr_Periods ");
            return DbHelperSQL.Query(strSql.ToString());
        } 
        #endregion

        #region 时间设置
        /// <summary>
        /// 时间设置   －By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateTime(ZQUSR.Model.sr_Periods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_Periods set ");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime ");
            strSql.Append(" where PK_PID=@PK_PID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),};
            parameters[0].Value = model.PK_PID;
            parameters[1].Value = model.StartTime;
            parameters[2].Value = model.EndTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        } 
        #endregion
	}
}

