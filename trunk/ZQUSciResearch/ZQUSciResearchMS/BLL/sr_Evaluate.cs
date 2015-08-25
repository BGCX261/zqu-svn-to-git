using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// ҵ���߼���sr_Evaluate ��ժҪ˵����
	/// </summary>
	public class sr_Evaluate
	{
		private readonly ZQUSR.DAL.sr_Evaluate dal=new ZQUSR.DAL.sr_Evaluate();
		public sr_Evaluate()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int PK_EID)
		{
			return dal.Exists(PK_EID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZQUSR.Model.sr_Evaluate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZQUSR.Model.sr_Evaluate model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PK_EID)
		{
			
			dal.Delete(PK_EID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZQUSR.Model.sr_Evaluate GetModel(int PK_EID)
		{
			
			return dal.GetModel(PK_EID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZQUSR.Model.sr_Evaluate GetModelByCache(int PK_EID)
		{
			
			string CacheKey = "sr_EvaluateModel-" + PK_EID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_EID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_Evaluate)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZQUSR.Model.sr_Evaluate> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZQUSR.Model.sr_Evaluate> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_Evaluate> modelList = new List<ZQUSR.Model.sr_Evaluate>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_Evaluate model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_Evaluate();
					if(dt.Rows[n]["PK_EID"].ToString()!="")
					{
						model.PK_EID=int.Parse(dt.Rows[n]["PK_EID"].ToString());
					}
					model.Sort=dt.Rows[n]["Sort"].ToString();
					model.Type=dt.Rows[n]["Type"].ToString();
					model.Source=dt.Rows[n]["Source"].ToString();
					model.Grade=dt.Rows[n]["Grade"].ToString();
					model.AwardGrade=dt.Rows[n]["AwardGrade"].ToString();
					if(dt.Rows[n]["Funds1"].ToString()!="")
					{
						model.Funds1=decimal.Parse(dt.Rows[n]["Funds1"].ToString());
					}
					if(dt.Rows[n]["Funds2"].ToString()!="")
					{
						model.Funds2=decimal.Parse(dt.Rows[n]["Funds2"].ToString());
					}
					model.JiBie=dt.Rows[n]["JiBie"].ToString();
					if(dt.Rows[n]["LevelFactor"].ToString()!="")
					{
						model.LevelFactor=decimal.Parse(dt.Rows[n]["LevelFactor"].ToString());
                        //model.LevelFactor = dt.Rows[n]["LevelFactor"].ToString();  //--by caiyuying
					}
					model.Extra1=dt.Rows[n]["Extra1"].ToString();
					model.Extra2=dt.Rows[n]["Extra2"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����


        #region ר���ɹ������ؼ���ͼ����ϵ��
        /// <summary>
        /// ר���ɹ�������ר������(Type)��ר���ȼ�(Source)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetZhuanLiJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            return dal.GetZhuanLiJiBie(AchievementModel);
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
            return dal.GetKJJDJiBie(AchievementModel);
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
            return dal.GetSourceByClass(strClass);
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
            return dal.GetHuoJiangType(strClass);
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
            return dal.GetHouJiangGrade(strClass);
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
            return dal.GetGradeByClass(strClass);
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
            return dal.GetSourceBySortType(strClass, strType);
        } 
        #endregion  

        #region  ��Ƽ����ɹ������ؼ���ͼ����ϵ��
        /// <summary>
        /// ��Ƽ����ɹ������ݳɹ���Դ(Source)�ͼ����ȼ�(Grade)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetSKJDJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            return dal.GetSKJDJiBie(AchievementModel);
        } 
        #endregion

        #region �Ƽ�Ӧ�óɹ������ؼ���ͼ����ϵ��
        /// <summary>
        /// �Ƽ�Ӧ�óɹ������ݳɹ���Դ��Source�����ض�Ӧ�ļ���JiBie���ͼ����ϵ����LevelFactor�� ����By Jianguo Fung
        /// </summary>
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetKJYYJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            return dal.GetKJYYJiBie(AchievementModel);
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
            return dal.GetRuanKeXueJiBie(AchievementModel);
        } 
        #endregion

        #region �񽱳ɹ������ؼ���ͼ����ϵ��
        /// <summary>
        /// �񽱳ɹ������ݻ񽱼���(Source)�ͻ񽱵ȼ�(Grade)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        /// <param name="AchievementModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetHuoJiangJiBie(ZQUSR.Model.sr_Achievement AchievementModel)
        {
            return dal.GetHuoJiangJiBie(AchievementModel);
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
            return dal.GetTypeBySort(strClass);
        }
        #endregion

        #region ѧ�����������ؼ���ͼ����ϵ��
        /// <summary>
        /// ѧ��������������Դ(Source)����������(Type)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        /// </summary>
        /// <param name="LZJModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetZhuZuoJiBie(ZQUSR.Model.sr_LwZzJc LZJModel)
        {
            return dal.GetZhuZuoJiBie(LZJModel);
        } 
        #endregion

        #region ������Ŀ�����ؼ���ͼ����ϵ��
        /// <summary>
        /// ������Ŀ��������Ŀ����(Type)����Ŀ��Դ(Source)���ض�Ӧ�ļ���(JiBie)�������ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        /// </summary>
        /// <param name="ProjectModel"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Evaluate GetXiangMuJiBie(ZQUSR.Model.sr_Project ProjectModel)
        {
            return dal.GetXiangMuJiBie(ProjectModel);
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
            return dal.GetShenBaoJiBie(ProjectModel);
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
            return dal.GetEvaluateBySort(sort);
        }
        #endregion

        #region ���¼���ͼ����ϵ����������׼��
        /// <summary>
        /// ���¼���ͼ����ϵ����������׼����By Jianguo Fung
        /// </summary>
        public void UpdateJiBie(ZQUSR.Model.sr_Evaluate model)
        {
            dal.UpdateJiBie(model);
        }
        #endregion

        #region �Ƿ���ڸü�¼��ѧ������/�Ƽ������ɹ�/������Ŀ��
        /// <summary>
        /// �Ƿ���ڸü�¼(Sort/Type/Source)��ѧ������/�Ƽ������ɹ�/������Ŀ��  ����By Jianguo Fung
        /// </summary>
        public bool ExistsTypeSource(ZQUSR.Model.sr_Evaluate model)
        {
            return dal.ExistsTypeSource(model);
        }
        #endregion

        #region �Ƿ���ڸü�¼��ר���ɹ���
        /// <summary>
        /// �Ƿ���ڸü�¼(Sort/Type) ��ר���ɹ��� ����By Jianguo Fung
        /// </summary>
        public bool ExistsType(ZQUSR.Model.sr_Evaluate model)
        {
            return dal.ExistsType(model);
        }
        #endregion

        #region �Ƿ���ڸü�¼����Ƽ����ɹ���
        /// <summary>
        /// �Ƿ���ڸü�¼(Sort/Source/Grade)����Ƽ����ɹ���  ����By Jianguo Fung
        /// </summary>
        public bool ExistsSourceGrade(ZQUSR.Model.sr_Evaluate model)
        {
            return dal.ExistsSourceGrade(model);
        }
        #endregion

        #region �Ƿ���ڸü�¼���Ƽ�Ӧ�óɹ�/���ѧ�ɹ���
        /// <summary>
        /// �Ƿ���ڸü�¼(Sort/Source)���Ƽ�Ӧ�óɹ�/���ѧ�ɹ���  ����By Jianguo Fung
        /// </summary>
        public bool ExistsSource(ZQUSR.Model.sr_Evaluate model)
        {
            return dal.ExistsSource(model);
        }
        #endregion

        #region �Ƿ���ڸü�¼���񽱳ɹ���
        /// <summary>
        /// �Ƿ���ڸü�¼(Sort/Type/Grade/AwardGrade)���񽱳ɹ���  ����By Jianguo Fung
        /// </summary>
        public bool ExistsTypeGradeAwardGrade(ZQUSR.Model.sr_Evaluate model)
        {
            return dal.ExistsTypeGradeAwardGrade(model);
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
            return dal.ExistsTypeSourceGrade(model);
        }
        #endregion
	}
}

