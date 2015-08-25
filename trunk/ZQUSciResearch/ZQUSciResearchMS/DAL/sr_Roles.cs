using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_Roles。
	/// </summary>
	public class sr_Roles
	{
		public sr_Roles()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PK_RoleID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Roles");
			strSql.Append(" where PK_RoleID=@PK_RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_RoleID", SqlDbType.NVarChar,50)};
			parameters[0].Value = PK_RoleID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ZQUSR.Model.sr_Roles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Roles(");
			strSql.Append("PK_RoleID,RoleName,RoleIntro)");
			strSql.Append(" values (");
			strSql.Append("@PK_RoleID,@RoleName,@RoleIntro)");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_RoleID", SqlDbType.NVarChar,10),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,10),
					new SqlParameter("@RoleIntro", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.PK_RoleID;
			parameters[1].Value = model.RoleName;
			parameters[2].Value = model.RoleIntro;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_Roles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Roles set ");
			strSql.Append("RoleName=@RoleName,");
			strSql.Append("RoleIntro=@RoleIntro");
			strSql.Append(" where PK_RoleID=@PK_RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_RoleID", SqlDbType.NVarChar,10),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,10),
					new SqlParameter("@RoleIntro", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.PK_RoleID;
			parameters[1].Value = model.RoleName;
			parameters[2].Value = model.RoleIntro;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string PK_RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Roles ");
			strSql.Append(" where PK_RoleID=@PK_RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_RoleID", SqlDbType.NVarChar,50)};
			parameters[0].Value = PK_RoleID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Roles GetModel(string PK_RoleID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_RoleID,RoleName,RoleIntro from sr_Roles ");
			strSql.Append(" where PK_RoleID=@PK_RoleID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_RoleID", SqlDbType.NVarChar,50)};
			parameters[0].Value = PK_RoleID;

			ZQUSR.Model.sr_Roles model=new ZQUSR.Model.sr_Roles();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.PK_RoleID=ds.Tables[0].Rows[0]["PK_RoleID"].ToString();
				model.RoleName=ds.Tables[0].Rows[0]["RoleName"].ToString();
				model.RoleIntro=ds.Tables[0].Rows[0]["RoleIntro"].ToString();
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
			strSql.Append("select PK_RoleID,RoleName,RoleIntro ");
			strSql.Append(" FROM sr_Roles ");
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
			strSql.Append(" PK_RoleID,RoleName,RoleIntro ");
			strSql.Append(" FROM sr_Roles ");
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
			parameters[0].Value = "sr_Roles";
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

