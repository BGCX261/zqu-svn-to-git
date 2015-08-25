using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace ZQUSR.DAL
{
    /// <summary>
    /// 数据访问类sr_WordsFunds。
    /// </summary>
    public class sr_WordsFunds
    {
        public sr_WordsFunds()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("PK_WFID", "sr_WordsFunds");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PK_WFID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_WordsFunds");
            strSql.Append(" where PK_WFID=@PK_WFID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_WFID", SqlDbType.Int,4)};
            parameters[0].Value = PK_WFID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZQUSR.Model.sr_WordsFunds model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sr_WordsFunds(");
            strSql.Append("Sort,Type,Digit1,Digit2,Digit3,Digit4,Digit5,Digit6,Digit7)");
            strSql.Append(" values (");
            strSql.Append("@Sort,@Type,@Digit1,@Digit2,@Digit3,@Digit4,@Digit5,@Digit6,@Digit7)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Digit1", SqlDbType.Float,8),
					new SqlParameter("@Digit2", SqlDbType.Float,8),
					new SqlParameter("@Digit3", SqlDbType.Float,8),
					new SqlParameter("@Digit4", SqlDbType.Float,8),
					new SqlParameter("@Digit5", SqlDbType.Float,8),
					new SqlParameter("@Digit6", SqlDbType.Float,8),
					new SqlParameter("@Digit7", SqlDbType.Float,8)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Digit1;
            parameters[3].Value = model.Digit2;
            parameters[4].Value = model.Digit3;
            parameters[5].Value = model.Digit4;
            parameters[6].Value = model.Digit5;
            parameters[7].Value = model.Digit6;
            parameters[8].Value = model.Digit7;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public void Update(ZQUSR.Model.sr_WordsFunds model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_WordsFunds set ");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Type=@Type,");
            strSql.Append("Digit1=@Digit1,");
            strSql.Append("Digit2=@Digit2,");
            strSql.Append("Digit3=@Digit3,");
            strSql.Append("Digit4=@Digit4,");
            strSql.Append("Digit5=@Digit5,");
            strSql.Append("Digit6=@Digit6,");
            strSql.Append("Digit7=@Digit7");
            strSql.Append(" where PK_WFID=@PK_WFID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_WFID", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Digit1", SqlDbType.Float,8),
					new SqlParameter("@Digit2", SqlDbType.Float,8),
					new SqlParameter("@Digit3", SqlDbType.Float,8),
					new SqlParameter("@Digit4", SqlDbType.Float,8),
					new SqlParameter("@Digit5", SqlDbType.Float,8),
					new SqlParameter("@Digit6", SqlDbType.Float,8),
					new SqlParameter("@Digit7", SqlDbType.Float,8)};
            parameters[0].Value = model.PK_WFID;
            parameters[1].Value = model.Sort;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.Digit1;
            parameters[4].Value = model.Digit2;
            parameters[5].Value = model.Digit3;
            parameters[6].Value = model.Digit4;
            parameters[7].Value = model.Digit5;
            parameters[8].Value = model.Digit6;
            parameters[9].Value = model.Digit7;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int PK_WFID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sr_WordsFunds ");
            strSql.Append(" where PK_WFID=@PK_WFID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_WFID", SqlDbType.Int,4)};
            parameters[0].Value = PK_WFID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZQUSR.Model.sr_WordsFunds GetModel(int PK_WFID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PK_WFID,Sort,Type,Digit1,Digit2,Digit3,Digit4,Digit5,Digit6,Digit7 from sr_WordsFunds ");
            strSql.Append(" where PK_WFID=@PK_WFID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_WFID", SqlDbType.Int,4)};
            parameters[0].Value = PK_WFID;

            ZQUSR.Model.sr_WordsFunds model = new ZQUSR.Model.sr_WordsFunds();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PK_WFID"].ToString() != "")
                {
                    model.PK_WFID = int.Parse(ds.Tables[0].Rows[0]["PK_WFID"].ToString());
                }
                model.Sort = ds.Tables[0].Rows[0]["Sort"].ToString();
                model.Type = ds.Tables[0].Rows[0]["Type"].ToString();
                if (ds.Tables[0].Rows[0]["Digit1"].ToString() != "")
                {
                    model.Digit1 = decimal.Parse(ds.Tables[0].Rows[0]["Digit1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit2"].ToString() != "")
                {
                    model.Digit2 = decimal.Parse(ds.Tables[0].Rows[0]["Digit2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit3"].ToString() != "")
                {
                    model.Digit3 = decimal.Parse(ds.Tables[0].Rows[0]["Digit3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit4"].ToString() != "")
                {
                    model.Digit4 = decimal.Parse(ds.Tables[0].Rows[0]["Digit4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit5"].ToString() != "")
                {
                    model.Digit5 = decimal.Parse(ds.Tables[0].Rows[0]["Digit5"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit6"].ToString() != "")
                {
                    model.Digit6 = decimal.Parse(ds.Tables[0].Rows[0]["Digit6"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit7"].ToString() != "")
                {
                    model.Digit7 = decimal.Parse(ds.Tables[0].Rows[0]["Digit7"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PK_WFID,Sort,Type,Digit1,Digit2,Digit3,Digit4,Digit5,Digit6,Digit7 ");
            strSql.Append(" FROM sr_WordsFunds ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" PK_WFID,Sort,Type,Digit1,Digit2,Digit3,Digit4,Digit5,Digit6,Digit7 ");
            strSql.Append(" FROM sr_WordsFunds ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "sr_WordsFunds";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        #region 学术著作：计算字数分用
        /// <summary>
        /// 学术著作：计算字数分用   ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public ZQUSR.Model.sr_WordsFunds GetModel(string Sort)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Digit1,Digit2,Digit3 from sr_WordsFunds ");
            strSql.Append(" where Sort=@Sort ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10)};
            parameters[0].Value = Sort;

            ZQUSR.Model.sr_WordsFunds model = new ZQUSR.Model.sr_WordsFunds();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Digit1"].ToString() != "")
                {
                    model.Digit1 = decimal.Parse(ds.Tables[0].Rows[0]["Digit1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit2"].ToString() != "")
                {
                    model.Digit2 = decimal.Parse(ds.Tables[0].Rows[0]["Digit2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit3"].ToString() != "")
                {
                    model.Digit3 = decimal.Parse(ds.Tables[0].Rows[0]["Digit3"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        } 
        #endregion

        #region 科研项目：计算经费分用
        /// <summary>
        ///  科研项目：计算经费分用  ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public ZQUSR.Model.sr_WordsFunds GetModel(string Sort, string Type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Digit1,Digit2,Digit3,Digit4,Digit5,Digit6,Digit7 from sr_WordsFunds ");
            strSql.Append(" where Sort=@Sort ");
            strSql.Append(" and Type=@Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Type", SqlDbType.NVarChar,10)};
            parameters[0].Value = Sort;
            parameters[1].Value = Type;

            ZQUSR.Model.sr_WordsFunds model = new ZQUSR.Model.sr_WordsFunds();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Digit1"].ToString() != "")
                {
                    model.Digit1 = decimal.Parse(ds.Tables[0].Rows[0]["Digit1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit2"].ToString() != "")
                {
                    model.Digit2 = decimal.Parse(ds.Tables[0].Rows[0]["Digit2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit3"].ToString() != "")
                {
                    model.Digit3 = decimal.Parse(ds.Tables[0].Rows[0]["Digit3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit4"].ToString() != "")
                {
                    model.Digit4 = decimal.Parse(ds.Tables[0].Rows[0]["Digit4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit5"].ToString() != "")
                {
                    model.Digit5 = decimal.Parse(ds.Tables[0].Rows[0]["Digit5"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit6"].ToString() != "")
                {
                    model.Digit6 = decimal.Parse(ds.Tables[0].Rows[0]["Digit6"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Digit7"].ToString() != "")
                {
                    model.Digit7 = decimal.Parse(ds.Tables[0].Rows[0]["Digit7"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 更新学术著作的字数分设置
        /// <summary>
        /// 更新学术著作的字数分设置 －By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateZhuZuo(ZQUSR.Model.sr_WordsFunds model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_WordsFunds set ");
            strSql.Append("Digit1=@Digit1,");
            strSql.Append("Digit2=@Digit2,");
            strSql.Append("Digit3=@Digit3 ");
            strSql.Append(" where Sort=@Sort ");
            SqlParameter[] parameters = {
					new SqlParameter("@Digit1", SqlDbType.Float,8),
					new SqlParameter("@Digit2", SqlDbType.Float,8),
					new SqlParameter("@Digit3", SqlDbType.Float,8),
					new SqlParameter("@Sort", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.Digit1;
            parameters[1].Value = model.Digit2;
            parameters[2].Value = model.Digit3;
            parameters[3].Value = model.Sort;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        } 
        #endregion

        #region 更新科研项目的经费分设置
        /// <summary>
        /// 更新科研项目的经费分设置 －By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateKeYan(ZQUSR.Model.sr_WordsFunds model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_WordsFunds set ");
            strSql.Append("Digit1=@Digit1,");
            strSql.Append("Digit2=@Digit2,");
            strSql.Append("Digit3=@Digit3,");
            strSql.Append("Digit4=@Digit4,");
            strSql.Append("Digit5=@Digit5,");
            strSql.Append("Digit6=@Digit6,");
            strSql.Append("Digit7=@Digit7 ");
            strSql.Append(" where Sort=@Sort ");
            strSql.Append(" and Type=@Type");
            SqlParameter[] parameters = {
					new SqlParameter("@Digit1", SqlDbType.Float,8),
					new SqlParameter("@Digit2", SqlDbType.Float,8),
					new SqlParameter("@Digit3", SqlDbType.Float,8),
					new SqlParameter("@Digit4", SqlDbType.Float,8),
					new SqlParameter("@Digit5", SqlDbType.Float,8),
					new SqlParameter("@Digit6", SqlDbType.Float,8),
					new SqlParameter("@Digit7", SqlDbType.Float,8),
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.Digit1;
            parameters[1].Value = model.Digit2;
            parameters[2].Value = model.Digit3;
            parameters[3].Value = model.Digit4;
            parameters[4].Value = model.Digit5;
            parameters[5].Value = model.Digit6;
            parameters[6].Value = model.Digit7;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.Type;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        } 
        #endregion
	}
}

