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
    public partial class GeRenXinXi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)  //如果用户还没登陆跳到登陆页面
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    sr_User users = new sr_User();
                    ZQUSR.Model.sr_User model = users.GetModel(Session["UserID"].ToString());

                    //TB_UserID.Text = Session["UserID"].ToString();
                    TB_UserID.Text = model.PK_UserID;
                    TB_UserName.Text = model.UserName;
                    DropDL_Sex.SelectedValue = model.Sex;   //
                    TB_Unit.SelectedValue = model.Unit;
                    DropDL_Degree.SelectedValue= model.Education;
                    TB_ZhiCheng.SelectedValue = model.ZhiCheng;
                    TB_Telephone.Text = model.Telephone;
                    int i = int.Parse(model.InOffice.ToString());
                    if (i == 1)
                        DropDL_Job.SelectedValue = "在职";
                    else
                        DropDL_Job.SelectedValue = "不在职";
                    TB_Email.Text = model.Email;

                }
            }
            
        }

        protected void Btn_save_Click(object sender, EventArgs e)
        {
            //if (TB_UserName.Text == "")
            //{
            //    Response.Write("<script>alert('用户姓名不能为空')</script>");
            //    TB_UserName.Focus();
            //    return;
            //}

            sr_User users = new sr_User();
            string UserID = Session["UserID"].ToString();
            string UserName = TB_UserName.Text.ToString().Trim();
            string Sex = DropDL_Sex.SelectedValue;
            string Unit = TB_Unit.SelectedValue;
            string Education = DropDL_Degree.SelectedValue;
            string ZhiCheng = TB_ZhiCheng.SelectedValue;
          
            string Telephone = TB_Telephone.Text.ToString().Trim();
            string InOffice= DropDL_Job.SelectedIndex.ToString();//...
            string Email = TB_Email.Text.ToString().Trim();

            if (users.UpdateGeRenXinXi(UserName, Sex, Unit, Education, ZhiCheng, Telephone, InOffice, Email, UserID))
            { Response.Write("<script>alert('信息更新成功')</script>"); }
            else
            {
                Response.Write("<script>alert('信息更新失败')</script>");
                return;
            }
            TB_UserName.Focus();
            TB_UserName.Text = "";
            TB_Telephone.Text = "";
            TB_Email.Text = "";

            Session["UserName"] = users.GetUserName(Session["UserID"].ToString()); //更新完信息后再将UserName保存到session
         
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
