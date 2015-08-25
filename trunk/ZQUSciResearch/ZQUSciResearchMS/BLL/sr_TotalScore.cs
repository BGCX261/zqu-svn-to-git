using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// ҵ���߼���sr_TotalScore ��ժҪ˵����
	/// </summary>
	public class sr_TotalScore
	{
		private readonly ZQUSR.DAL.sr_TotalScore dal=new ZQUSR.DAL.sr_TotalScore();
		public sr_TotalScore()
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
		public bool Exists(int PK_TID)
		{
			return dal.Exists(PK_TID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZQUSR.Model.sr_TotalScore model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZQUSR.Model.sr_TotalScore model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PK_TID)
		{
			
			dal.Delete(PK_TID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZQUSR.Model.sr_TotalScore GetModel(int PK_TID)
		{
			
			return dal.GetModel(PK_TID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZQUSR.Model.sr_TotalScore GetModelByCache(int PK_TID)
		{
			
			string CacheKey = "sr_TotalScoreModel-" + PK_TID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_TID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_TotalScore)objModel;
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
		public List<ZQUSR.Model.sr_TotalScore> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZQUSR.Model.sr_TotalScore> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_TotalScore> modelList = new List<ZQUSR.Model.sr_TotalScore>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_TotalScore model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_TotalScore();
					if(dt.Rows[n]["PK_TID"].ToString()!="")
					{
						model.PK_TID=int.Parse(dt.Rows[n]["PK_TID"].ToString());
					}
					model.FK_UserID=dt.Rows[n]["FK_UserID"].ToString();
					model.Year=dt.Rows[n]["Year"].ToString();
					if(dt.Rows[n]["TotalScore"].ToString()!="")
					{
						model.TotalScore=decimal.Parse(dt.Rows[n]["TotalScore"].ToString());
					}
					if(dt.Rows[n]["TotalRewards"].ToString()!="")
					{
						model.TotalRewards=decimal.Parse(dt.Rows[n]["TotalRewards"].ToString());
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
	}
}

