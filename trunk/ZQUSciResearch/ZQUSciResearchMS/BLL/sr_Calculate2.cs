using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// ҵ���߼���sr_Calculate2 ��ժҪ˵����
	/// </summary>
	public class sr_Calculate2
	{
		private readonly ZQUSR.DAL.sr_Calculate2 dal=new ZQUSR.DAL.sr_Calculate2();
		public sr_Calculate2()
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
		public int  Add(ZQUSR.Model.sr_Calculate2 model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZQUSR.Model.sr_Calculate2 model)
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
		public ZQUSR.Model.sr_Calculate2 GetModel(int PK_CID)
		{
			
			return dal.GetModel(PK_CID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZQUSR.Model.sr_Calculate2 GetModelByCache(int PK_CID)
		{
			
			string CacheKey = "sr_Calculate2Model-" + PK_CID;
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
			return (ZQUSR.Model.sr_Calculate2)objModel;
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
		public List<ZQUSR.Model.sr_Calculate2> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZQUSR.Model.sr_Calculate2> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_Calculate2> modelList = new List<ZQUSR.Model.sr_Calculate2>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_Calculate2 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_Calculate2();
					if(dt.Rows[n]["PK_CID"].ToString()!="")
					{
						model.PK_CID=int.Parse(dt.Rows[n]["PK_CID"].ToString());
					}
					if(dt.Rows[n]["Population"].ToString()!="")
					{
						model.Population=int.Parse(dt.Rows[n]["Population"].ToString());
					}
					if(dt.Rows[n]["Rank"].ToString()!="")
					{
						model.Rank=int.Parse(dt.Rows[n]["Rank"].ToString());
					}
					model.ScoreScale=dt.Rows[n]["ScoreScale"].ToString();
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
        /// ���˺��������������������������������򷵻ضԵĵ÷ֱ���    ����By Jianguo Fung
        /// </summary>
        /// <param name="Cal2Model"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Calculate2 GetScoreScale(int population, int rank)
        {
            return dal.GetScoreScale(population, rank);
        }

        /// <summary>
        /// ���������б�   ����By Jianguo Fung
        /// </summary>
        public DataSet GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ���±��� ��By Jianguo Fung
        /// </summary>
        public void UpdateScoreScale(ZQUSR.Model.sr_Calculate2 model)
        {
            dal.UpdateScoreScale(model);
        }
	}
}

