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
    public partial class WanShanXinXi : System.Web.UI.Page
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

                    TB_UserID.Text = Session["UserID"].ToString();
                }
            }
            
        }

        protected void Btn_save_Click(object sender, EventArgs e)
        {
           
            sr_User users = new sr_User();
            string UserID = Session["UserID"].ToString();
            string UserName = TB_UserName.Text.ToString().Trim();
            string Sex = DropDL_Sex.SelectedValue;
            string Unit = TB_Unit.SelectedValue;
            string Education = DropDL_Degree.SelectedValue;
            string ZhiCheng = TB_ZhiCheng.SelectedValue;

            string Telephone = TB_Telephone.Text.ToString().Trim();
            string InOffice = DropDL_Job.SelectedIndex.ToString();//...
            string Email = TB_Email.Text.ToString().Trim();

            if (users.UpdateGeRenXinXi(UserName, Sex, Unit, Education, ZhiCheng, Telephone, InOffice, Email, UserID))
            {
                Response.Write("<script>alert('信息更新成功')</script>");
                users.UpdateLogins(UserID);             //更新登录次数
            }
            else
            {
                Response.Write("<script>alert('信息更新失败')</script>");
                return;
            }
            
            Session["UserName"] = users.GetUserName(Session["UserID"].ToString()); //完善完信息后再将UserName保存到session
            string Role = Session["Role"].ToString();      //完善完信息后再根据角色跳到不通的页面。
            Session["Unit"] = users.GetUserUnit(Session["UserID"].ToString());
            switch (Role)
            {
                case "教师":
                    Response.Redirect("../Teacher.aspx");
                    break;
                case "管理员":
                    Response.Redirect("../Secretary.aspx");
                    break;
                case "系统管理员":
                    Response.Redirect("../KeYuan.aspx");
                    break;
                case "超级管理员":
                    Response.Redirect("../Chief.aspx");
                    break;
                default:
                    break;
            }
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            TB_UserName.Focus();
            TB_UserName.Text = "";
            TB_Telephone.Text = "";
            TB_Email.Text = "";
        }

        
    }
}
