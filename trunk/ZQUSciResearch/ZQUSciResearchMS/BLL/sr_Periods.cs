using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// ҵ���߼���sr_Periods ��ժҪ˵����
	/// </summary>
	public class sr_Periods
	{
		private readonly ZQUSR.DAL.sr_Periods dal=new ZQUSR.DAL.sr_Periods();
		public sr_Periods()
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
		public int  Add(ZQUSR.Model.sr_Periods model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZQUSR.Model.sr_Periods model)
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
		public ZQUSR.Model.sr_Periods GetModel(int PK_PID)
		{
			
			return dal.GetModel(PK_PID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZQUSR.Model.sr_Periods GetModelByCache(int PK_PID)
		{
			
			string CacheKey = "sr_PeriodsModel-" + PK_PID;
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
			return (ZQUSR.Model.sr_Periods)objModel;
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
		public List<ZQUSR.Model.sr_Periods> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZQUSR.Model.sr_Periods> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_Periods> modelList = new List<ZQUSR.Model.sr_Periods>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_Periods model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_Periods();
					if(dt.Rows[n]["PK_PID"].ToString()!="")
					{
						model.PK_PID=int.Parse(dt.Rows[n]["PK_PID"].ToString());
					}
					model.PeriName=dt.Rows[n]["PeriName"].ToString();
					if(dt.Rows[n]["StartTime"].ToString()!="")
					{
						model.StartTime=DateTime.Parse(dt.Rows[n]["StartTime"].ToString());
					}
					if(dt.Rows[n]["EndTime"].ToString()!="")
					{
						model.EndTime=DateTime.Parse(dt.Rows[n]["EndTime"].ToString());
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

        #region ���������б�
        /// <summary>
        /// ���������б�  ��By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            return dal.GetList();
        }
        #endregion

        #region ʱ������
        /// <summary>
        /// ʱ������   ��By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateTime(ZQUSR.Model.sr_Periods model)
        {
            dal.UpdateTime(model);
        }
        #endregion
	}
}

