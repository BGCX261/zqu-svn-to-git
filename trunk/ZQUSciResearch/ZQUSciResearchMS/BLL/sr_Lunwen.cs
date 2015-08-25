using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// 业务逻辑类sr_Lunwen 的摘要说明。
	/// </summary>
	public class sr_Lunwen
	{
		private readonly ZQUSR.DAL.sr_Lunwen dal=new ZQUSR.DAL.sr_Lunwen();
		public sr_Lunwen()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PK_LID)
		{
			return dal.Exists(PK_LID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZQUSR.Model.sr_Lunwen model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_Lunwen model)
		{
			dal.Update(model);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_LID)
		{
			
			dal.Delete(PK_LID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Lunwen GetModel(int PK_LID)
		{
			
			return dal.GetModel(PK_LID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZQUSR.Model.sr_Lunwen> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法


        #region 获得收录/转载情况，绑定到下拉框中
        /// <summary>
        /// 获得收录/转载情况，绑定到下拉框中  ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetSituation()
        {
            return dal.GetSituation();
        } 
        #endregion

        #region 根据影响因子(QIF)返回级别(JiBie)和级别分系数(LevelFactor)
        /// <summary>
        /// 根据影响因子(QIF)返回级别(JiBie)和级别分系数(LevelFactor)   －By Jianguo Fung
        /// </summary>
        public ZQUSR.Model.sr_Lunwen GetJiBieByQIF(decimal QIF)
        {
            return dal.GetJiBieByQIF(QIF);
        } 
        #endregion

        #region 根据收录转载情况(Sitution)返回级别(JiBie)和级别分系数(LevelFactor)
        /// <summary>
        /// 根据收录转载情况(Sitution)返回级别(JiBie)和级别分系数(LevelFactor)   －By Jianguo Fung
        /// </summary>
        public ZQUSR.Model.sr_Lunwen GetJiBieBySitution(string Situation)
        {
            return dal.GetJiBieBySitution(Situation);
        } 
        #endregion

        #region 返回数据列表
        /// <summary>
        /// 返回数据列表  －By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            return dal.GetData();
        }
        #endregion

        #region 更新级别和级别分系数
        /// <summary>
        /// 更新级别和级别分系数 －By Jianguo Fung
        /// </summary>
        /// <param name="model"></param>
        public void UpdateJiBie(ZQUSR.Model.sr_Lunwen model)
        {
            dal.UpdateJiBie(model);
        }
        #endregion

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录（Type/Situation）－By Jianguo Fung
        /// </summary>
        public bool Exists(ZQUSR.Model.sr_Lunwen model)
        {
            return dal.Exists(model);
        }
        #endregion
	}
}

