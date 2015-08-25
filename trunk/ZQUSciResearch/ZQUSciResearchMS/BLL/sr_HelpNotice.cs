using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// ҵ���߼���sr_HelpNotice ��ժҪ˵����
	/// </summary>
	public class sr_HelpNotice
	{
		private readonly ZQUSR.DAL.sr_HelpNotice dal=new ZQUSR.DAL.sr_HelpNotice();
		public sr_HelpNotice()
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
		public bool Exists(int PK_HNID)
		{
			return dal.Exists(PK_HNID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZQUSR.Model.sr_HelpNotice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZQUSR.Model.sr_HelpNotice model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PK_HNID)
		{
			
			dal.Delete(PK_HNID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZQUSR.Model.sr_HelpNotice GetModel(int PK_HNID)
		{
			
			return dal.GetModel(PK_HNID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZQUSR.Model.sr_HelpNotice GetModelByCache(int PK_HNID)
		{
			
			string CacheKey = "sr_HelpNoticeModel-" + PK_HNID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_HNID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_HelpNotice)objModel;
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
		public List<ZQUSR.Model.sr_HelpNotice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZQUSR.Model.sr_HelpNotice> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_HelpNotice> modelList = new List<ZQUSR.Model.sr_HelpNotice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_HelpNotice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_HelpNotice();
					if(dt.Rows[n]["PK_HNID"].ToString()!="")
					{
						model.PK_HNID=int.Parse(dt.Rows[n]["PK_HNID"].ToString());
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.FK_UserID=dt.Rows[n]["FK_UserID"].ToString();
					if(dt.Rows[n]["AddTime"].ToString()!="")
					{
						model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
					}
					model.NotContent=dt.Rows[n]["NotContent"].ToString();
					if(dt.Rows[n]["Type"].ToString()!="")
					{
						model.Type=int.Parse(dt.Rows[n]["Type"].ToString());
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
	}
}

