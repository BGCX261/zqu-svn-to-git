using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_LevelScores。
	/// </summary>
	public class sr_LevelScores
	{
		public sr_LevelScores()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_ID", "sr_LevelScores"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_LevelScores");
			strSql.Append(" where PK_ID=@PK_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_ID", SqlDbType.Int,4)};
			parameters[0].Value = PK_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZQUSR.Model.sr_LevelScores model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_LevelScores(");
			strSql.Append("JiBie,Score)");
			strSql.Append(" values (");
			strSql.Append("@JiBie,@Score)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@Score", SqlDbType.Int,4)};
			parameters[0].Value = model.JiBie;
			parameters[1].Value = model.Score;

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
		public void Update(ZQUSR.Model.sr_LevelScores model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_LevelScores set ");
			strSql.Append("JiBie=@JiBie,");
			strSql.Append("Score=@Score");
			strSql.Append(" where PK_ID=@PK_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_ID", SqlDbType.Int,4),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@Score", SqlDbType.Int,4)};
			parameters[0].Value = model.PK_ID;
			parameters[1].Value = model.JiBie;
			parameters[2].Value = model.Score;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_LevelScores ");
			strSql.Append(" where PK_ID=@PK_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_ID", SqlDbType.Int,4)};
			parameters[0].Value = PK_ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_LevelScores GetModel(int PK_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_ID,JiBie,Score from sr_LevelScores ");
			strSql.Append(" where PK_ID=@PK_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_ID", SqlDbType.Int,4)};
			parameters[0].Value = PK_ID;

			ZQUSR.Model.sr_LevelScores model=new ZQUSR.Model.sr_LevelScores();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_ID"].ToString()!="")
				{
					model.PK_ID=int.Parse(ds.Tables[0].Rows[0]["PK_ID"].ToString());
				}
				model.JiBie=ds.Tables[0].Rows[0]["JiBie"].ToString();
				if(ds.Tables[0].Rows[0]["Score"].ToString()!="")
				{
					model.Score=int.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
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
			strSql.Append("select PK_ID,JiBie,Score ");
			strSql.Append(" FROM sr_LevelScores ");
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
			strSql.Append(" PK_ID,JiBie,Score ");
			strSql.Append(" FROM sr_LevelScores ");
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
			parameters[0].Value = "sr_LevelScores";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法

        /// <summary>
        /// 根据级别返回对应的级别分    ——By Jianguo Fung
        /// </summary>
        /// <param name="JiBie"></param>
        /// <returns></returns>
        public int GetScoreByJiBie(string JiBie)
        {
            string strSql = "select Score from sr_LevelScores where JiBie='"+ JiBie+"'";
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 返回数据列表   ——By Jianguo Fung
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PK_ID,JiBie,Score ");
            strSql.Append(" FROM sr_LevelScores ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新级别分数
        /// </summary>
        public void UpdateScore(ZQUSR.Model.sr_LevelScores model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_LevelScores set ");
            strSql.Append(" Score=@Score ");
            strSql.Append(" where PK_ID=@PK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_ID", SqlDbType.Int,4),
					new SqlParameter("@Score", SqlDbType.Int,4)};
            parameters[0].Value = model.PK_ID;
            parameters[1].Value = model.Score;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
	}
}

