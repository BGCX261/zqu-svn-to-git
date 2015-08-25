using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// ҵ���߼���sr_Calculate3 ��ժҪ˵����
	/// </summary>
	public class sr_Calculate3
	{
		private readonly ZQUSR.DAL.sr_Calculate3 dal=new ZQUSR.DAL.sr_Calculate3();
		public sr_Calculate3()
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
		public bool Exists(int PK_CID)
		{
			return dal.Exists(PK_CID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZQUSR.Model.sr_Calculate3 model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZQUSR.Model.sr_Calculate3 model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PK_CID)
		{
			
			dal.Delete(PK_CID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZQUSR.Model.sr_Calculate3 GetModel(int PK_CID)
		{
			
			return dal.GetModel(PK_CID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZQUSR.Model.sr_Calculate3 GetModelByCache(int PK_CID)
		{
			
			string CacheKey = "sr_Calculate3Model-" + PK_CID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_CID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_Calculate3)objModel;
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
		public List<ZQUSR.Model.sr_Calculate3> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZQUSR.Model.sr_Calculate3> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_Calculate3> modelList = new List<ZQUSR.Model.sr_Calculate3>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_Calculate3 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_Calculate3();
					if(dt.Rows[n]["PK_CID"].ToString()!="")
					{
						model.PK_CID=int.Parse(dt.Rows[n]["PK_CID"].ToString());
					}
					model.Type=dt.Rows[n]["Type"].ToString();
					if(dt.Rows[n]["Scale"].ToString()!="")
					{
						model.Scale=decimal.Parse(dt.Rows[n]["Scale"].ToString());
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

        /// <summary>
        /// ���������б� ��By Jianguo Fung
        /// </summary>
        public DataSet GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����һ������ ��By Jianguo Fung
        /// </summary>
        public void UpdateScale(ZQUSR.Model.sr_Calculate3 model)
        {
            dal.UpdateScale(model);
        }

        /// <summary>
        /// �õ���Ŀ�����˵ı���  --by caiyuying 2011-01-21
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public decimal GetProjectScale(string Type)
        {
            return dal.GetProjectScale(Type);
        }
	}
}

