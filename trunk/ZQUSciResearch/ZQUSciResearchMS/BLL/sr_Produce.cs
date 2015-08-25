using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// 业务逻辑类sr_Produce 的摘要说明。
	/// </summary>
	public class sr_Produce
	{
		private readonly ZQUSR.DAL.sr_Produce dal=new ZQUSR.DAL.sr_Produce();
		public sr_Produce()
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
		public bool Exists(int PK_PID)
		{
			return dal.Exists(PK_PID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZQUSR.Model.sr_Produce model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_Produce model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_PID)
		{
			
			dal.Delete(PK_PID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_Produce GetModel(int PK_PID)
		{
			
			return dal.GetModel(PK_PID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
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
		public List<ZQUSR.Model.sr_Produce> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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


        #region 创作类成果：返回学科列表
        /// <summary>
        /// 创作类成果：返回学科列表    ——By Jianguo Fung   
        /// </summary>
        /// <returns></returns>
        public DataSet GetXueKe()
        {
            return dal.GetXueKe();
        } 
        #endregion

        #region 创作类成果：根据学科返回发表刊物来源
        /// <summary>
        /// 创作类成果：根据学科返回发表刊物来源    ——By Jianguo Fung
        /// </summary>
        /// <param name="Xueke"></param>
        /// <returns></returns>
        public DataSet GetSourceByXueke(string Xueke)
        {
            return dal.GetSourceByXueke(Xueke);
        } 
        #endregion

        #region 创作类成果：返回级别和级别分系数
        /// <summary>
        /// 创作类成果：根据发表刊物名称/来源（Source）返回级别和级别分系数     ——By Jianguo Fung
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public ZQUSR.Model.sr_Produce GetJiBieBySource(string Source)
        {
            return dal.GetJiBieBySource(Source);
        } 
        #endregion

        #region 返回数据列表
        /// <summary>
        /// 返回数据列表   ——By Jianguo Fung
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            return dal.GetData();
        }
        #endregion

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录（XueKe/Source）－By Jianguo Fung
        /// </summary>
        public bool Exists(ZQUSR.Model.sr_Produce model)
        {
            return dal.Exists(model);
        }
        #endregion

        #region 更新级别和级别分系数（评定标准）
        /// <summary>
        /// 更新级别和级别分系数（评定标准）－By Jianguo Fung
        /// </summary>
        public void UpdateJiBie(ZQUSR.Model.sr_Produce model)
        {
            dal.UpdateJiBie(model);
        }
        #endregion
	}
}

