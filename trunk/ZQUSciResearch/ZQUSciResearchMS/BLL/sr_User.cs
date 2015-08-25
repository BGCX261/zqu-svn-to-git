using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ZQUSR.Model;
namespace ZQUSR.BLL
{
    /// <summary>
    /// ҵ���߼���sr_User ��ժҪ˵����
    /// </summary>
    public class sr_User
    {
        private readonly ZQUSR.DAL.sr_User dal = new ZQUSR.DAL.sr_User();
        public sr_User()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string PK_UserID)
        {
            return dal.Exists(PK_UserID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(ZQUSR.Model.sr_User model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ZQUSR.Model.sr_User model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string PK_UserID)
        {

            dal.Delete(PK_UserID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZQUSR.Model.sr_User GetModel(string PK_UserID)
        {

            return dal.GetModel(PK_UserID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
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
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ZQUSR.Model.sr_User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
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

        #region ����һ���û�
        /// <summary>
        /// ����һ���û�
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="PassWord">����</param>,
        //   new SqlParameter("@RoleName", SqlDbType.NVarChar,15)parameters[2].Value = RoleName;
        /// <param name="RoleName">��ɫName</param>
        /// <returns></returns>
        public bool AddUser(string PK_UserID, string PassWord, string FK_RoleID)
        {
            return dal.AddUser(PK_UserID,PassWord,  FK_RoleID);
        }
        #endregion

        #region �޸�һ���û���Ϣ
        /// <summary>
        /// �޸�һ���û���Ϣ
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="PassWord">����</param>,
        //   new SqlParameter("@RoleName", SqlDbType.NVarChar,15)parameters[2].Value = RoleName;
        /// <param name="RoleID">��ɫID</param>
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
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        #region �õ���ɫΪ����ʦ���������б�
        /// <summary>
        /// �õ���ɫΪ����ʦ���������б�
        /// author:liangjinwei
        /// </summary>
        /// <returns></returns>
        public DataSet GetTeachersList()
        {
            return dal.GetTeachersList();
        }
        #endregion

        #region �õ���ɫΪ������Ա���������б�
        /// <summary>
        /// �õ���ɫΪ������Ա���������б�
        /// author:liangjinwei
        /// </summary>
        /// <returns></returns>
        public DataSet GetGuanliyuanList()
        {
            return dal.GetGuanliyuanList();
        }
        #endregion

        #region �õ���ɫΪ��ϵͳ����Ա���������б�
        /// <summary>
        /// �õ���ɫΪ��ϵͳ����Ա���������б�
        /// author:liangjinwei
        /// </summary>
        /// <returns></returns>
        public DataSet GetXitongGuanliyuanList()
        {
            return dal.GetXitongGuanliyuanList();
        }
        #endregion

        #region �õ�ȫ����ɫΪ�������б�
        /// <summary>
        /// �õ�ȫ����ɫΪ�������б�
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

        public DataSet GetXiuGaiUser()//�󶨽�ʦ�����Ա
        {

            return dal.GetXiuGaiUser();
        }

        public DataSet GetXiuGaiUserXiTong()////��ϵͳ����Ա
        {
            return dal.GetXiuGaiUserXiTong();
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����
        #region �����û�������������û��治����
        /// <summary>
        /// �����û�������������û��治����
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="PassWord">����</param>
        /// <param name="RoleName">��ɫName</param>
        /// <returns></returns>
        public bool isExistUser(string UserId, string PassWord, string RoleName)
        {
            return dal.isExistUser(UserId, PassWord, RoleName);
        }
        #endregion

        #region �����û����õ� ��¼״̬���ж��Ƿ���Ե�¼��ȥ 1Ϊ���Խ�ȥ 0Ϊ�����Խ�ȥ
        /// <summary>
        /// �����û����õ� ��¼״̬���ж��Ƿ���Ե�¼��ȥ 1Ϊ���Խ�ȥ 0Ϊ�����Խ�ȥ
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserID">�û�ID</param>
        /// <returns></returns>
        public bool StatusIsTrue(string UserID)
        {
            return dal.StatusIsTrue(UserID);
        }
        #endregion

        #region �����û����õ���¼�Ĵ����������ж��ǲ��ǵ�һ�ε�¼
        /// <summary>
        /// �����û����õ���¼�Ĵ����������ж��ǲ��ǵ�һ�ε�¼
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int GetLogins(string UserID)
        {
            return dal.GetLogins(UserID);
        }
        #endregion

        #region �����û�ID�õ��û���
        /// <summary>
        /// �����û�ID�õ��û���
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserName(string UserID)
        {
            return dal.GetUserName(UserID);
        }
        #endregion

        #region �����û�ID�õ��û�����ѧԺ,����û���Ϊ�� ���ؿ��ַ��� ""
        /// <summary>
        /// �����û�ID�õ��û�����ѧԺ,����û���Ϊ�� ���ؿ��ַ��� ""
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserUnit(string UserID)
        {
            return dal.GetUserUnit(UserID);
        }
        #endregion

        #region �����û�ID�õ��û�����
        /// <summary>
        /// �����û�ID�õ��û�����
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetPassword(string UserID)
        {
            return dal.GetPassword(UserID);

        }
        #endregion

        #region ���µ�¼����
        /// <summary>
        /// ���µ�¼����
        /// author:liangjinwei 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int UpdateLogins(string UserID)
        {
            return dal.UpdateLogins(UserID);
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��������
        /// author:liangjinwei 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool UpdatePassword(string Password, string UserID)
        {
            return dal.UpdatePassword(Password, UserID);
        }
        #endregion

        #region ���¸�����Ϣ
        /// <summary>
        /// ���¸�����Ϣ
        /// author:liangjinwei 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool UpdateGeRenXinXi(string UserName, string Sex, string Unit, string Education, string ZhiCheng, string Telephone, string InOffice, string Email, string UserID)
        {
            return dal.UpdateGeRenXinXi(UserName, Sex, Unit, Education, ZhiCheng, Telephone, InOffice, Email, UserID);
        }
        #endregion

        #region ���ĸ�����Ϣ ��UpdateGeRenXinXi���Ķ���һ����¼״̬�ֶ�DropStatus
        /// <summary>
        /// ���ĸ�����Ϣ ��UpdateGeRenXinXi���Ķ���һ����¼״̬�ֶ�DropStatus
        /// author:liangjinwei 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool ChangeGeRenXinXi(string UserName, string Sex, string Unit, string Education, string ZhiCheng, string Telephone, string InOffice, string Email, string DropStatus, string UserID)
        {
            return dal.ChangeGeRenXinXi(UserName, Sex, Unit, Education, ZhiCheng, Telephone, InOffice, Email, DropStatus,UserID);
        }
        #endregion

        #region ���ظ��ĸ�����Ϣ ��UpdateGeRenXinXi���Ķ���2����¼״̬�ֶ� DropStatus��password
        /// <summary>
        /// ���ظ��ĸ�����Ϣ ��UpdateGeRenXinXi���Ķ���2����¼״̬�ֶ� DropStatus��password
        /// author:liangjinwei 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool ChangeGeRenXinXi(string UserName, string Password, string Sex, string Unit, string Education, string ZhiCheng, string Telephone, string InOffice, string Email, string DropStatus, string UserID)
        {
            return dal.ChangeGeRenXinXi( UserName,  Password,  Sex,  Unit,  Education,  ZhiCheng,  Telephone,  InOffice,  Email,  DropStatus,  UserID);
        }
        #endregion


        #region �����û�ID�����û����ڵ�λ
        /// <summary>
        /// �����û�ID�����û����ڵ�λ   By JianguoFung
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string GetUnitByUserID(string userID)
        {
            return dal.GetUnitByUserID(userID);
        } 
        #endregion

        #region ��Ϣ���͡�������ѧԺ�б�
        /// <summary>
        /// ��Ϣ���͡�������ѧԺ�б�    ����By dancy   
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetXueYuan()
        {
            return dal.GetXueYuan();
        }
        #endregion

        #region ��Ϣ���͡�������ѧԺ���ؽ�ʦ�����б�
        /// <summary>
        /// ��Ϣ���͡�������ѧԺ���ؽ�ʦ�����б�    ����By dancy   
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetNameByXueyuan(string Xueyuan)
        {
            return dal.GetNameByXueyuan(Xueyuan);
        }
        #endregion

        #region �����û�������������û��治����
        /// <summary>
        /// ��Ϣ���͡��������û�����ѧԺ���ؽ�ʦID   ����By dancy   
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="PassWord">ѧԺ</param>
        /// <returns>UserID</returns>
        public string isExistUser(string UserName, string Unit)
        {
            return dal.isExistUser(UserName, Unit);
        }
        #endregion
    }
}

