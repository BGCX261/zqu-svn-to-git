using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// ҵ���߼���sr_Lunwen ��ժҪ˵����
	/// </summary>
	public class sr_Lunwen
	{
		private readonly ZQUSR.DAL.sr_Lunwen dal=new ZQUSR.DAL.sr_Lunwen();
		public sr_Lunwen()
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
		public bool Exists(int PK_LID)
		{
			return dal.Exists(PK_LID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(ZQUSR.Model.sr_Lunwen model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ZQUSR.Model.sr_Lunwen model)
		{
			dal.Update(model);
		}


		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PK_LID)
		{
			
			dal.Delete(PK_LID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ZQUSR.Model.sr_Lunwen GetModel(int PK_LID)
		{
			
			return dal.GetModel(PK_LID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ZQUSR.Model.sr_Lunwen GetModelByCache(int PK_LID)
		{
			
			string CacheKey = "sr_LunwenModel-" + PK_LID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PK_LID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ZQUSR.Model.sr_Lunwen)objModel;
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
		public List<ZQUSR.Model.sr_Lunwen> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ZQUSR.Model.sr_Lunwen> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_Lunwen> modelList = new List<ZQUSR.Model.sr_Lunwen>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_Lunwen model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_Lunwen();
					if(dt.Rows[n]["PK_LID"].ToString()!="")
					{
						model.PK_LID=int.Parse(dt.Rows[n]["PK_LID"].ToString());
					}
					model.Type=dt.Rows[n]["Type"].ToString();
					model.Situation=dt.Rows[n]["Situation"].ToString();
					if(dt.Rows[n]["Factor1"].ToString()!="")
					{
						model.Factor1=decimal.Parse(dt.Rows[n]["Factor1"].ToString());
                        //model.Factor1 = dt.Rows[n]["Factor1"].ToString();     //--by caiyuying
					}
					if(dt.Rows[n]["Factor2"].ToString()!="")
					{
						model.Factor2=decimal.Parse(dt.Rows[n]["Factor2"].ToString());
                        //model.Factor2 = dt.Rows[n]["Factor2"].ToString();      //--by caiyuying
					}
					model.JiBie=dt.Rows[n]["JiBie"].ToString();
					if(dt.Rows[n]["LevelFactor"].ToString()!="")
					{
						model.LevelFactor=decimal.Parse(dt.Rows[n]["LevelFactor"].ToString());
                        //model.LevelFactor = dt.Rows[n]["LevelFactor"].ToString();     //--by caiyuying
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


        #region �����¼/ת��������󶨵���������
        /// <summary>
        /// �����¼/ת��������󶨵���������  ����By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetSituation()
        {
            return dal.GetSituation();
        } 
        #endregion

        #region ����Ӱ������(QIF)���ؼ���(JiBie)�ͼ����ϵ��(LevelFactor)
        /// <summary>
        /// ����Ӱ������(QIF)���ؼ���(JiBie)�ͼ����ϵ��(LevelFactor)   ��By Jianguo Fung
        /// </summary>
        public ZQUSR.Model.sr_Lunwen GetJiBieByQIF(decimal QIF)
        {
            return dal.GetJiBieByQIF(QIF);
        } 
        #endregion

        #region ������¼ת�����(Sitution)���ؼ���(JiBie)�ͼ����ϵ��(LevelFactor)
        /// <summary>
        /// ������¼ת�����(Sitution)���ؼ���(JiBie)�ͼ����ϵ��(LevelFactor)   ��By Jianguo Fung
        /// </summary>
        public ZQUSR.Model.sr_Lunwen GetJiBieBySitution(string Situation)
        {
            return dal.GetJiBieBySitution(Situation);
        } 
        #endregion

        #region ���������б�
        /// <summary>
        /// ���������б�  ��By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            return dal.GetData();
        }
        #endregion

        #region ���¼���ͼ����ϵ��
        /// <summary>
        /// ���¼���ͼ����ϵ�� ��By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateJiBie(ZQUSR.Model.sr_Lunwen model)
        {
            dal.UpdateJiBie(model);
        }
        #endregion

        #region �Ƿ���ڸü�¼
        /// <summary>
        /// �Ƿ���ڸü�¼��Type/Situation����By Jianguo Fung
        /// </summary>
        public bool Exists(ZQUSR.Model.sr_Lunwen model)
        {
            return dal.Exists(model);
        }
        #endregion
	}
}

