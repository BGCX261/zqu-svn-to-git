using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
	/// <summary>
	/// 业务逻辑类sr_UserRole 的摘要说明。
	/// </summary>
	public class sr_UserRole
	{
		private readonly ZQUSR.DAL.sr_UserRole dal=new ZQUSR.DAL.sr_UserRole();
		public sr_UserRole()
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
		public bool Exists(int PK_ID)
		{
			return dal.Exists(PK_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ZQUSR.Model.sr_UserRole model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ZQUSR.Model.sr_UserRole model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PK_ID)
		{
			
			dal.Delete(PK_ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ZQUSR.Model.sr_UserRole GetModel(int PK_ID)
		{
			
			return dal.GetModel(PK_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ZQUSR.Model.sr_UserRole GetModelByCache(int PK_ID)
		{
			
			string CacheKey = "sr_UserRoleModel-" + PK_ID;
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
			return (ZQUSR.Model.sr_UserRole)objModel;
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
		public List<ZQUSR.Model.sr_UserRole> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ZQUSR.Model.sr_UserRole> DataTableToList(DataTable dt)
		{
			List<ZQUSR.Model.sr_UserRole> modelList = new List<ZQUSR.Model.sr_UserRole>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ZQUSR.Model.sr_UserRole model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ZQUSR.Model.sr_UserRole();
					if(dt.Rows[n]["PK_ID"].ToString()!="")
					{
						model.PK_ID=int.Parse(dt.Rows[n]["PK_ID"].ToString());
					}
					model.FK_RoleID=dt.Rows[n]["FK_RoleID"].ToString();
					model.FK_UserID=dt.Rows[n]["FK_UserID"].ToString();
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
	}
}

