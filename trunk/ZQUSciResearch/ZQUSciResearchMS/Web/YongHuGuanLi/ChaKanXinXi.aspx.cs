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
    public partial class ChaKanXinXi : System.Web.UI.Page
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
                {
                    sr_User users = new sr_User();
                    ZQUSR.Model.sr_User model = users.GetModel(Session["UserID"].ToString());
                    
                    Lb_UserID.Text = model.PK_UserID;
                    Lb_UserName.Text = model.UserName;
                    Lb_UserSex.Text = model.Sex;
                    Lb_UserUnit.Text = model.Unit;
                    Lb_UserEducation.Text = model.Education;
                    Lb_UserZhiCheng.Text = model.ZhiCheng;
                    Lb_UserTel.Text = model.Telephone;
                    int i = int.Parse(model.InOffice.ToString());
                    if (i == 1)
                        Lb_UserInOffice.Text = "在职";
                    else
                        Lb_UserInOffice.Text = "不在职";
                    Lb_UserEmail.Text = model.Email;
                    Lb_UserLoginTimes.Text = model.Logins.ToString();
                }
            }
        }
    }
}
