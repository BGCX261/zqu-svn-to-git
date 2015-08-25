using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_Publish。
	/// </summary>
	public class sr_Publish
	{
		public sr_Publish()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PL_PID", "sr_Publish"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PL_PID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Publish");
			strSql.Append(" where PL_PID=@PL_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PL_PID", SqlDbType.Int,4)};
			parameters[0].Value = PL_PID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZQUSR.Model.sr_Publish model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Publish(");
			strSql.Append("Publisher,UnitName)");
			strSql.Append(" values (");
			strSql.Append("@Publisher,@UnitName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Publisher", SqlDbType.NVarChar,20),
					new SqlParameter("@UnitName", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.Publisher;
			parameters[1].Value = model.UnitName;

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
		public void Update(ZQUSR.Model.sr_Publish model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Publish set ");
			strSql.Append("Publisher=@Publisher,");
			strSql.Append("UnitName=@UnitName");
			strSql.Append(" where PL_PID=@PL_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PL_PID", SqlDbType.Int,4),
					new SqlParameter("@Publisher", SqlDbType.NVarChar,20),
					new SqlParameter("@UnitName", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.PL_PID;
			parameters[1].Value = model.Publisher;
			parameters[2].Value = model.UnitName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PL_PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Publish ");
			strSql.Append(" where PL_PID=@PL_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PL_PID", SqlDbType.Int,4)};
			parameters[0].Value = PL_PID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Publish GetModel(int PL_PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PL_PID,Publisher,UnitName from sr_Publish ");
			strSql.Append(" where PL_PID=@PL_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PL_PID", SqlDbType.Int,4)};
			parameters[0].Value = PL_PID;

			ZQUSR.Model.sr_Publish model=new ZQUSR.Model.sr_Publish();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PL_PID"].ToString()!="")
				{
					model.PL_PID=int.Parse(ds.Tables[0].Rows[0]["PL_PID"].ToString());
				}
				model.Publisher=ds.Tables[0].Rows[0]["Publisher"].ToString();
				model.UnitName=ds.Tables[0].Rows[0]["UnitName"].ToString();
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
			strSql.Append("select PL_PID,Publisher,UnitName ");
			strSql.Append(" FROM sr_Publish ");
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
			strSql.Append(" PL_PID,Publisher,UnitName ");
			strSql.Append(" FROM sr_Publish ");
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
			parameters[0].Value = "sr_Publish";
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

