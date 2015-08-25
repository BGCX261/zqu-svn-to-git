using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ZQUSR.DAL
{
    /// <summary>
    /// 数据访问类:sr_ZhiCheng
    /// </summary>
    public partial class sr_ZhiCheng
    {
        public sr_ZhiCheng()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_ZhiCheng");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
};

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ZQUSR.Model.sr_ZhiCheng model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sr_ZhiCheng(");
            strSql.Append("Grade,ZhiChengName)");
            strSql.Append(" values (");
            strSql.Append("@Grade,@ZhiChengName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Grade", SqlDbType.NVarChar,10),
					new SqlParameter("@ZhiChengName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Grade;
            parameters[1].Value = model.ZhiChengName;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ZQUSR.Model.sr_ZhiCheng model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_ZhiCheng set ");
            strSql.Append("Grade=@Grade,");
            strSql.Append("ZhiChengName=@ZhiChengName");
            strSql.Append(" where PK_ZCID=@PK_ZCID");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_ZCID", SqlDbType.Int,4),
					new SqlParameter("@Grade", SqlDbType.NVarChar,10),
					new SqlParameter("@ZhiChengName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.PK_ZCID;
            parameters[1].Value = model.Grade;
            parameters[2].Value = model.ZhiChengName;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PK_ZCID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sr_ZhiCheng ");
            strSql.Append(" where PK_ZCID=@PK_ZCID");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_ZCID", SqlDbType.Int,4)
};
            parameters[0].Value = PK_ZCID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PK_ZCIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sr_ZhiCheng ");
            strSql.Append(" where PK_ZCID in (" + PK_ZCIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZQUSR.Model.sr_ZhiCheng GetModel(int PK_ZCID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PK_ZCID,Grade,ZhiChengName from sr_ZhiCheng ");
            strSql.Append(" where PK_ZCID=@PK_ZCID");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_ZCID", SqlDbType.Int,4)
};
            parameters[0].Value = PK_ZCID;

            ZQUSR.Model.sr_ZhiCheng model = new ZQUSR.Model.sr_ZhiCheng();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PK_ZCID"].ToString() != "")
                {
                    model.PK_ZCID = int.Parse(ds.Tables[0].Rows[0]["PK_ZCID"].ToString());
                }
                model.Grade = ds.Tables[0].Rows[0]["Grade"].ToString();
                model.ZhiChengName = ds.Tables[0].Rows[0]["ZhiChengName"].ToString();
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
            strSql.Append("select PK_ZCID,Grade,ZhiChengName ");
            strSql.Append(" FROM sr_ZhiCheng ");
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
            strSql.Append(" PK_ZCID,Grade,ZhiChengName ");
            strSql.Append(" FROM sr_ZhiCheng ");
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
            parameters[0].Value = "sr_ZhiCheng";
            parameters[1].Value = "PK_ZCID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}


