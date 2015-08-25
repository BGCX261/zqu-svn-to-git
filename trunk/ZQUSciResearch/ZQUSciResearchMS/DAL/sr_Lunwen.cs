using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
	/// <summary>
	/// 数据访问类sr_Lunwen。
	/// </summary>
	public class sr_Lunwen
	{
		public sr_Lunwen()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_LID", "sr_Lunwen"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_LID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Lunwen");
			strSql.Append(" where PK_LID=@PK_LID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_LID", SqlDbType.Int,4)};
			parameters[0].Value = PK_LID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ZQUSR.Model.sr_Lunwen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Lunwen(");
			strSql.Append("Type,Situation,Factor1,Factor2,JiBie,LevelFactor,Extra1,Extra2)");
			strSql.Append(" values (");
			strSql.Append("@Type,@Situation,@Factor1,@Factor2,@JiBie,@LevelFactor,@Extra1,@Extra2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Situation", SqlDbType.NVarChar,100),
					new SqlParameter("@Factor1", SqlDbType.Float,8),
					new SqlParameter("@Factor2", SqlDbType.Float,8),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Situation;
			parameters[2].Value = model.Factor1;
			parameters[3].Value = model.Factor2;
			parameters[4].Value = model.JiBie;
			parameters[5].Value = model.LevelFactor;
			parameters[6].Value = model.Extra1;
			parameters[7].Value = model.Extra2;

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
		/// 更新一条数据   modify by caiyuying  2011-01-20
		/// </summary>
		public void Update(ZQUSR.Model.sr_Lunwen model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Lunwen set ");
			//strSql.Append("Type=@Type,");
			strSql.Append("Situation=@Situation,");
			strSql.Append("Factor1=@Factor1,");
			strSql.Append("Factor2=@Factor2,");
			strSql.Append("JiBie=@JiBie,");
			strSql.Append("LevelFactor=@LevelFactor,");
			strSql.Append("Extra1=@Extra1,");
			strSql.Append("Extra2=@Extra2");
			strSql.Append(" where PK_LID=@PK_LID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_LID", SqlDbType.Int,4),
					//new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Situation", SqlDbType.NVarChar,100),
					new SqlParameter("@Factor1", SqlDbType.Float,8),
					new SqlParameter("@Factor2", SqlDbType.Float,8),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.PK_LID;
			//parameters[1].Value = model.Type;
			parameters[1].Value = model.Situation;
			parameters[2].Value = model.Factor1;
			parameters[3].Value = model.Factor2;
			parameters[4].Value = model.JiBie;
			parameters[5].Value = model.LevelFactor;
			parameters[6].Value = model.Extra1;
			parameters[7].Value = model.Extra2;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_LID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Lunwen ");
			strSql.Append(" where PK_LID=@PK_LID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_LID", SqlDbType.Int,4)};
			parameters[0].Value = PK_LID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Lunwen GetModel(int PK_LID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_LID,Type,Situation,Factor1,Factor2,JiBie,LevelFactor,Extra1,Extra2 from sr_Lunwen ");
			strSql.Append(" where PK_LID=@PK_LID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_LID", SqlDbType.Int,4)};
			parameters[0].Value = PK_LID;

			ZQUSR.Model.sr_Lunwen model=new ZQUSR.Model.sr_Lunwen();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_LID"].ToString()!="")
				{
					model.PK_LID=int.Parse(ds.Tables[0].Rows[0]["PK_LID"].ToString());
				}
				model.Type=ds.Tables[0].Rows[0]["Type"].ToString();
				model.Situation=ds.Tables[0].Rows[0]["Situation"].ToString();
				if(ds.Tables[0].Rows[0]["Factor1"].ToString()!="")
				{
					model.Factor1=decimal.Parse(ds.Tables[0].Rows[0]["Factor1"].ToString());
                    //model.Factor1 = ds.Tables[0].Rows[0]["Factor1"].ToString();    //---by caiyuying
				}
				if(ds.Tables[0].Rows[0]["Factor2"].ToString()!="")
				{
					model.Factor2=decimal.Parse(ds.Tables[0].Rows[0]["Factor2"].ToString());
                    //model.Factor2 = ds.Tables[0].Rows[0]["Factor2"].ToString();     //---by caiyuying
				}
				model.JiBie=ds.Tables[0].Rows[0]["JiBie"].ToString();
				if(ds.Tables[0].Rows[0]["LevelFactor"].ToString()!="")
				{
					model.LevelFactor=decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                    //model.LevelFactor = ds.Tables[0].Rows[0]["LevelFactor"].ToString();    //---by caiyuying
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
			strSql.Append("select PK_LID,Type,Situation,Factor1,Factor2,JiBie,LevelFactor,Extra1,Extra2 ");
			strSql.Append(" FROM sr_Lunwen ");
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
			strSql.Append(" PK_LID,Type,Situation,Factor1,Factor2,JiBie,LevelFactor,Extra1,Extra2 ");
			strSql.Append(" FROM sr_Lunwen ");
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
			parameters[0].Value = "sr_Lunwen";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法

        #region 获得收录/转载情况，绑定到下拉框中
        /// <summary>
        /// 获得收录/转载情况，绑定到下拉框中  ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetSituation()
        {
            string strSql = "select distinct Situation from sr_Lunwen";
            return DbHelperSQL.Query(strSql.ToString());
        } 
        #endregion

        #region 根据影响因子(QIF)返回级别(JiBie)和级别分系数(LevelFactor)
        /// <summary>
        /// 根据影响因子(QIF)返回级别(JiBie)和级别分系数(LevelFactor)   －By Jianguo Fung
        /// </summary>
        public ZQUSR.Model.sr_Lunwen GetJiBieByQIF(decimal QIF)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Lunwen ");
            strSql.Append(" where @QIF>Factor1-0.0001 and @QIF<Factor2 ");
            SqlParameter[] parameters = {
					new SqlParameter("@QIF", SqlDbType.Decimal,8)};
            parameters[0].Value = QIF;

            ZQUSR.Model.sr_Lunwen model = new ZQUSR.Model.sr_Lunwen();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.JiBie = ds.Tables[0].Rows[0]["JiBie"].ToString();
                if (ds.Tables[0].Rows[0]["LevelFactor"].ToString() != "")
                {
                    model.LevelFactor = decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        } 
        #endregion

        #region 根据收录转载情况(Sitution)返回级别(JiBie)和级别分系数(LevelFactor)
        /// <summary>
        /// 根据收录转载情况(Sitution)返回级别(JiBie)和级别分系数(LevelFactor)   －By Jianguo Fung
        /// </summary>
        public ZQUSR.Model.sr_Lunwen GetJiBieBySitution(string Situation)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Lunwen ");
            strSql.Append(" where Situation=@Situation");
            SqlParameter[] parameters = {
					new SqlParameter("@Situation", SqlDbType.NVarChar,100)};
            parameters[0].Value = Situation;

            ZQUSR.Model.sr_Lunwen model = new ZQUSR.Model.sr_Lunwen();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.JiBie = ds.Tables[0].Rows[0]["JiBie"].ToString();
                if (ds.Tables[0].Rows[0]["LevelFactor"].ToString() != "")
                {
                    model.LevelFactor = decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        } 
        #endregion

        #region 返回数据列表
        /// <summary>
        /// 返回数据列表  －By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            string strSql = "select * from sr_Lunwen";
            return DbHelperSQL.Query(strSql.ToString());
        } 
        #endregion

        #region 更新级别和级别分系数
        /// <summary>
        /// 更新级别和级别分系数 －By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateJiBie(ZQUSR.Model.sr_Lunwen model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_Lunwen set ");
            strSql.Append("JiBie=@JiBie,");
            strSql.Append("LevelFactor=@LevelFactor ");
            strSql.Append(" where PK_LID=@PK_LID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_LID", SqlDbType.Int,4),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8)};
            parameters[0].Value = model.PK_LID;
            parameters[1].Value = model.JiBie;
            parameters[2].Value = model.LevelFactor;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        } 
        #endregion

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录（Type/Situation）－By Jianguo Fung
        /// </summary>
        public bool Exists(ZQUSR.Model.sr_Lunwen model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Lunwen");
            strSql.Append(" where Type=@Type and ");
            strSql.Append("  Situation=@Situation ");
            SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.Char,10),
                    new SqlParameter("@Situation", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Type;
            parameters[1].Value = model.Situation;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion
	}
}

