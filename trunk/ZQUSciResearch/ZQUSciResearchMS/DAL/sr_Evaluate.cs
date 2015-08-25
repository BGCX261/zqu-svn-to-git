using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace ZQUSR.DAL
{
	/// <summary>
	/// ���ݷ�����sr_Evaluate��
	/// </summary>
	public class sr_Evaluate
	{
		public sr_Evaluate()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PK_EID", "sr_Evaluate"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int PK_EID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sr_Evaluate");
			strSql.Append(" where PK_EID=@PK_EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_EID", SqlDbType.Int,4)};
			parameters[0].Value = PK_EID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(ZQUSR.Model.sr_Evaluate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sr_Evaluate(");
			strSql.Append("Sort,Type,Source,Grade,AwardGrade,Funds1,Funds2,JiBie,LevelFactor,Extra1,Extra2)");
			strSql.Append(" values (");
			strSql.Append("@Sort,@Type,@Source,@Grade,@AwardGrade,@Funds1,@Funds2,@JiBie,@LevelFactor,@Extra1,@Extra2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Source", SqlDbType.NVarChar,30),
					new SqlParameter("@Grade", SqlDbType.NVarChar,20),
					new SqlParameter("@AwardGrade", SqlDbType.NVarChar,5),
					new SqlParameter("@Funds1", SqlDbType.Float,8),
					new SqlParameter("@Funds2", SqlDbType.Float,8),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.Sort;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Source;
			parameters[3].Value = model.Grade;
			parameters[4].Value = model.AwardGrade;
			parameters[5].Value = model.Funds1;
			parameters[6].Value = model.Funds2;
			parameters[7].Value = model.JiBie;
			parameters[8].Value = model.LevelFactor;
			parameters[9].Value = model.Extra1;
			parameters[10].Value = model.Extra2;

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
		/// ����һ������      //--modify by caiyuying 2011--1-20
		/// </summary>
		public void Update(ZQUSR.Model.sr_Evaluate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sr_Evaluate set ");
			//strSql.Append("Sort=@Sort,");
			strSql.Append("Type=@Type,");
			strSql.Append("Source=@Source,");
			strSql.Append("Grade=@Grade,");
			strSql.Append("AwardGrade=@AwardGrade,");
			strSql.Append("Funds1=@Funds1,");
			strSql.Append("Funds2=@Funds2,");
			strSql.Append("JiBie=@JiBie,");
			strSql.Append("LevelFactor=@LevelFactor,");
			strSql.Append("Extra1=@Extra1,");
			strSql.Append("Extra2=@Extra2");
			strSql.Append(" where PK_EID=@PK_EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_EID", SqlDbType.Int,4),
					//new SqlParameter("@Sort", SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Source", SqlDbType.NVarChar,30),
					new SqlParameter("@Grade", SqlDbType.NVarChar,20),
					new SqlParameter("@AwardGrade", SqlDbType.NVarChar,5),
					new SqlParameter("@Funds1", SqlDbType.Float,8),
					new SqlParameter("@Funds2", SqlDbType.Float,8),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.PK_EID;
			//parameters[1].Value = model.Sort;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Source;
			parameters[3].Value = model.Grade;
			parameters[4].Value = model.AwardGrade;
			parameters[5].Value = model.Funds1;
			parameters[6].Value = model.Funds2;
			parameters[7].Value = model.JiBie;
			parameters[8].Value = model.LevelFactor;
			parameters[9].Value = model.Extra1;
			parameters[10].Value = model.Extra2;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PK_EID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sr_Evaluate ");
			strSql.Append(" where PK_EID=@PK_EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_EID", SqlDbType.Int,4)};
			parameters[0].Value = PK_EID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZQUSR.Model.sr_Evaluate GetModel(int PK_EID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PK_EID,Sort,Type,Source,Grade,AwardGrade,Funds1,Funds2,JiBie,LevelFactor,Extra1,Extra2 from sr_Evaluate ");
			strSql.Append(" where PK_EID=@PK_EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PK_EID", SqlDbType.Int,4)};
			parameters[0].Value = PK_EID;

			ZQUSR.Model.sr_Evaluate model=new ZQUSR.Model.sr_Evaluate();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PK_EID"].ToString()!="")
				{
					model.PK_EID=int.Parse(ds.Tables[0].Rows[0]["PK_EID"].ToString());
				}
				model.Sort=ds.Tables[0].Rows[0]["Sort"].ToString();
				model.Type=ds.Tables[0].Rows[0]["Type"].ToString();
				model.Source=ds.Tables[0].Rows[0]["Source"].ToString();
				model.Grade=ds.Tables[0].Rows[0]["Grade"].ToString();
				model.AwardGrade=ds.Tables[0].Rows[0]["AwardGrade"].ToString();
				if(ds.Tables[0].Rows[0]["Funds1"].ToString()!="")
				{
					model.Funds1=decimal.Parse(ds.Tables[0].Rows[0]["Funds1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Funds2"].ToString()!="")
				{
					model.Funds2=decimal.Parse(ds.Tables[0].Rows[0]["Funds2"].ToString());
				}
				model.JiBie=ds.Tables[0].Rows[0]["JiBie"].ToString();
				if(ds.Tables[0].Rows[0]["LevelFactor"].ToString()!="")
				{
					model.LevelFactor=decimal.Parse(ds.Tables[0].Rows[0]["LevelFactor"].ToString());
                    //model.LevelFactor = ds.Tables[0].Rows[0]["LevelFactor"].ToString();   //--by caiyuying
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PK_EID,Sort,Type,Source,Grade,AwardGrade,Funds1,Funds2,JiBie,LevelFactor,Extra1,Extra2 ");
			strSql.Append(" FROM sr_Evaluate ");
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
			strSql.Append(" PK_EID,Sort,Type,Source,Grade,AwardGrade,Funds1,Funds2,JiBie,LevelFactor,Extra1,Extra2 ");
			strSql.Append(" FROM sr_Evaluate ");
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
			parameters[0].Value = "sr_Evaluate";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����

        #region ר���ɹ������ؼ���ͼ����ϵ��
        /// <summary>
        /// ר���ɹ�������ר������(Type)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetZhuanLiJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Type=@Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,10)};
            parameters[0].Value = AchievementModel.Type;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
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

        #region �Ƽ������ɹ������ؼ���ͼ����ϵ��
        /// <summary>
        /// �Ƽ������ɹ������ݼ�������(Unit)�ͼ�������(Type)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetKJJDJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Type=@Type and Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = AchievementModel.Type;
            parameters[1].Value = AchievementModel.Unit;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
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

        #region ������𷵻ؼ������ţ��Ƽ������ɹ������ɹ���Դ����Ƽ����ɹ�����������Դ��ѧ��������
        /// <summary>
        /// ������𷵻ؼ������ţ��Ƽ������ɹ������ɹ���Դ����Ƽ����ɹ�����������Դ��ѧ��������    ����By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <returns></returns>
        public DataSet GetSourceByClass(string strClass)
        {
            string strSql = "select distinct Source from sr_Evaluate where Sort='"+ strClass +"'";
            return DbHelperSQL.Query(strSql.ToString());
        } 
        #endregion

        #region ���ݴ���𣨻񽱳ɹ������ػ񽱳ɹ���𣨽�ѧ�ɹ���/����/����ࣩ
        /// <summary>
        /// ���ݴ���𣨻񽱳ɹ������ػ񽱳ɹ���𣨽�ѧ�ɹ���/����/����ࣩ ����By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <returns></returns>
        public DataSet GetHuoJiangType(string strClass)
        {
            string strSql = "select distinct Type from sr_Evaluate where Sort='" + strClass + "'";
            return DbHelperSQL.Query(strSql.ToString());
        } 
        #endregion

        #region ������𷵻ػ񽱼��𣨻񽱳ɹ���
        /// <summary>
        /// ������𷵻ػ񽱼��𣨻񽱳ɹ���   ����By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <returns></returns>
        public DataSet GetHouJiangGrade(string strClass)
        {
            string strSql = "select distinct Grade from sr_Evaluate where Type='" + strClass + "'";
            return DbHelperSQL.Query(strSql.ToString());
        } 
        #endregion

        #region ������𷵻ؼ����ȼ�����Ƽ����ɹ���
        /// <summary>
        /// ������𷵻ؼ����ȼ�����Ƽ����ɹ���   ����By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <returns></returns>
        public DataSet GetGradeByClass(string strClass)
        {
            string strSql = "select distinct Type from sr_Evaluate where Sort='" + strClass + "'";
            return DbHelperSQL.Query(strSql.ToString());
        } 
        #endregion

        #region �����������ͷ�����Դ��������Ŀ/��Ŀ�걨��
        /// <summary>
        /// �����������ͷ�����Դ��������Ŀ/��Ŀ�걨��   ����By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <param name="strType"></param>
        /// <returns></returns>
        public DataSet GetSourceBySortType(string strClass, string strType)
        {
            string strSql = "select distinct Source from sr_Evaluate where Sort='" + strClass + "' and Type='" + strType + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }  
        #endregion
        
        #region ��Ƽ����ɹ������ؼ���ͼ����ϵ��
		/// <summary>
        /// ��Ƽ����ɹ������ݳɹ���Դ(Source)�ͼ����ȼ�(Grade)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetSKJDJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Source=@Source and Type=@Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@Source", SqlDbType.NVarChar,30),
                    new SqlParameter("@Type", SqlDbType.NVarChar,10)};
            parameters[0].Value = AchievementModel.Source;
            parameters[1].Value = AchievementModel.Grade;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
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

        #region �Ƽ�Ӧ�óɹ������ؼ���ͼ����ϵ��
        /// <summary>
        /// �Ƽ�Ӧ�óɹ������ݳɹ���Դ��Source�����ض�Ӧ�ļ���JiBie���ͼ����ϵ����LevelFactor�� ����By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetKJYYJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = AchievementModel.Source;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
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

        #region ���ѧ�ɹ������ؼ���ͼ����ϵ��
        /// <summary>
        /// ���ѧ�ɹ������ݲ��ɲ��ţ�Unit�����ض�Ӧ�ļ���JiBie���ͼ����ϵ����LevelFactor�� ����By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetRuanKeXueJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = AchievementModel.Unit;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
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

        #region �񽱳ɹ������ؼ���ͼ����ϵ��
        /// <summary>
        /// �񽱳ɹ�������(Type/Source/Grade)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetHuoJiangJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Type=@Type and Grade=@Source and AwardGrade=@Grade ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Type", SqlDbType.NVarChar,10),
					new SqlParameter("@Source", SqlDbType.NVarChar,30),
                    new SqlParameter("@Grade", SqlDbType.NVarChar,20)};
            parameters[0].Value = AchievementModel.Type;
            parameters[1].Value = AchievementModel.Source;
            parameters[2].Value = AchievementModel.Grade;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
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

        #region ���ݴ���𷵻����ͣ�ѧ������/ר���ɹ���
        /// <summary>
        /// ���ݴ����(Sort)��������(Type)��ѧ������/ר���ɹ���   ����By Jianguo Fung
        /// </summary>
        /// <param name="strClass"></param>
        /// <returns></returns>
        public DataSet GetTypeBySort(string strClass)
        {
            string strSql = "select distinct Type from sr_Evaluate where Sort='" + strClass + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region ѧ�����������ؼ���ͼ����ϵ��
        /// <summary>
        /// ѧ��������������Դ(Source)����������(Type)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetZhuZuoJiBie(ZQUSR.Model.sr_LwZzJc LZJModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Type=@Type and Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = LZJModel.Type;
            parameters[1].Value = LZJModel.Source;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
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

        #region ������Ŀ�����ؼ���ͼ����ϵ��
        /// <summary>
        /// ������Ŀ��������Ŀ����(Type)����Ŀ��Դ(Source)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By caiyuying
        /// </summary>
        /// <param name="ProjectModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetXiangMuJiBie(ZQUSR.Model.sr_Project ProjectModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Sort=@Sort and Type=@Type and Source=@Source ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Sort",SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = ProjectModel.SmallSort;
            parameters[1].Value = ProjectModel.Type;
            parameters[2].Value = ProjectModel.Source;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
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

        #region ������Ŀ�����ؼ���ͼ����ϵ��
        /// <summary>
        /// ������Ŀ�������걨��Ŀ����(Type)����Ŀ��Դ(Source)���걨���(Grade)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        /// <param name="ProjectModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetShenBaoJiBie(ZQUSR.Model.sr_Project ProjectModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JiBie,LevelFactor from sr_Evaluate ");
            strSql.Append(" where Sort=@Sort and Type=@Type and Source=@Source and Grade=@Grade ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Sort",SqlDbType.NVarChar,10),
					new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30),
                    new SqlParameter("@Grade", SqlDbType.NVarChar,20)};
            parameters[0].Value = ProjectModel.SmallSort;
            parameters[1].Value = ProjectModel.Type;
            parameters[2].Value = ProjectModel.Source;
            parameters[3].Value = ProjectModel.ReviewState;

            ZQUSR.Model.sr_Evaluate model = new ZQUSR.Model.sr_Evaluate();
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

        #region ������𷵻�������׼
        /// <summary>
        /// ������𷵻�������׼   ����By Jianguo Fung
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        public DataSet GetEvaluateBySort(string sort)
        {
            string strSql = "select * from sr_Evaluate where Sort='" + sort + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region ���¼���ͼ����ϵ����������׼��
        /// <summary>
        /// ���¼���ͼ����ϵ����������׼����By Jianguo Fung
        /// </summary>
        public void UpdateJiBie(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_Evaluate set ");
            strSql.Append("JiBie=@JiBie,");
            strSql.Append("LevelFactor=@LevelFactor ");
            strSql.Append(" where PK_EID=@PK_EID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_EID", SqlDbType.Int,4),
					new SqlParameter("@JiBie", SqlDbType.Char,1),
					new SqlParameter("@LevelFactor", SqlDbType.Float,8)};
            parameters[0].Value = model.PK_EID;
            parameters[1].Value = model.JiBie;
            parameters[2].Value = model.LevelFactor;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        } 
        #endregion

        #region �Ƿ���ڸü�¼��ѧ������/�Ƽ������ɹ�/������Ŀ��
        /// <summary>
        /// �Ƿ���ڸü�¼(Sort/Type/Source)��ѧ������/�Ƽ������ɹ�/������Ŀ��  ����By Jianguo Fung
        /// </summary>
        public bool ExistsTypeSource(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Type=@Type and ");
            strSql.Append(" Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Source;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        } 
        #endregion

        #region �Ƿ���ڸü�¼��ר���ɹ���
        /// <summary>
        /// �Ƿ���ڸü�¼(Sort/Type) ��ר���ɹ��� ����By Jianguo Fung
        /// </summary>
        public bool ExistsType(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Type=@Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Type", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Type;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region �Ƿ���ڸü�¼����Ƽ����ɹ���
        /// <summary>
        /// �Ƿ���ڸü�¼(Sort/Source/Grade)����Ƽ����ɹ���  ����By Jianguo Fung
        /// </summary>
        public bool ExistsSourceGrade(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Source=@Source and ");
            strSql.Append(" Grade=@Grade ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30),
                    new SqlParameter("@Grade", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Source;
            parameters[2].Value = model.Grade;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region �Ƿ���ڸü�¼���Ƽ�Ӧ�óɹ�/���ѧ�ɹ���
        /// <summary>
        /// �Ƿ���ڸü�¼(Sort/Source)���Ƽ�Ӧ�óɹ�/���ѧ�ɹ���  ����By Jianguo Fung
        /// </summary>
        public bool ExistsSource(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Source=@Source ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Source;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region �Ƿ���ڸü�¼���񽱳ɹ���
        /// <summary>
        /// �Ƿ���ڸü�¼(Sort/Type/Grade/AwardGrade)���񽱳ɹ���  ����By Jianguo Fung
        /// </summary>
        public bool ExistsTypeGradeAwardGrade(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Type=@Type and ");
            strSql.Append(" Grade=@Grade and ");
            strSql.Append(" AwardGrade=@AwardGrade ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Grade", SqlDbType.NVarChar,20),
                    new SqlParameter("@AwardGrade", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Grade;
            parameters[3].Value = model.AwardGrade;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region �Ƿ���ڸü�¼����Ŀ�걨��
        /// <summary>
        /// �Ƿ���ڸü�¼(Sort/Type/Source/Source)����Ŀ�걨��  ����By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsTypeSourceGrade(ZQUSR.Model.sr_Evaluate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_Evaluate");
            strSql.Append(" where Sort=@Sort and ");
            strSql.Append(" Type=@Type and ");
            strSql.Append(" Source=@Source and ");
            strSql.Append(" Grade=@Grade ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sort", SqlDbType.NVarChar,10),
                    new SqlParameter("@Type", SqlDbType.NVarChar,10),
                    new SqlParameter("@Source", SqlDbType.NVarChar,30),
                    new SqlParameter("@Grade", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.Sort;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Source;
            parameters[3].Value = model.Grade;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        } 
        #endregion
	}
}

