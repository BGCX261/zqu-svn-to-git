using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_HelpNotice。
	/// </summary>
	public class sr_HelpNotice
	{
		public sr_HelpNotice()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_HNID", "sr_HelpNotice"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_HNID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_HelpNotice");
			strSql.Append(" where PK_HNID=@PK_HNID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_HNID", SqlDbType.Int,4)};
			parameters[0].Value = PK_HNID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZQUSR.Model.sr_HelpNotice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_HelpNotice(");
			strSql.Append("Title,FK_UserID,AddTime,NotContent,Type,Extra1,Extra2,Extra3)");
			strSql.Append(" values (");
			strSql.Append("@Title,@FK_UserID,@AddTime,@NotContent,@Type,@Extra1,@Extra2,@Extra3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@FK_UserID", SqlDbType.NVarChar,10),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@NotContent", SqlDbType.NVarChar,500),
					new SqlParameter("@Type", SqlDbType.TinyInt,1),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra3", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.FK_UserID;
			parameters[2].Value = model.AddTime;
			parameters[3].Value = model.NotContent;
			parameters[4].Value = model.Type;
			parameters[5].Value = model.Extra1;
			parameters[6].Value = model.Extra2;
			parameters[7].Value = model.Extra3;

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
		public void Update(ZQUSR.Model.sr_HelpNotice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_HelpNotice set ");
			strSql.Append("Title=@Title,");
			strSql.Append("FK_UserID=@FK_UserID,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("NotContent=@NotContent,");
			strSql.Append("Type=@Type,");
			strSql.Append("Extra1=@Extra1,");
			strSql.Append("Extra2=@Extra2,");
			strSql.Append("Extra3=@Extra3");
			strSql.Append(" where PK_HNID=@PK_HNID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_HNID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@FK_UserID", SqlDbType.NVarChar,10),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@NotContent", SqlDbType.NVarChar,500),
					new SqlParameter("@Type", SqlDbType.TinyInt,1),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra3", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.PK_HNID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.FK_UserID;
			parameters[3].Value = model.AddTime;
			parameters[4].Value = model.NotContent;
			parameters[5].Value = model.Type;
			parameters[6].Value = model.Extra1;
			parameters[7].Value = model.Extra2;
			parameters[8].Value = model.Extra3;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_HNID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_HelpNotice ");
			strSql.Append(" where PK_HNID=@PK_HNID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_HNID", SqlDbType.Int,4)};
			parameters[0].Value = PK_HNID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_HelpNotice GetModel(int PK_HNID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_HNID,Title,FK_UserID,AddTime,NotContent,Type,Extra1,Extra2,Extra3 from sr_HelpNotice ");
			strSql.Append(" where PK_HNID=@PK_HNID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_HNID", SqlDbType.Int,4)};
			parameters[0].Value = PK_HNID;

			ZQUSR.Model.sr_HelpNotice model=new ZQUSR.Model.sr_HelpNotice();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_HNID"].ToString()!="")
				{
					model.PK_HNID=int.Parse(ds.Tables[0].Rows[0]["PK_HNID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.FK_UserID=ds.Tables[0].Rows[0]["FK_UserID"].ToString();
				if(ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
				}
				model.NotContent=ds.Tables[0].Rows[0]["NotContent"].ToString();
				if(ds.Tables[0].Rows[0]["Type"].ToString()!="")
				{
					model.Type=int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
				}
				model.Extra1=ds.Tables[0].Rows[0]["Extra1"].ToString();
				model.Extra2=ds.Tables[0].Rows[0]["Extra2"].ToString();
				model.Extra3=ds.Tables[0].Rows[0]["Extra3"].ToString();
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
			strSql.Append("select PK_HNID,Title,FK_UserID,AddTime,NotContent,Type,Extra1,Extra2,Extra3 ");
			strSql.Append(" FROM sr_HelpNotice ");
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
			strSql.Append(" PK_HNID,Title,FK_UserID,AddTime,NotContent,Type,Extra1,Extra2,Extra3 ");
			strSql.Append(" FROM sr_HelpNotice ");
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
			parameters[0].Value = "sr_HelpNotice";
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

