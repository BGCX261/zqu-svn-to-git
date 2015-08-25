using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_Message。
	/// </summary>
	public class sr_Message
	{
		public sr_Message()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_MID", "sr_Message"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_MID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Message");
			strSql.Append(" where PK_MID=@PK_MID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_MID", SqlDbType.Int,4)};
			parameters[0].Value = PK_MID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZQUSR.Model.sr_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Message(");
			strSql.Append("Title,MessContent,FK_RecieverID,FK_SenderID,SendTime,IsRead)");
			strSql.Append(" values (");
			strSql.Append("@Title,@MessContent,@FK_RecieverID,@FK_SenderID,@SendTime,@IsRead)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@MessContent", SqlDbType.NVarChar,500),
					new SqlParameter("@FK_RecieverID", SqlDbType.NVarChar,10),
					new SqlParameter("@FK_SenderID", SqlDbType.NVarChar,10),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.MessContent;
			parameters[2].Value = model.FK_RecieverID;
			parameters[3].Value = model.FK_SenderID;
			parameters[4].Value = model.SendTime;
			parameters[5].Value = model.IsRead;

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
		public void Update(ZQUSR.Model.sr_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Message set ");
			strSql.Append("Title=@Title,");
			strSql.Append("MessContent=@MessContent,");
			strSql.Append("FK_RecieverID=@FK_RecieverID,");
			strSql.Append("FK_SenderID=@FK_SenderID,");
			strSql.Append("SendTime=@SendTime,");
			strSql.Append("IsRead=@IsRead");
			strSql.Append(" where PK_MID=@PK_MID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_MID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@MessContent", SqlDbType.NVarChar,500),
					new SqlParameter("@FK_RecieverID", SqlDbType.NVarChar,10),
					new SqlParameter("@FK_SenderID", SqlDbType.NVarChar,10),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.PK_MID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.MessContent;
			parameters[3].Value = model.FK_RecieverID;
			parameters[4].Value = model.FK_SenderID;
			parameters[5].Value = model.SendTime;
			parameters[6].Value = model.IsRead;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_MID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Message ");
			strSql.Append(" where PK_MID=@PK_MID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_MID", SqlDbType.Int,4)};
			parameters[0].Value = PK_MID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Message GetModel(int PK_MID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_MID,Title,MessContent,FK_RecieverID,FK_SenderID,SendTime,IsRead from sr_Message ");
			strSql.Append(" where PK_MID=@PK_MID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_MID", SqlDbType.Int,4)};
			parameters[0].Value = PK_MID;

			ZQUSR.Model.sr_Message model=new ZQUSR.Model.sr_Message();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_MID"].ToString()!="")
				{
					model.PK_MID=int.Parse(ds.Tables[0].Rows[0]["PK_MID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.MessContent=ds.Tables[0].Rows[0]["MessContent"].ToString();
				model.FK_RecieverID=ds.Tables[0].Rows[0]["FK_RecieverID"].ToString();
				model.FK_SenderID=ds.Tables[0].Rows[0]["FK_SenderID"].ToString();
				if(ds.Tables[0].Rows[0]["SendTime"].ToString()!="")
				{
					model.SendTime=DateTime.Parse(ds.Tables[0].Rows[0]["SendTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
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
			strSql.Append("select PK_MID,Title,MessContent,FK_RecieverID,FK_SenderID,SendTime,IsRead ");
            strSql.Append(" FROM sr_Message");
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
			strSql.Append(" PK_MID,Title,MessContent,FK_RecieverID,FK_SenderID,SendTime,IsRead ");
			strSql.Append(" FROM sr_Message ");
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
			parameters[0].Value = "sr_Message";
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

