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
namespace Web.YongHuGuanLi
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)  //如果用户还没登陆跳到登陆页面
                {
                    Response.Redirect("../login.aspx");
                }
                else
                    TB_UserID.Text = Session["UserID"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            sr_User users = new sr_User();
            string UserID=Session["UserID"].ToString();
            string Password = users.GetPassword(UserID);
            try
            {
                string strPwd = TB_OldPassword.Text;
                string oldPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(strPwd, "MD5");
                if (Password != oldPwd)
                { 
                    Response.Write("<script>alert('旧密码输入有误')</script>");
                    TB_OldPassword.Text = "";
                    TB_OldPassword.Focus();
                    return;
                }
                else if(TB_NewPassword1.Text!=TB_NewPassword2.Text)
                {
                    Response.Write("<script>alert('两次输入的新密码不一致，请重新输入')</script>");
                    TB_OldPassword.Text = "";
                    TB_NewPassword1.Text = "";
                    TB_NewPassword2.Text = "";
                    TB_OldPassword.Focus();
                    return;
                }
                string strPassword = TB_NewPassword1.Text.ToString();
                string newPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(strPassword, "MD5");
                if (users.UpdatePassword(newPwd, UserID))
                {
                    Response.Write("<script>alert('密码更改成功')</script>");
                    TB_OldPassword.Text = "";
                    TB_NewPassword1.Text = "";
                    TB_NewPassword2.Text = "";
                    TB_OldPassword.Focus();
                }
                else
                    Response.Write("<script>alert('密码更改失败')</script>");
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TB_OldPassword.Text = "";
            TB_NewPassword1.Text = "";
            TB_NewPassword2.Text = "";
            TB_OldPassword.Focus();
        }

        

      
    }
}
