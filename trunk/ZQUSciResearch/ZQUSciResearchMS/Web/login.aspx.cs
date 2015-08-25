using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ZQUSR.BLL;

namespace Web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login1_Click(object sender, ImageClickEventArgs e)
        {
            string UserID = "", temppwd = "", Role = "";
            UserID = user.Text.Trim().ToString();
            temppwd = password.Text.Trim().ToString();
            string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(temppwd, "MD5");
            Role = chknumber.SelectedValue;

            sr_User users = new sr_User();
            
            //if (UserID == "")
            //{
            //    //Response.Write("<script>alert('用户名不能为空')</script>");
            //    user.Focus();
            //    return;
            //}
            //else if (temppwd == "")
            //{
            //    Response.Write("<script>alert('密码不能为空')</script>");
            //    password.Focus();
            //    return;
            //}
            if (!users.Exists(UserID))
            {
                Response.Write("<script>alert('不存在此用户')</script>");
                return;
            }
            if (!users.isExistUser(UserID, pwd, Role) )
            {
                Response.Write("<script>alert('密码或角色错误')</script>");
                return;
            }
            if (!users.StatusIsTrue(UserID))
            {
                Response.Write("<script>alert('此用户已被屏蔽')</script>");
                return;
            }
            else//如果可以登录进去
            {
                Session["UserID"] = UserID;
                Session["UserName"] = users.GetUserName(UserID);
                Session["Role"] = Role;
                Session["Unit"] = users.GetUserUnit(UserID);
                int LoginTimes;
                LoginTimes = users.GetLogins(UserID);   //得到登录次数
                
                if (LoginTimes == 0)                    //如果是第一次登录
                {
                    Response.Write(" <script> alert( '你首次登陆，请先完善信息');location.href= 'YongHuGuanLi/WanShanXinXi.aspx'; </script> ");

                }
                else
                {
                   
                    switch (Role)
                    {
                        case "教师":
                            Response.Redirect("Teacher.aspx");
                            break;
                        case "管理员":
                            Response.Redirect("Secretary.aspx");
                            break;
                        case "系统管理员":
                            Response.Redirect("KeYuan.aspx");
                            break;
                        case "超级管理员":
                            Response.Redirect("Chief.aspx");
                            break;
                        default:
                            break;
                    }
                }
            }
            //else
            //{
            //    Response.Write("<script>alert('不存在此用户或此用户不合法')</script>");
            //    user.Text = "";
            //    password.Text = "";
            //    user.Focus();
            //    return;
            //}
        }
    }
}
