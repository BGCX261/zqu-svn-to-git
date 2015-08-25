using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZQUSR.DAL
{
	/// <summary>
	/// ���ݷ�����sr_Calculate3��
	/// </summary>
	public class sr_Calculate3
	{
		public sr_Calculate3()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_CID", "sr_Calculate3"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int PK_CID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Calculate3");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4)};
			parameters[0].Value = PK_CID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(ZQUSR.Model.sr_Calculate3 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Calculate3(");
			strSql.Append("Type,Scale)");
			strSql.Append(" values (");
			strSql.Append("@Type,@Scale)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Scale", SqlDbType.Float,8)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Scale;

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
		/// ����һ������
		/// </summary>
		public void Update(ZQUSR.Model.sr_Calculate3 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Calculate3 set ");
			strSql.Append("Type=@Type,");
			strSql.Append("Scale=@Scale");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Scale", SqlDbType.Float,8)};
			parameters[0].Value = model.PK_CID;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Scale;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PK_CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Calculate3 ");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4)};
			parameters[0].Value = PK_CID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZQUSR.Model.sr_Calculate3 GetModel(int PK_CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_CID,Type,Scale from sr_Calculate3 ");
			strSql.Append(" where PK_CID=@PK_CID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4)};
			parameters[0].Value = PK_CID;

			ZQUSR.Model.sr_Calculate3 model=new ZQUSR.Model.sr_Calculate3();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_CID"].ToString()!="")
				{
					model.PK_CID=int.Parse(ds.Tables[0].Rows[0]["PK_CID"].ToString());
				}
				model.Type=ds.Tables[0].Rows[0]["Type"].ToString();
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PK_CID,Type,Scale ");
			strSql.Append(" FROM sr_Calculate3 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" PK_CID,Type,Scale ");
			strSql.Append(" FROM sr_Calculate3 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        
		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "sr_Calculate3";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����

        /// <summary>
        /// ���������б� ��By Jianguo Fung
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PK_CID,Type,Scale ");
            strSql.Append(" FROM sr_Calculate3 ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ����һ������ ��By Jianguo Fung
        /// </summary>
        public void UpdateScale(ZQUSR.Model.sr_Calculate3 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_Calculate3 set ");
            strSql.Append(" Scale=@Scale ");
            strSql.Append(" where PK_CID=@PK_CID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_CID", SqlDbType.Int,4),
					new SqlParameter("@Scale", SqlDbType.Float,8)};
            parameters[0].Value = model.PK_CID;
            parameters[1].Value = model.Scale;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// �ӱ�sr_Calculate3�õ���Ŀ�����˵ı���   --by caiyuying 2011-01-21
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public decimal GetProjectScale(string Type)
        {
            string strSql = "select Scale from sr_Calculate3 where Type='" + Type + "'";
            return Convert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString()));
        }
	}
}

