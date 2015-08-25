using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// ҵ���߼���sr_Produce ��ժҪ˵����
	/// </summary>
	public class sr_Produce
	{
		private readonly ZQUSR.DAL.sr_Produce dal=new ZQUSR.DAL.sr_Produce();
		public sr_Produce()
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
		public int  Add(ZQUSR.Model.sr_Produce model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZQUSR.Model.sr_Produce model)
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
		public ZQUSR.Model.sr_Produce GetModel(int PK_PID)
		{
			
			return dal.GetModel(PK_PID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZQUSR.Model.sr_Produce GetModelByCache(int PK_PID)
		{
			
			string CacheKey = "sr_ProduceModel-" + PK_PID;
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
			return (ZQUSR.Model.sr_Produce)objModel;
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
		public List<ZQUSR.Model.sr_Produce> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZQUSR.Model.sr_Produce> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_Produce> modelList = new List<ZQUSR.Model.sr_Produce>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_Produce model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_Produce();
					if(dt.Rows[n]["PK_PID"].ToString()!="")
					{
						model.PK_PID=int.Parse(dt.Rows[n]["PK_PID"].ToString());
					}
					model.XueKe=dt.Rows[n]["XueKe"].ToString();
					model.Source=dt.Rows[n]["Source"].ToString();
					model.JiBie=dt.Rows[n]["JiBie"].ToString();
					if(dt.Rows[n]["LevelFactor"].ToString()!="")
					{
						model.LevelFactor=decimal.Parse(dt.Rows[n]["LevelFactor"].ToString());
                        //model.LevelFactor = dt.Rows[n]["LevelFactor"].ToString();
					}
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


        #region ������ɹ�������ѧ���б�
        /// <summary>
        /// ������ɹ�������ѧ���б�    ����By Jianguo Fung   
        /// </summary>
        /// <returns></returns>
        public DataSet GetXueKe()
        {
            return dal.GetXueKe();
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
            return dal.GetSourceByXueke(Xueke);
        } 
        #endregion

        #region ������ɹ������ؼ���ͼ����ϵ��
        /// <summary>
        /// ������ɹ������ݷ���������/��Դ��Source�����ؼ���ͼ����ϵ��     ����By Jianguo Fung
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Produce GetJiBieBySource(string Source)
        {
            return dal.GetJiBieBySource(Source);
        } 
        #endregion

        #region ���������б�
        /// <summary>
        /// ���������б�   ����By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            return dal.GetData();
        }
        #endregion

        #region �Ƿ���ڸü�¼
        /// <summary>
        /// �Ƿ���ڸü�¼��XueKe/Source����By Jianguo Fung
        /// </summary>
        public bool Exists(ZQUSR.Model.sr_Produce model)
        {
            return dal.Exists(model);
        }
        #endregion

        #region ���¼���ͼ����ϵ����������׼��
        /// <summary>
        /// ���¼���ͼ����ϵ����������׼����By Jianguo Fung
        /// </summary>
        public void UpdateJiBie(ZQUSR.Model.sr_Produce model)
        {
            dal.UpdateJiBie(model);
        }
        #endregion
	}
}

