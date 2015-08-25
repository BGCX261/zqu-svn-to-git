using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
    /// <summary>
    /// 业务逻辑类sr_User 的摘要说明。
    /// </summary>
    public class sr_User
    {
        private readonly ZQUSR.DAL.sr_User dal = new ZQUSR.DAL.sr_User();
        public sr_User()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PK_UserID)
        {
            return dal.Exists(PK_UserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ZQUSR.Model.sr_User model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ZQUSR.Model.sr_User model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string PK_UserID)
        {

            dal.Delete(PK_UserID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZQUSR.Model.sr_User GetModel(string PK_UserID)
        {

            return dal.GetModel(PK_UserID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public ZQUSR.Model.sr_User GetModelByCache(string PK_UserID)
        {

            string CacheKey = "sr_UserModel-" + PK_UserID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(PK_UserID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZQUSR.Model.sr_User)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZQUSR.Model.sr_User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ZQUSR.Model.sr_User> DataTableToList(DataTable dt)
        {
            List<ZQUSR.Model.sr_User> modelList = new List<ZQUSR.Model.sr_User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZQUSR.Model.sr_User model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ZQUSR.Model.sr_User();
                    model.PK_UserID = dt.Rows[n]["PK_UserID"].ToString();
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.Password = dt.Rows[n]["Password"].ToString();
                    model.Sex = dt.Rows[n]["Sex"].ToString();
                    model.Unit = dt.Rows[n]["Unit"].ToString();
                    model.Education = dt.Rows[n]["Education"].ToString();
                    model.ZhiCheng = dt.Rows[n]["ZhiCheng"].ToString();
                    model.Telephone = dt.Rows[n]["Telephone"].ToString();
                    if (dt.Rows[n]["InOffice"].ToString() != "")
                    {
                        model.InOffice = int.Parse(dt.Rows[n]["InOffice"].ToString());
                    }
                    model.Email = dt.Rows[n]["Email"].ToString();
                    if (dt.Rows[n]["Logins"].ToString() != "")
                    {
                        model.Logins = int.Parse(dt.Rows[n]["Logins"].ToString());
                    }
                    if (dt.Rows[n]["LastLogin"].ToString() != "")
                    {
                        model.LastLogin = DateTime.Parse(dt.Rows[n]["LastLogin"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    model.Extra1 = dt.Rows[n]["Extra1"].ToString();
                    model.Extra2 = dt.Rows[n]["Extra2"].ToString();
                    model.Extra3 = dt.Rows[n]["Extra3"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #region 增加一个用户
        /// <summary>
        /// 增加一个用户
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="PassWord">密码</param>,
        //   new SqlParameter("@RoleName", SqlDbType.NVarChar,15)parameters[2].Value = RoleName;
        /// <param name="RoleName">角色Name</param>
        /// <returns></returns>
        public bool AddUser(string PK_UserID, string PassWord, string FK_RoleID)
        {
            return dal.AddUser(PK_UserID,PassWord,  FK_RoleID);
        }
        #endregion

        #region 修改一条用户信息
        /// <summary>
        /// 修改一条用户信息
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="PassWord">密码</param>,
        //   new SqlParameter("@RoleName", SqlDbType.NVarChar,15)parameters[2].Value = RoleName;
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public bool UpdateIDPwd(string PK_UserID, string Password, string FK_RoleID, string OldID)
        {
            return dal.UpdateIDPwd(PK_UserID,  Password,  FK_RoleID,  OldID);
        }
        #endregion

        public bool UpdateIDPwd(string PK_UserID, string FK_RoleID, string OldID)
        {
            return dal.UpdateIDPwd(PK_UserID, FK_RoleID, OldID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        #region 得到角色为‘老师’的数据列表
        /// <summary>
        /// 得到角色为‘老师’的数据列表
        /// author:liangjinwei
        /// </summary>
        /// <returns></returns>
        public DataSet GetTeachersList()
        {
            return dal.GetTeachersList();
        }
        #endregion

        #region 得到角色为‘管理员’的数据列表
        /// <summary>
        /// 得到角色为‘管理员’的数据列表
        /// author:liangjinwei
        /// </summary>
        /// <returns></returns>
        public DataSet GetGuanliyuanList()
        {
            return dal.GetGuanliyuanList();
        }
        #endregion

        #region 得到角色为‘系统管理员’的数据列表
        /// <summary>
        /// 得到角色为‘系统管理员’的数据列表
        /// author:liangjinwei
        /// </summary>
        /// <returns></returns>
        public DataSet GetXitongGuanliyuanList()
        {
            return dal.GetXitongGuanliyuanList();
        }
        #endregion

        #region 得到全部角色为的数据列表
        /// <summary>
        /// 得到全部角色为的数据列表
        /// author:liangjinwei
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllRoseList()
        {
            return dal.GetAllRoseList();
        }
        #endregion

        public DataSet GetFeipeiUser()
        {
            return dal.GetFeipeiUser();
        }
        public DataSet GetFeipeiUserXiTong()
        {
            return dal.GetFeipeiUserXiTong();
        }

        public DataSet GetXiuGaiUser()//绑定教师或管理员
        {

            return dal.GetXiuGaiUser();
        }

        public DataSet GetXiuGaiUserXiTong()////绑定系统管理员
        {
            return dal.GetXiuGaiUserXiTong();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
        #region 根据用户名和密码查找用户存不存在
        /// <summary>
        /// 根据用户名和密码查找用户存不存在
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="PassWord">密码</param>
        /// <param name="RoleName">角色Name</param>
        /// <returns></returns>
        public bool isExistUser(string UserId, string PassWord, string RoleName)
        {
            return dal.isExistUser(UserId, PassWord, RoleName);
        }
        #endregion

        #region 根据用户名得到 登录状态，判断是否可以登录进去 1为可以进去 0为不可以进去
        /// <summary>
        /// 根据用户名得到 登录状态，判断是否可以登录进去 1为可以进去 0为不可以进去
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        public bool StatusIsTrue(string UserID)
        {
            return dal.StatusIsTrue(UserID);
        }
        #endregion

        #region 根据用户名得到登录的次数，用来判断是不是第一次登录
        /// <summary>
        /// 根据用户名得到登录的次数，用来判断是不是第一次登录
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int GetLogins(string UserID)
        {
            return dal.GetLogins(UserID);
        }
        #endregion

        #region 根据用户ID得到用户名
        /// <summary>
        /// 根据用户ID得到用户名
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserName(string UserID)
        {
            return dal.GetUserName(UserID);
        }
        #endregion

        #region 根据用户ID得到用户所在学院,如果用户名为空 返回空字符串 ""
        /// <summary>
        /// 根据用户ID得到用户所在学院,如果用户名为空 返回空字符串 ""
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserUnit(string UserID)
        {
            return dal.GetUserUnit(UserID);
        }
        #endregion

        #region 根据用户ID得到用户密码
        /// <summary>
        /// 根据用户ID得到用户密码
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetPassword(string UserID)
        {
            return dal.GetPassword(UserID);

        }
        #endregion

        #region 更新登录次数
        /// <summary>
        /// 更新登录次数
        /// author:liangjinwei 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int UpdateLogins(string UserID)
        {
            return dal.UpdateLogins(UserID);
        }
        #endregion

        #region 更新密码
        /// <summary>
        /// 更新密码
        /// author:liangjinwei 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool UpdatePassword(string Password, string UserID)
        {
            return dal.UpdatePassword(Password, UserID);
        }
        #endregion

        #region 更新个人信息
        /// <summary>
        /// 更新个人信息
        /// author:liangjinwei 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool UpdateGeRenXinXi(string UserName, string Sex, string Unit, string Education, string ZhiCheng, string Telephone, string InOffice, string Email, string UserID)
        {
            return dal.UpdateGeRenXinXi(UserName, Sex, Unit, Education, ZhiCheng, Telephone, InOffice, Email, UserID);
        }
        #endregion

        #region 更改个人信息 比UpdateGeRenXinXi更改多了一个登录状态字段DropStatus
        /// <summary>
        /// 更改个人信息 比UpdateGeRenXinXi更改多了一个登录状态字段DropStatus
        /// author:liangjinwei 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool ChangeGeRenXinXi(string UserName, string Sex, string Unit, string Education, string ZhiCheng, string Telephone, string InOffice, string Email, string DropStatus, string UserID)
        {
            return dal.ChangeGeRenXinXi(UserName, Sex, Unit, Education, ZhiCheng, Telephone, InOffice, Email, DropStatus,UserID);
        }
        #endregion

        #region 重载更改个人信息 比UpdateGeRenXinXi更改多了2个登录状态字段 DropStatus、password
        /// <summary>
        /// 重载更改个人信息 比UpdateGeRenXinXi更改多了2个登录状态字段 DropStatus、password
        /// author:liangjinwei 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool ChangeGeRenXinXi(string UserName, string Password, string Sex, string Unit, string Education, string ZhiCheng, string Telephone, string InOffice, string Email, string DropStatus, string UserID)
        {
            return dal.ChangeGeRenXinXi( UserName,  Password,  Sex,  Unit,  Education,  ZhiCheng,  Telephone,  InOffice,  Email,  DropStatus,  UserID);
        }
        #endregion


        #region 根据用户ID返回用户所在单位
        /// <summary>
        /// 根据用户ID返回用户所在单位   By JianguoFung
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string GetUnitByUserID(string userID)
        {
            return dal.GetUnitByUserID(userID);
        } 
        #endregion

        #region 消息发送——返回学院列表
        /// <summary>
        /// 消息发送——返回学院列表    ——By dancy   
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetXueYuan()
        {
            return dal.GetXueYuan();
        }
        #endregion

        #region 消息发送——根据学院返回教师姓名列表
        /// <summary>
        /// 消息发送——根据学院返回教师姓名列表    ——By dancy   
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetNameByXueyuan(string Xueyuan)
        {
            return dal.GetNameByXueyuan(Xueyuan);
        }
        #endregion

        #region 根据用户名和密码查找用户存不存在
        /// <summary>
        /// 消息发送——根据用户名与学院返回教师ID   ——By dancy   
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="PassWord">学院</param>
        /// <returns>UserID</returns>
        public string isExistUser(string UserName, string Unit)
        {
            return dal.isExistUser(UserName, Unit);
        }
        #endregion
    }
}

