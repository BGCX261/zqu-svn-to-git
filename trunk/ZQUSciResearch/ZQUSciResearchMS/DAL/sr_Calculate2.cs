using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_Calculate2。
	/// </summary>
	public class sr_Calculate2
	{
		public sr_Calculate2()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_CID", "sr_Calculate2"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_CID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Calculate2");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4)};
			parameters[0].Value = PK_CID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZQUSR.Model.sr_Calculate2 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Calculate2(");
			strSql.Append("Population,Rank,ScoreScale)");
			strSql.Append(" values (");
			strSql.Append("@Population,@Rank,@ScoreScale)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Population", SqlDbType.Int,4),
					new SqlParameter("@Rank", SqlDbType.Int,4),
					new SqlParameter("@ScoreScale", SqlDbType.NVarChar,5)};
			parameters[0].Value = model.Population;
			parameters[1].Value = model.Rank;
			parameters[2].Value = model.ScoreScale;

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
		public void Update(ZQUSR.Model.sr_Calculate2 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Calculate2 set ");
			strSql.Append("Population=@Population,");
			strSql.Append("Rank=@Rank,");
			strSql.Append("ScoreScale=@ScoreScale");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4),
					new SqlParameter("@Population", SqlDbType.Int,4),
					new SqlParameter("@Rank", SqlDbType.Int,4),
					new SqlParameter("@ScoreScale", SqlDbType.NVarChar,5)};
			parameters[0].Value = model.PK_CID;
			parameters[1].Value = model.Population;
			parameters[2].Value = model.Rank;
			parameters[3].Value = model.ScoreScale;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Calculate2 ");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4)};
			parameters[0].Value = PK_CID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Calculate2 GetModel(int PK_CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_CID,Population,Rank,ScoreScale from sr_Calculate2 ");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4)};
			parameters[0].Value = PK_CID;

			ZQUSR.Model.sr_Calculate2 model=new ZQUSR.Model.sr_Calculate2();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_CID"].ToString()!="")
				{
					model.PK_CID=int.Parse(ds.Tables[0].Rows[0]["PK_CID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Population"].ToString()!="")
				{
					model.Population=int.Parse(ds.Tables[0].Rows[0]["Population"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rank"].ToString()!="")
				{
					model.Rank=int.Parse(ds.Tables[0].Rows[0]["Rank"].ToString());
				}
				model.ScoreScale=ds.Tables[0].Rows[0]["ScoreScale"].ToString();
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
			strSql.Append("select PK_CID,Population,Rank,ScoreScale ");
			strSql.Append(" FROM sr_Calculate2 ");
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
			strSql.Append(" PK_CID,Population,Rank,ScoreScale ");
			strSql.Append(" FROM sr_Calculate2 ");
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
			parameters[0].Value = "sr_Calculate2";
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
        /// 多人合作计算分数，根据完成人数和排名次序返回对的得分比例    ——By Jianguo Fung
        /// </summary>
        /// <param name="Cal2Model"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Calculate2 GetScoreScale(int population, int rank)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ScoreScale from sr_Calculate2 ");
            strSql.Append(" where Population=@Population and Rank=@Rank ");
            SqlParameter[] parameters = {
					new SqlParameter("@Population", SqlDbType.Int,4),
                    new SqlParameter("@Rank", SqlDbType.Int,4)};
            parameters[0].Value = population;
            parameters[1].Value = rank;

            ZQUSR.Model.sr_Calculate2 model = new ZQUSR.Model.sr_Calculate2();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ScoreScale = ds.Tables[0].Rows[0]["ScoreScale"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 返回数据列表   ——By Jianguo Fung
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PK_CID,Population,Rank,ScoreScale ");
            strSql.Append(" FROM sr_Calculate2 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新比例 －By Jianguo Fung
        /// </summary>
        public void UpdateScoreScale(ZQUSR.Model.sr_Calculate2 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_Calculate2 set ");
            strSql.Append(" ScoreScale=@ScoreScale ");
            strSql.Append(" where PK_CID=@PK_CID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4),
					new SqlParameter("@ScoreScale", SqlDbType.NVarChar,5)};
            parameters[0].Value = model.PK_CID;
            parameters[1].Value = model.ScoreScale;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
	}
}

