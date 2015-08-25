using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
using System.Collections;

namespace ZQUSR.DAL
{
    /// <summary>
    /// 数据访问类sr_User。
    /// </summary>
    public class sr_User
    {
        public sr_User()
        { }
        #region  成员方法
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PK_UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sr_User");
            strSql.Append(" where PK_UserID=@PK_UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_UserID", SqlDbType.NVarChar,50)};
            parameters[0].Value = PK_UserID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ZQUSR.Model.sr_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sr_User(");
            strSql.Append("PK_UserID,UserName,Password,Sex,Unit,Education,ZhiCheng,Telephone,InOffice,Email,Logins,LastLogin,Status,Extra1,Extra2,Extra3)");
            strSql.Append(" values (");
            strSql.Append("@PK_UserID,@UserName,@Password,@Sex,@Unit,@Education,@ZhiCheng,@Telephone,@InOffice,@Email,@Logins,@LastLogin,@Status,@Extra1,@Extra2,@Extra3)");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_UserID", SqlDbType.NVarChar,10),
					new SqlParameter("@UserName", SqlDbType.NVarChar,10),
					new SqlParameter("@Password", SqlDbType.NVarChar,32),
					new SqlParameter("@Sex", SqlDbType.Char,2),
					new SqlParameter("@Unit", SqlDbType.NVarChar,20),
					new SqlParameter("@Education", SqlDbType.NVarChar,10),
					new SqlParameter("@ZhiCheng", SqlDbType.NVarChar,10),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,15),
					new SqlParameter("@InOffice", SqlDbType.TinyInt,1),
					new SqlParameter("@Email", SqlDbType.NVarChar,30),
					new SqlParameter("@Logins", SqlDbType.Int,4),
					new SqlParameter("@LastLogin", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra3", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.PK_UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Unit;
            parameters[5].Value = model.Education;
            parameters[6].Value = model.ZhiCheng;
            parameters[7].Value = model.Telephone;
            parameters[8].Value = model.InOffice;
            parameters[9].Value = model.Email;
            parameters[10].Value = model.Logins;
            parameters[11].Value = model.LastLogin;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.Extra1;
            parameters[14].Value = model.Extra2;
            parameters[15].Value = model.Extra3;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ZQUSR.Model.sr_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_User set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("Education=@Education,");
            strSql.Append("ZhiCheng=@ZhiCheng,");
            strSql.Append("Telephone=@Telephone,");
            strSql.Append("InOffice=@InOffice,");
            strSql.Append("Email=@Email,");
            strSql.Append("Logins=@Logins,");
            strSql.Append("LastLogin=@LastLogin,");
            strSql.Append("Status=@Status,");
            strSql.Append("Extra1=@Extra1,");
            strSql.Append("Extra2=@Extra2,");
            strSql.Append("Extra3=@Extra3");
            strSql.Append(" where PK_UserID=@PK_UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_UserID", SqlDbType.NVarChar,10),
					new SqlParameter("@UserName", SqlDbType.NVarChar,10),
					new SqlParameter("@Password", SqlDbType.NVarChar,32),
					new SqlParameter("@Sex", SqlDbType.Char,2),
					new SqlParameter("@Unit", SqlDbType.NVarChar,20),
					new SqlParameter("@Education", SqlDbType.NVarChar,10),
					new SqlParameter("@ZhiCheng", SqlDbType.NVarChar,10),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,15),
					new SqlParameter("@InOffice", SqlDbType.TinyInt,1),
					new SqlParameter("@Email", SqlDbType.NVarChar,30),
					new SqlParameter("@Logins", SqlDbType.Int,4),
					new SqlParameter("@LastLogin", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Extra1", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra2", SqlDbType.NVarChar,10),
					new SqlParameter("@Extra3", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.PK_UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Unit;
            parameters[5].Value = model.Education;
            parameters[6].Value = model.ZhiCheng;
            parameters[7].Value = model.Telephone;
            parameters[8].Value = model.InOffice;
            parameters[9].Value = model.Email;
            parameters[10].Value = model.Logins;
            parameters[11].Value = model.LastLogin;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.Extra1;
            parameters[14].Value = model.Extra2;
            parameters[15].Value = model.Extra3;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string PK_UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sr_User ");
            strSql.Append(" where PK_UserID=@PK_UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_UserID", SqlDbType.NVarChar,50)};
            parameters[0].Value = PK_UserID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZQUSR.Model.sr_User GetModel(string PK_UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PK_UserID,UserName,Password,Sex,Unit,Education,ZhiCheng,Telephone,InOffice,Email,Logins,LastLogin,Status,Extra1,Extra2,Extra3 from sr_User ");
            strSql.Append(" where PK_UserID=@PK_UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PK_UserID", SqlDbType.NVarChar,50)};
            parameters[0].Value = PK_UserID;

            ZQUSR.Model.sr_User model = new ZQUSR.Model.sr_User();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.PK_UserID = ds.Tables[0].Rows[0]["PK_UserID"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                model.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();
                model.Education = ds.Tables[0].Rows[0]["Education"].ToString();
                model.ZhiCheng = ds.Tables[0].Rows[0]["ZhiCheng"].ToString();
                model.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                if (ds.Tables[0].Rows[0]["InOffice"].ToString() != "")
                {
                    model.InOffice = int.Parse(ds.Tables[0].Rows[0]["InOffice"].ToString());
                }
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["Logins"].ToString() != "")
                {
                    model.Logins = int.Parse(ds.Tables[0].Rows[0]["Logins"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLogin"].ToString() != "")
                {
                    model.LastLogin = DateTime.Parse(ds.Tables[0].Rows[0]["LastLogin"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                model.Extra1 = ds.Tables[0].Rows[0]["Extra1"].ToString();
                model.Extra2 = ds.Tables[0].Rows[0]["Extra2"].ToString();
                model.Extra3 = ds.Tables[0].Rows[0]["Extra3"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #region 增加一个用户
        /// <summary>
        /// 增加一个用户
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="PassWord">密码</param>,
        //   new SqlParameter("@RoleName", SqlDbType.NVarChar,15)parameters[2].Value = RoleName;
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public bool AddUser(string PK_UserID, string Password, string FK_RoleID)
        {
            Hashtable strSH = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
                            Insert into sr_User(PK_UserID,Password)  
                            values(@PK_UserID,@Password)

                            Insert into sr_UserRole(FK_RoleID,FK_UserID)  
                            values(@FK_RoleID,@PK_UserID)
                        ");

            SqlParameter[] param = { 
                                    new SqlParameter("@PK_UserID",SqlDbType.NVarChar,10),
                                    new SqlParameter("@Password",SqlDbType.NVarChar,32),
                                    new SqlParameter("@FK_RoleID",SqlDbType.NVarChar,10)
                                 };
            param[0].Value = PK_UserID;
            param[1].Value = Password;
            param[2].Value = FK_RoleID;

            strSH.Add(strSql.ToString(), param);

          return    DbHelperSQL.ExecuteSqlTran(strSH);
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
        public bool UpdateIDPwd(string PK_UserID, string Password, string FK_RoleID,string OldID)
        {
            Hashtable strSH = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
                            Insert into sr_User(PK_UserID,Password)  
                            values(@PK_UserID,@Password)

                            Insert into sr_UserRole(FK_RoleID,FK_UserID)  
                            values(@FK_RoleID,@PK_UserID)
                
                            delete from sr_User where PK_UserID=@OldID
                        ");

            SqlParameter[] param = { 
                                    new SqlParameter("@PK_UserID",SqlDbType.NVarChar,10),
                                    new SqlParameter("@Password",SqlDbType.NVarChar,32),
                                    new SqlParameter("@FK_RoleID",SqlDbType.NVarChar,10),
                                    new SqlParameter("@OldID",SqlDbType.NVarChar,10)

                                 };
            param[0].Value = PK_UserID;
            param[1].Value = Password;
            param[2].Value = FK_RoleID;
            param[3].Value = OldID;

            strSH.Add(strSql.ToString(), param);

            return DbHelperSQL.ExecuteSqlTran(strSH);
        }
        #endregion

        public bool UpdateIDPwd(string PK_UserID, string FK_RoleID, string OldID)
        {
            Hashtable strSH = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
                            Insert into sr_User(PK_UserID)  
                            values(@PK_UserID)

                            Insert into sr_UserRole(FK_RoleID,FK_UserID)  
                            values(@FK_RoleID,@PK_UserID)
                
                            delete from sr_User where PK_UserID=@OldID
                        ");

            SqlParameter[] param = { 
                                    new SqlParameter("@PK_UserID",SqlDbType.NVarChar,10),
                                    new SqlParameter("@FK_RoleID",SqlDbType.NVarChar,10),
                                    new SqlParameter("@OldID",SqlDbType.NVarChar,10)

                                 };
            param[0].Value = PK_UserID;
            param[1].Value = FK_RoleID;
            param[2].Value = OldID;

            strSH.Add(strSql.ToString(), param);

            return DbHelperSQL.ExecuteSqlTran(strSH);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PK_UserID,UserName,Sex,Unit,Education,ZhiCheng,Telephone,InOffice,Email,Logins ");
            strSql.Append(" FROM sr_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #region 得到角色为‘老师’的数据列表
        /// <summary>
        /// 得到角色为‘老师’的数据列表
        /// author:liangjinwei
        /// </summary>
        /// <returns></returns>
        public DataSet GetTeachersList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM dbo.sr_UserRole INNER JOIN dbo.sr_User ON dbo.sr_UserRole.FK_UserID = dbo.sr_User.PK_UserID INNER JOIN dbo.sr_Roles ON dbo.sr_UserRole.FK_RoleID = dbo.sr_Roles.PK_RoleID WHERE dbo.sr_Roles.RoleName = '教师'");

            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 得到角色为‘管理员’的数据列表
        /// <summary>
        /// 得到角色为‘管理员’的数据列表
        /// author:liangjinwei
        /// </summary>PK_UserID,UserName,Sex,Unit,Education,ZhiCheng,Telephone,InOffice,Email,Logins
        /// <returns></returns>
        public DataSet GetGuanliyuanList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM dbo.sr_UserRole INNER JOIN dbo.sr_User ON dbo.sr_UserRole.FK_UserID = dbo.sr_User.PK_UserID INNER JOIN dbo.sr_Roles ON dbo.sr_UserRole.FK_RoleID = dbo.sr_Roles.PK_RoleID WHERE dbo.sr_Roles.RoleName = '管理员'");

            return DbHelperSQL.Query(strSql.ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM dbo.sr_UserRole INNER JOIN dbo.sr_User ON dbo.sr_UserRole.FK_UserID = dbo.sr_User.PK_UserID INNER JOIN dbo.sr_Roles ON dbo.sr_UserRole.FK_RoleID = dbo.sr_Roles.PK_RoleID WHERE dbo.sr_Roles.RoleName = '系统管理员'");

            return DbHelperSQL.Query(strSql.ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM dbo.sr_UserRole INNER JOIN dbo.sr_User ON dbo.sr_UserRole.FK_UserID = dbo.sr_User.PK_UserID INNER JOIN dbo.sr_Roles ON dbo.sr_UserRole.FK_RoleID = dbo.sr_Roles.PK_RoleID ");

            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        public DataSet GetFeipeiUser()//绑定教师或管理员
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.sr_User.PK_UserID, dbo.sr_Roles.RoleName, dbo.sr_User.UserName FROM dbo.sr_User INNER JOIN dbo.sr_UserRole ON dbo.sr_User.PK_UserID = dbo.sr_UserRole.FK_UserID INNER JOIN dbo.sr_Roles ON dbo.sr_UserRole.FK_RoleID = dbo.sr_Roles.PK_RoleID and dbo.sr_User.Logins=0 and (sr_Roles.RoleName='教师' or sr_Roles.RoleName='管理员')");

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetFeipeiUserXiTong()////绑定系统管理员
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dbo.sr_User.PK_UserID, dbo.sr_Roles.RoleName, dbo.sr_User.UserName FROM dbo.sr_User INNER JOIN dbo.sr_UserRole ON dbo.sr_User.PK_UserID = dbo.sr_UserRole.FK_UserID INNER JOIN dbo.sr_Roles ON dbo.sr_UserRole.FK_RoleID = dbo.sr_Roles.PK_RoleID and dbo.sr_User.Logins=0 and sr_Roles.RoleName='系统管理员'");

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetXiuGaiUser()//绑定教师或管理员
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.sr_User INNER JOIN dbo.sr_UserRole ON dbo.sr_User.PK_UserID = dbo.sr_UserRole.FK_UserID INNER JOIN dbo.sr_Roles ON dbo.sr_UserRole.FK_RoleID = dbo.sr_Roles.PK_RoleID  and (sr_Roles.RoleName='教师' or sr_Roles.RoleName='管理员')");

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetXiuGaiUserXiTong()////绑定系统管理员
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.sr_User INNER JOIN dbo.sr_UserRole ON dbo.sr_User.PK_UserID = dbo.sr_UserRole.FK_UserID INNER JOIN dbo.sr_Roles ON dbo.sr_UserRole.FK_RoleID = dbo.sr_Roles.PK_RoleID and sr_Roles.RoleName='系统管理员'");

            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" PK_UserID,UserName,Password,Sex,Unit,Education,ZhiCheng,Telephone,InOffice,Email,Logins,LastLogin,Status,Extra1,Extra2,Extra3 ");
            strSql.Append(" FROM sr_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "sr_User";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        #region 根据用户名和密码查找用户存不存在
        /// <summary>
        /// 根据用户名和密码和角色查找用户存不存在
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="PassWord">密码</param>
        /// <param name="RoleName">角色Name</param>
        /// <returns></returns>
        public bool isExistUser(string UserId, string PassWord, string RoleName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT     count(dbo.sr_UserRole.PK_ID)
                            FROM         dbo.sr_User INNER JOIN
                        dbo.sr_UserRole ON dbo.sr_User.PK_UserID = dbo.sr_UserRole.FK_UserID INNER JOIN
                        dbo.sr_Roles ON dbo.sr_UserRole.FK_RoleID = dbo.sr_Roles.PK_RoleID
                        WHERE     (dbo.sr_User.PK_UserID = @UserId) AND (dbo.sr_User.Password = @PassWord) AND 
			            (dbo.sr_Roles.RoleName = @RoleName)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.NVarChar,10),
                    new SqlParameter("@PassWord", SqlDbType.NVarChar,32),
                    new SqlParameter("@RoleName", SqlDbType.NVarChar,15)
                                        };
            parameters[0].Value = UserId;
            parameters[1].Value = PassWord;
            parameters[2].Value = RoleName;
            DataSet ds = new DataSet();
            ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return (int.Parse(ds.Tables[0].Rows[0][0].ToString()) > 0);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Status from sr_User where PK_UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.NVarChar,10)
                                        };
            parameters[0].Value = UserID;
            int status;
            status = int.Parse(DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString());
            if (status == 1)
                return true;
            else
                return false;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Logins from sr_User where PK_UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.NVarChar,10)
                                        };
            parameters[0].Value = UserID;
            return int.Parse(DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString());
        }
        #endregion

        #region 根据用户ID得到用户名,如果用户名为空 返回空字符串 ""
        /// <summary>
        /// 根据用户ID得到用户名,如果用户名为空 返回空字符串""
        /// author:liangjinwei
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetUserName(string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserName from sr_User where PK_UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.NVarChar,10)
                                        };
            parameters[0].Value = UserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            string str = "";
            if (obj == null)
                return str;
            else
                return obj.ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Unit from sr_User where PK_UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.NVarChar,10)
                                        };
            parameters[0].Value = UserID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            string str = "";
            if (obj == null)
                return str;
            else
                return obj.ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Password from sr_User where PK_UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.NVarChar,32)
                                        };
            parameters[0].Value = UserID;

            return DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();

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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_User  set Logins=Logins+1  where PK_UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.NVarChar,10)
                                        };
            parameters[0].Value = UserID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_User  Set Password=@Password where PK_UserID=@PK_UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@Password", SqlDbType.NVarChar,32),
                    
                    new SqlParameter("@PK_UserID", SqlDbType.NVarChar,10)
                                        };
            parameters[0].Value = Password;

            parameters[1].Value = UserID;
            int i;
            i = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (i > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region 更新个人信息
        /// <summary>
        /// 更新个人信息
        /// author:liangjinwei 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>(UserName, Sex, Unit, Education, ZhiCheng, Telephone, InOffice, Email, UserID)
        public bool UpdateGeRenXinXi(string UserName, string Sex, string Unit, string Education, string ZhiCheng, string Telephone, string InOffice, string Email, string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_User  Set UserName=@UserName,Sex=@Sex,Unit=@Unit,Education=@Education, ZhiCheng=@ZhiCheng,Telephone=@Telephone ,InOffice=@InOffice,Email=@Email where PK_UserID=@PK_UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,10),
                    new SqlParameter("@Sex", SqlDbType.NVarChar,2),
                    new SqlParameter("@Unit", SqlDbType.NVarChar,20),
                    new SqlParameter("@Education", SqlDbType.NVarChar,10),
                    new SqlParameter("@ZhiCheng", SqlDbType.NVarChar,10),
                    
                    new SqlParameter("@Telephone", SqlDbType.NVarChar,15),
                    new SqlParameter("@InOffice", SqlDbType.NVarChar,2),    //...
                    new SqlParameter("@Email", SqlDbType.NVarChar,30),
                    new SqlParameter("@PK_UserID", SqlDbType.NVarChar,10)
                                        };
            parameters[0].Value = UserName;
            parameters[1].Value = Sex;
            parameters[2].Value = Unit;
            parameters[3].Value = Education;
            parameters[4].Value = ZhiCheng;

            parameters[5].Value = Telephone;
            parameters[6].Value = InOffice;
            parameters[7].Value = Email;
            parameters[8].Value = UserID;
            int i;
            i = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (i > 0)
                return true;
            else
                return false;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_User  Set UserName=@UserName,Sex=@Sex,Unit=@Unit,Education=@Education, ZhiCheng=@ZhiCheng,Telephone=@Telephone ,InOffice=@InOffice,Email=@Email,Status=@DropStatus where PK_UserID=@PK_UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,10),
                    new SqlParameter("@Sex", SqlDbType.NVarChar,2),
                    new SqlParameter("@Unit", SqlDbType.NVarChar,20),
                    new SqlParameter("@Education", SqlDbType.NVarChar,10),
                    new SqlParameter("@ZhiCheng", SqlDbType.NVarChar,10),
                    
                    new SqlParameter("@Telephone", SqlDbType.NVarChar,15),
                    new SqlParameter("@InOffice", SqlDbType.NVarChar,2),    //...
                    new SqlParameter("@Email", SqlDbType.NVarChar,30),
                    new SqlParameter("@DropStatus", SqlDbType.NVarChar,10),
                                        
                    new SqlParameter("@PK_UserID", SqlDbType.NVarChar,10)};
            parameters[0].Value = UserName;
            parameters[1].Value = Sex;
            parameters[2].Value = Unit;
            parameters[3].Value = Education;
            parameters[4].Value = ZhiCheng;

            parameters[5].Value = Telephone;
            parameters[6].Value = InOffice;
            parameters[7].Value = Email;
            parameters[8].Value = DropStatus;
            parameters[9].Value = UserID;
            
            int i;
            i = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (i > 0)
                return true;
            else
                return false;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sr_User  Set UserName=@UserName,Password=@Password,Sex=@Sex,Unit=@Unit,Education=@Education, ZhiCheng=@ZhiCheng,Telephone=@Telephone ,InOffice=@InOffice,Email=@Email,Status=@DropStatus where PK_UserID=@PK_UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,10),
                    new SqlParameter("@Password", SqlDbType.NVarChar,32),
                    new SqlParameter("@Sex", SqlDbType.NVarChar,2),
                    new SqlParameter("@Unit", SqlDbType.NVarChar,20),
                    new SqlParameter("@Education", SqlDbType.NVarChar,10),
                    new SqlParameter("@ZhiCheng", SqlDbType.NVarChar,10),
                    
                    new SqlParameter("@Telephone", SqlDbType.NVarChar,15),
                    new SqlParameter("@InOffice", SqlDbType.NVarChar,2),    //...
                    new SqlParameter("@Email", SqlDbType.NVarChar,30),
                    new SqlParameter("@DropStatus", SqlDbType.NVarChar,10),
                                        
                    new SqlParameter("@PK_UserID", SqlDbType.NVarChar,10)};
            parameters[0].Value = UserName;
            parameters[1].Value = Password;
            parameters[2].Value = Sex;
            parameters[3].Value = Unit;
            parameters[4].Value = Education;
            parameters[5].Value = ZhiCheng;

            parameters[6].Value = Telephone;
            parameters[7].Value = InOffice;
            parameters[8].Value = Email;
            parameters[9].Value = DropStatus;
            parameters[10].Value = UserID;

            int i;
            i = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (i > 0)
                return true;
            else
                return false;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Unit from sr_User where PK_UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.NVarChar,10)
                                        };
            parameters[0].Value = userID;

            return DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();
        } 
        #endregion

        #region 消息发送——返回学院列表
        /// <summary>
        /// 消息发送——返回学院列表    ——By dancy   
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetXueYuan()
        {
            string strSql = "select distinct Unit from sr_User";
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 消息发送——根据学院返回教师姓名列表
        /// <summary>
        /// 消息发送——根据学院返回教师姓名列表    ——By dancy   
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetNameByXueyuan(string Xueyuan)
        {
            string strSql = "select UserName from sr_User where Unit='" + Xueyuan + "'";
            return DbHelperSQL.Query(strSql.ToString());
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
            string strSql = "select PK_UserID from sr_User where UserName='"+UserName+"' AND Unit='" + Unit + "'";
            DataSet ds = new DataSet();
            ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return (ds.Tables[0].Rows[0][0].ToString());
            }
        }
        #endregion
    }
}

