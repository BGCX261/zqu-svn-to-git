using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_UserRole。
	/// </summary>
	public class sr_UserRole
	{
		public sr_UserRole()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_ID", "sr_UserRole"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_UserRole");
			strSql.Append(" where PK_ID=@PK_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_ID", SqlDbType.Int,4)};
			parameters[0].Value = PK_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZQUSR.Model.sr_UserRole model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_UserRole(");
			strSql.Append("FK_RoleID,FK_UserID)");
			strSql.Append(" values (");
			strSql.Append("@FK_RoleID,@FK_UserID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FK_RoleID", SqlDbType.NVarChar,10),
					new SqlParameter("@FK_UserID", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.FK_RoleID;
			parameters[1].Value = model.FK_UserID;

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
		public void Update(ZQUSR.Model.sr_UserRole model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_UserRole set ");
			strSql.Append("FK_RoleID=@FK_RoleID,");
			strSql.Append("FK_UserID=@FK_UserID");
			strSql.Append(" where PK_ID=@PK_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_ID", SqlDbType.Int,4),
					new SqlParameter("@FK_RoleID", SqlDbType.NVarChar,10),
					new SqlParameter("@FK_UserID", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.PK_ID;
			parameters[1].Value = model.FK_RoleID;
			parameters[2].Value = model.FK_UserID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_UserRole ");
			strSql.Append(" where PK_ID=@PK_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_ID", SqlDbType.Int,4)};
			parameters[0].Value = PK_ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_UserRole GetModel(int PK_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_ID,FK_RoleID,FK_UserID from sr_UserRole ");
			strSql.Append(" where PK_ID=@PK_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_ID", SqlDbType.Int,4)};
			parameters[0].Value = PK_ID;

			ZQUSR.Model.sr_UserRole model=new ZQUSR.Model.sr_UserRole();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_ID"].ToString()!="")
				{
					model.PK_ID=int.Parse(ds.Tables[0].Rows[0]["PK_ID"].ToString());
				}
				model.FK_RoleID=ds.Tables[0].Rows[0]["FK_RoleID"].ToString();
				model.FK_UserID=ds.Tables[0].Rows[0]["FK_UserID"].ToString();
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
			strSql.Append("select PK_ID,FK_RoleID,FK_UserID ");
			strSql.Append(" FROM sr_UserRole ");
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
			strSql.Append(" PK_ID,FK_RoleID,FK_UserID ");
			strSql.Append(" FROM sr_UserRole ");
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
			parameters[0].Value = "sr_UserRole";
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

