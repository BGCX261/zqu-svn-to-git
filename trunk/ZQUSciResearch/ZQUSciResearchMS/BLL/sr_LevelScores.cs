using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// ҵ���߼���sr_LevelScores ��ժҪ˵����
	/// </summary>
	public class sr_LevelScores
	{
		private readonly ZQUSR.DAL.sr_LevelScores dal=new ZQUSR.DAL.sr_LevelScores();
		public sr_LevelScores()
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
		public bool Exists(int PK_ID)
		{
			return dal.Exists(PK_ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZQUSR.Model.sr_LevelScores model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZQUSR.Model.sr_LevelScores model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PK_ID)
		{
			
			dal.Delete(PK_ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZQUSR.Model.sr_LevelScores GetModel(int PK_ID)
		{
			
			return dal.GetModel(PK_ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZQUSR.Model.sr_LevelScores GetModelByCache(int PK_ID)
		{
			
			string CacheKey = "sr_LevelScoresModel-" + PK_ID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_ID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_LevelScores)objModel;
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
		public List<ZQUSR.Model.sr_LevelScores> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZQUSR.Model.sr_LevelScores> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_LevelScores> modelList = new List<ZQUSR.Model.sr_LevelScores>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_LevelScores model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_LevelScores();
					if(dt.Rows[n]["PK_ID"].ToString()!="")
					{
						model.PK_ID=int.Parse(dt.Rows[n]["PK_ID"].ToString());
					}
					model.JiBie=dt.Rows[n]["JiBie"].ToString();
					if(dt.Rows[n]["Score"].ToString()!="")
					{
						model.Score=int.Parse(dt.Rows[n]["Score"].ToString());
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
        /// ���ݼ��𷵻ض�Ӧ�ļ����    ����By Jianguo Fung
        /// </summary>
        /// <param name="JiBie"></param>
        /// <returns></returns>
        public int GetScoreByJiBie(string JiBie)
        {
            return dal.GetScoreByJiBie(JiBie);
        }

        /// <summary>
        /// ���������б�   ����By Jianguo Fung
        /// </summary>
        public DataSet GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ���¼������
        /// </summary>
        public void UpdateScore(ZQUSR.Model.sr_LevelScores model)
        {
            dal.UpdateScore(model);
        }
	}
}

