using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZQUSR.DAL
{
	/// <summary>
	/// ���ݷ�����sr_Periodicals��
	/// </summary>
	public class sr_Periodicals
	{
		public sr_Periodicals()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_PID", "sr_Periodicals"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int PK_PID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Periodicals");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4)};
			parameters[0].Value = PK_PID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(ZQUSR.Model.sr_Periodicals model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Periodicals(");
			strSql.Append("ISSN,QikanKey,QikanName,QikanEngName,XueKe,QIF,JiBie,LevelFactor,Extra1,Extra2,Extra3)");
			strSql.Append(" values (");
			strSql.Append("@ISSN,@QikanKey,@QikanName,@QikanEngName,@XueKe,@QIF,@JiBie,@LevelFactor,@Extra1,@Extra2,@Extra3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ISSN", SqlDbType.NVarChar,20),
					new SqlParameter("@QikanKey", SqlDbType.NVarChar,10),
					new SqlParameter("@QikanName", SqlDbType.NVarChar,100),
					new SqlParameter("@QikanEngName", SqlDbType.NVarChar,100),
					new SqlParameter("@XueKe", SqlDbType.NVarChar,10),
					new SqlParameter("@QIF", SqlDbType.Float,8),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra3", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.ISSN;
			parameters[1].Value = model.QikanKey;
			parameters[2].Value = model.QikanName;
			parameters[3].Value = model.QikanEngName;
			parameters[4].Value = model.XueKe;
			parameters[5].Value = model.QIF;
			parameters[6].Value = model.JiBie;
			parameters[7].Value = model.LevelFactor;
			parameters[8].Value = model.Extra1;
			parameters[9].Value = model.Extra2;
			parameters[10].Value = model.Extra3;

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
		public void Update(ZQUSR.Model.sr_Periodicals model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Periodicals set ");
			strSql.Append("ISSN=@ISSN,");
			strSql.Append("QikanKey=@QikanKey,");
			strSql.Append("QikanName=@QikanName,");
			strSql.Append("QikanEngName=@QikanEngName,");
			strSql.Append("XueKe=@XueKe,");
			strSql.Append("QIF=@QIF,");
			strSql.Append("JiBie=@JiBie,");
			strSql.Append("LevelFactor=@LevelFactor,");
			strSql.Append("Extra1=@Extra1,");
			strSql.Append("Extra2=@Extra2,");
			strSql.Append("Extra3=@Extra3");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4),
					new SqlParameter("@ISSN", SqlDbType.NVarChar,20),
					new SqlParameter("@QikanKey", SqlDbType.NVarChar,10),
					new SqlParameter("@QikanName", SqlDbType.NVarChar,100),
					new SqlParameter("@QikanEngName", SqlDbType.NVarChar,100),
					new SqlParameter("@XueKe", SqlDbType.NVarChar,10),
					new SqlParameter("@QIF", SqlDbType.Float,8),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra3", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.PK_PID;
			parameters[1].Value = model.ISSN;
			parameters[2].Value = model.QikanKey;
			parameters[3].Value = model.QikanName;
			parameters[4].Value = model.QikanEngName;
			parameters[5].Value = model.XueKe;
			parameters[6].Value = model.QIF;
			parameters[7].Value = model.JiBie;
			parameters[8].Value = model.LevelFactor;
			parameters[9].Value = model.Extra1;
			parameters[10].Value = model.Extra2;
			parameters[11].Value = model.Extra3;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PK_PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Periodicals ");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4)};
			parameters[0].Value = PK_PID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZQUSR.Model.sr_Periodicals GetModel(int PK_PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_PID,ISSN,QikanKey,QikanName,QikanEngName,XueKe,QIF,JiBie,LevelFactor,Extra1,Extra2,Extra3 from sr_Periodicals ");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4)};
			parameters[0].Value = PK_PID;

			ZQUSR.Model.sr_Periodicals model=new ZQUSR.Model.sr_Periodicals();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_PID"].ToString()!="")
				{
					model.PK_PID=int.Parse(ds.Tables[0].Rows[0]["PK_PID"].ToString());
				}
				model.ISSN=ds.Tables[0].Rows[0]["ISSN"].ToString();
				model.QikanKey=ds.Tables[0].Rows[0]["QikanKey"].ToString();
				model.QikanName=ds.Tables[0].Rows[0]["QikanName"].ToString();
				model.QikanEngName=ds.Tables[0].Rows[0]["QikanEngName"].ToString();
				model.XueKe=ds.Tables[0].Rows[0]["XueKe"].ToString();
				if(ds.Tables[0].Rows[0]["QIF"].ToString()!="")
				{
					model.QIF=decimal.Parse(ds.Tables[0].Rows[0]["QIF"].ToString());
				}
				model.JiBie=ds.Tables[0].Rows[0]["JiBie"].ToString();
				if(ds.Tables[0].Rows[0]["LevelFactor"].ToString()!="")
				{
					model.LevelFactor=decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PK_PID,ISSN,QikanKey,QikanName,QikanEngName,XueKe,QIF,JiBie,LevelFactor,Extra1,Extra2,Extra3 ");
			strSql.Append(" FROM sr_Periodicals ");
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
			strSql.Append(" PK_PID,ISSN,QikanKey,QikanName,QikanEngName,XueKe,QIF,JiBie,LevelFactor,Extra1,Extra2,Extra3 ");
			strSql.Append(" FROM sr_Periodicals ");
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
			parameters[0].Value = "sr_Periodicals";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����


        #region �����û�����Ĺؼ��ּ������ݿⷵ���ڿ����ƣ�����ƥ�������
        /// <summary>
        /// �����û�����Ĺؼ��ּ������ݿⷵ���ڿ����ƣ�����ƥ�����������By Jianguo Fung
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataSet GetQikanNameByKey(string key)
        {
            string strSql = "select QikanName from sr_Periodicals where QikanName like '" + key + "%'";
            return DbHelperSQL.Query(strSql.ToString());
        } 
        #endregion

        #region �����ڿ��ŷ����ڿ�����
        /// <summary>
        /// �����ڿ��ŷ����ڿ�����   ��By Jianguo Fung
        /// 
        /// </summary>
        /// <param name="ISSN"></param>
        /// <returns></returns>
        public string GetQikanNameByISSN(string ISSN)
        {
            string strSql = "select QikanName from sr_Periodicals where ISSN='" + ISSN + "'";
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        } 
        #endregion

        #region ���ݿ�������(QikanName)���ض�Ӧ��Ӱ������(QIF)������(JiBie)�ͼ����ϵ��(LevelFactor)
        /// <summary>
        /// ѧ�����ģ����ݿ�������(QikanName)���ض�Ӧ��Ӱ������(QIF)������(JiBie)�ͼ����ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        public ZQUSR.Model.sr_Periodicals GetLunwenJiBieByQikanName(string QikanName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 QIF,JiBie,LevelFactor from sr_Periodicals ");
            strSql.Append(" where QikanName=@QikanName ");
            SqlParameter[] parameters = {
					new SqlParameter("@QikanName", SqlDbType.NVarChar,100)};
            parameters[0].Value = QikanName;

            ZQUSR.Model.sr_Periodicals model = new ZQUSR.Model.sr_Periodicals();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["QIF"].ToString() != "")
                {
                    model.QIF = decimal.Parse(ds.Tables[0].Rows[0]["QIF"].ToString());
                }
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

        #region ���������б�(1������SCI/SSCI���ݣ�2�����ط�SCI/SSCI����)
        /// <summary>
        /// ���������б�(1������SCI/SSCI���ݣ�2�����ط�SCI/SSCI����) ��By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetDatByKey(int key)
        {
            string strSql = null;
            if (key == 1)
            {
                strSql = "select * from sr_Periodicals where QikanKey in('SCI','SSCI')";
            }
            else if (key == 2)
            {
                strSql = "select * from sr_Periodicals where QikanKey not in('SCI','SSCI')";
            }
            return DbHelperSQL.Query(strSql.ToString());
        } 
        #endregion

        #region ���¼���ͼ����ϵ��
        /// <summary>
        /// ���¼���ͼ����ϵ�� ��By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateJiBie(ZQUSR.Model.sr_Periodicals model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_Periodicals set ");
            strSql.Append(" JiBie=@JiBie,");
            strSql.Append(" LevelFactor=@LevelFactor ");
            strSql.Append(" where PK_PID=@PK_PID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8)};
            parameters[0].Value = model.PK_PID;
            parameters[1].Value = model.JiBie;
            parameters[2].Value = model.LevelFactor;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        } 
        #endregion

        #region ����Ӱ������
        /// <summary>
        /// ����Ӱ������  ��By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateQIF(ZQUSR.Model.sr_Periodicals model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_Periodicals set ");
            strSql.Append("QIF=@QIF ");
            strSql.Append(" where PK_PID=@PK_PID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4),
					new SqlParameter("@QIF", SqlDbType.Float,8)};
            parameters[0].Value = model.PK_PID;
            parameters[1].Value = model.QIF;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        } 
        #endregion

        #region �Ƿ���ڸü�¼
        /// <summary>
        /// �Ƿ���ڸü�¼��QikanKey/QikanName����By Jianguo Fung
        /// </summary>
        public bool Exists(ZQUSR.Model.sr_Periodicals model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Periodicals");
            strSql.Append(" where QikanKey=@QikanKey and ");
            strSql.Append("  QikanName=@QikanName ");
            SqlParameter[] parameters = {
					new SqlParameter("@QikanKey", SqlDbType.Char,10),
                    new SqlParameter("@QikanName", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.QikanKey;
            parameters[1].Value = model.QikanName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion
	}
}

