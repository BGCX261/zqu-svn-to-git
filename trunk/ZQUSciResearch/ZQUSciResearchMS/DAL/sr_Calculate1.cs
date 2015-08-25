using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_Calculate1。
	/// </summary>
	public class sr_Calculate1
	{
		public sr_Calculate1()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_CID", "sr_Calculate1"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_CID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Calculate1");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4)};
			parameters[0].Value = PK_CID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZQUSR.Model.sr_Calculate1 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Calculate1(");
			strSql.Append("Sort,JiBie,SchoolSign,Scale)");
			strSql.Append(" values (");
			strSql.Append("@Sort,@JiBie,@SchoolSign,@Scale)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@SchoolSign", SqlDbType.NVarChar,10),
					new SqlParameter("@Scale", SqlDbType.Float,8)};
			parameters[0].Value = model.Sort;
			parameters[1].Value = model.JiBie;
			parameters[2].Value = model.SchoolSign;
			parameters[3].Value = model.Scale;

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
		public void Update(ZQUSR.Model.sr_Calculate1 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Calculate1 set ");
			strSql.Append("Sort=@Sort,");
			strSql.Append("JiBie=@JiBie,");
			strSql.Append("SchoolSign=@SchoolSign,");
			strSql.Append("Scale=@Scale");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@SchoolSign", SqlDbType.NVarChar,10),
					new SqlParameter("@Scale", SqlDbType.Float,8)};
			parameters[0].Value = model.PK_CID;
			parameters[1].Value = model.Sort;
			parameters[2].Value = model.JiBie;
			parameters[3].Value = model.SchoolSign;
			parameters[4].Value = model.Scale;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Calculate1 ");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4)};
			parameters[0].Value = PK_CID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Calculate1 GetModel(int PK_CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_CID,Sort,JiBie,SchoolSign,Scale from sr_Calculate1 ");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4)};
			parameters[0].Value = PK_CID;

			ZQUSR.Model.sr_Calculate1 model=new ZQUSR.Model.sr_Calculate1();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_CID"].ToString()!="")
				{
					model.PK_CID=int.Parse(ds.Tables[0].Rows[0]["PK_CID"].ToString());
				}
				model.Sort=ds.Tables[0].Rows[0]["Sort"].ToString();
				model.JiBie=ds.Tables[0].Rows[0]["JiBie"].ToString();
				model.SchoolSign=ds.Tables[0].Rows[0]["SchoolSign"].ToString();
				if(ds.Tables[0].Rows[0]["Scale"].ToString()!="")
				{
					model.Scale=decimal.Parse(ds.Tables[0].Rows[0]["Scale"].ToString());
				}
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
			strSql.Append("select PK_CID,Sort,JiBie,SchoolSign,Scale ");
			strSql.Append(" FROM sr_Calculate1 ");
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
			strSql.Append(" PK_CID,Sort,JiBie,SchoolSign,Scale ");
			strSql.Append(" FROM sr_Calculate1 ");
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
			parameters[0].Value = "sr_Calculate1";
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

