using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// ҵ���߼���sr_Periodicals ��ժҪ˵����
	/// </summary>
	public class sr_Periodicals
	{
		private readonly ZQUSR.DAL.sr_Periodicals dal=new ZQUSR.DAL.sr_Periodicals();
		public sr_Periodicals()
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
		public bool Exists(int PK_PID)
		{
			return dal.Exists(PK_PID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZQUSR.Model.sr_Periodicals model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZQUSR.Model.sr_Periodicals model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PK_PID)
		{
			
			dal.Delete(PK_PID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZQUSR.Model.sr_Periodicals GetModel(int PK_PID)
		{
			
			return dal.GetModel(PK_PID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZQUSR.Model.sr_Periodicals GetModelByCache(int PK_PID)
		{
			
			string CacheKey = "sr_PeriodicalsModel-" + PK_PID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_PID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_Periodicals)objModel;
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
		public List<ZQUSR.Model.sr_Periodicals> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZQUSR.Model.sr_Periodicals> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_Periodicals> modelList = new List<ZQUSR.Model.sr_Periodicals>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_Periodicals model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_Periodicals();
					if(dt.Rows[n]["PK_PID"].ToString()!="")
					{
						model.PK_PID=int.Parse(dt.Rows[n]["PK_PID"].ToString());
					}
					model.ISSN=dt.Rows[n]["ISSN"].ToString();
					model.QikanKey=dt.Rows[n]["QikanKey"].ToString();
					model.QikanName=dt.Rows[n]["QikanName"].ToString();
					model.QikanEngName=dt.Rows[n]["QikanEngName"].ToString();
					model.XueKe=dt.Rows[n]["XueKe"].ToString();
					if(dt.Rows[n]["QIF"].ToString()!="")
					{
						model.QIF=decimal.Parse(dt.Rows[n]["QIF"].ToString());
					}
					model.JiBie=dt.Rows[n]["JiBie"].ToString();
					if(dt.Rows[n]["LevelFactor"].ToString()!="")
					{
						model.LevelFactor=decimal.Parse(dt.Rows[n]["LevelFactor"].ToString());
					}
					model.Extra1=dt.Rows[n]["Extra1"].ToString();
					model.Extra2=dt.Rows[n]["Extra2"].ToString();
					model.Extra3=dt.Rows[n]["Extra3"].ToString();
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


        #region �����û�����Ĺؼ��ּ������ݿⷵ���ڿ����ƣ�����ƥ�������
        /// <summary>
        /// �����û�����Ĺؼ��ּ������ݿⷵ���ڿ����ƣ�����ƥ�����������By Jianguo Fung
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataSet GetQikanNameByKey(string key)
        {
            return dal.GetQikanNameByKey(key);
        } 
        #endregion

        #region �����ڿ��ŷ����ڿ�����
        /// <summary>
        ///  �����ڿ��ŷ����ڿ�����   ��By Jianguo Fung
        /// </summary>
        /// <param name="ISSN"></param>
        /// <returns></returns>
        public string GetQikanNameByISSN(string ISSN)
        {
            return dal.GetQikanNameByISSN(ISSN);
        } 
        #endregion

        #region ѧ�����ģ����ݿ�������(QikanName)���ض�Ӧ��Ӱ������(QIF)������(JiBie)�ͼ����ϵ��(LevelFactor) 
        /// <summary>
        /// ѧ�����ģ����ݿ�������(QikanName)���ض�Ӧ��Ӱ������(QIF)������(JiBie)�ͼ����ϵ��(LevelFactor)     ����By Jianguo Fung
        /// </summary>
        public ZQUSR.Model.sr_Periodicals GetLunwenJiBieByQikanName(string QikanName)
        {
            return dal.GetLunwenJiBieByQikanName(QikanName);
        } 
        #endregion

        #region ���������б�(1������SCI/SSCI���ݣ�2�����ط�SCI/SSCI����)
        /// <summary>
        /// ���������б�(1������SCI/SSCI���ݣ�2�����ط�SCI/SSCI����) ��By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetDatByKey(int key)
        {
            return dal.GetDatByKey(key);
        }
        #endregion

        #region ���¼���ͼ����ϵ��
        /// <summary>
        /// ���¼���ͼ����ϵ�� ��By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateJiBie(ZQUSR.Model.sr_Periodicals model)
        {
            dal.UpdateJiBie(model);
        }
        #endregion

        #region ����Ӱ������
        /// <summary>
        /// ����Ӱ������  ��By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateQIF(ZQUSR.Model.sr_Periodicals model)
        {
            dal.UpdateQIF(model);
        }
        #endregion

        #region �Ƿ���ڸü�¼
        /// <summary>
        /// �Ƿ���ڸü�¼��QikanKey/QikanName����By Jianguo Fung
        /// </summary>
        public bool Exists(ZQUSR.Model.sr_Periodicals model)
        {
            return dal.Exists(model);
        }
        #endregion
	}
}

