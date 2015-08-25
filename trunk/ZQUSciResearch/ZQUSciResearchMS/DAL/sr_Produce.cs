using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZQUSR.DAL
{
	/// <summary>
	/// ���ݷ�����sr_Produce��
	/// </summary>
	public class sr_Produce
	{
		public sr_Produce()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_PID", "sr_Produce"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int PK_PID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Produce");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4)};
			parameters[0].Value = PK_PID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(ZQUSR.Model.sr_Produce model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Produce(");
			strSql.Append("XueKe,Source,JiBie,LevelFactor)");
			strSql.Append(" values (");
			strSql.Append("@XueKe,@Source,@JiBie,@LevelFactor)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@XueKe", SqlDbType.Char,4),
					new SqlParameter("@Source", SqlDbType.NVarChar,70),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8)};
			parameters[0].Value = model.XueKe;
			parameters[1].Value = model.Source;
			parameters[2].Value = model.JiBie;
			parameters[3].Value = model.LevelFactor;

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
		/// ����һ������  ---modify by caiyuying 2011-1-20
		/// </summary>
		public void Update(ZQUSR.Model.sr_Produce model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Produce set ");
			//strSql.Append("XueKe=@XueKe,");
			strSql.Append("Source=@Source,");
			strSql.Append("JiBie=@JiBie,");
			strSql.Append("LevelFactor=@LevelFactor");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4),
					//new SqlParameter("@XueKe", SqlDbType.Char,4),
					new SqlParameter("@Source", SqlDbType.NVarChar,70),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8)};
			parameters[0].Value = model.PK_PID;
			//parameters[1].Value = model.XueKe;
			parameters[1].Value = model.Source;
			parameters[2].Value = model.JiBie;
			parameters[3].Value = model.LevelFactor;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PK_PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Produce ");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4)};
			parameters[0].Value = PK_PID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZQUSR.Model.sr_Produce GetModel(int PK_PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_PID,XueKe,Source,JiBie,LevelFactor from sr_Produce ");
			strSql.Append(" where PK_PID=@PK_PID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_PID", SqlDbType.Int,4)};
			parameters[0].Value = PK_PID;

			ZQUSR.Model.sr_Produce model=new ZQUSR.Model.sr_Produce();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_PID"].ToString()!="")
				{
					model.PK_PID=int.Parse(ds.Tables[0].Rows[0]["PK_PID"].ToString());
				}
				model.XueKe=ds.Tables[0].Rows[0]["XueKe"].ToString();
				model.Source=ds.Tables[0].Rows[0]["Source"].ToString();
				model.JiBie=ds.Tables[0].Rows[0]["JiBie"].ToString();
				if(ds.Tables[0].Rows[0]["LevelFactor"].ToString()!="")
				{
					model.LevelFactor=decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                    //model.LevelFactor = ds.Tables[0].Rows[0]["LevelFactor"].ToString();    //--by caiyuying
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
			strSql.Append("select PK_PID,XueKe,Source,JiBie,LevelFactor ");
			strSql.Append(" FROM sr_Produce ");
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
			strSql.Append(" PK_PID,XueKe,Source,JiBie,LevelFactor ");
			strSql.Append(" FROM sr_Produce ");
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
			parameters[0].Value = "sr_Produce";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����


        #region ������ɹ�������ѧ���б� 
        /// <summary>
        /// ������ɹ�������ѧ���б�    ����By Jianguo Fung     
        /// </summary>
        /// <returns></returns>
        public DataSet GetXueKe()
        {
            string strSql = "select distinct XueKe from sr_Produce";
            return DbHelperSQL.Query(strSql.ToString());
        } 
        #endregion

        #region ������ɹ�������ѧ�Ʒ��ط�������Դ
		/// <summary>
        /// ������ɹ�������ѧ�Ʒ��ط�������Դ    ����By Jianguo Fung
        /// </summary>
        /// <param name="Xueke"></param>
        /// <returns></returns>
        public DataSet GetSourceByXueke(string Xueke)
        {
            string strSql = "select * from sr_Produce where XueKe='"+ Xueke +"'";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region ������ɹ������ؼ���ͼ����ϵ��
        /// <summary>
        /// ������ɹ������ݷ���������/��Դ��Source�����ؼ���ͼ����ϵ��     ����By Jianguo Fung
        /// </summary>
        public ZQUSR.Model.sr_Produce GetJiBieBySource(string Source)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Produce ");
            strSql.Append(" where Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Source", SqlDbType.NVarChar,70)};
            parameters[0].Value = Source;

            ZQUSR.Model.sr_Produce model = new ZQUSR.Model.sr_Produce();
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

        #region ���������б�
        /// <summary>
        /// ���������б�   ����By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetData( )
        {
            string strSql = "select * from sr_Produce";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region �Ƿ���ڸü�¼
        /// <summary>
        /// �Ƿ���ڸü�¼��XueKe/Source����By Jianguo Fung
        /// </summary>
        public bool Exists(ZQUSR.Model.sr_Produce model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Produce");
            strSql.Append(" where XueKe=@XueKe and ");
            strSql.Append("  Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@XueKe", SqlDbType.Char,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.XueKe;
            parameters[1].Value = model.Source;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        } 
        #endregion

        #region ���¼���ͼ����ϵ����������׼��
        /// <summary>
        /// ���¼���ͼ����ϵ����������׼����By Jianguo Fung
        /// </summary>
        public void UpdateJiBie(ZQUSR.Model.sr_Produce model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_Produce set ");
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
	}
}

