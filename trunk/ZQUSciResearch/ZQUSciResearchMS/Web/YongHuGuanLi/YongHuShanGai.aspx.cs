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
using System.Data.SqlClient;
using ZQUSR.BLL;
namespace Web.YongHuGuanLi
{
    public partial class YongHuShanGai : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        sr_User users = new sr_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)  //如果用户还没登陆跳到登陆页面
                    Response.Redirect("../login.aspx");
                else
                {


                    if (Session["Role"] != null)
                    {
                        bind();
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('您已经与服务器断开连接，请重新登录！');window.location.href='~/../../login.aspx';</script>");
                    }
                }
            }
        }
        void Getdataset()
        {
            if (Session["Role"].ToString() == "系统管理员")
            {
                ds = users.GetXiuGaiUser(); //所要分配用户为教师或管理员
            }
            else if (Session["Role"].ToString() == "超级管理员")
            {
                ds = users.GetXiuGaiUserXiTong();//所要分配用户为系统管理员
            }
        }
        void bind()
        {
            Getdataset();

            this.GridView1.DataSource = ds.Tables[0];
            this.GridView1.DataBind();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)     //Unit字段中超长字符用...替代
            {
                DataRowView mydrv;
                string gIntro;
                if (GridView1.PageIndex == 0)
                {
                    mydrv = ds.Tables[0].DefaultView[i];
                    gIntro = Convert.ToString(mydrv["Unit"]);
                    GridView1.Rows[i].Cells[3].Text = SubStr(gIntro, 4);
                }
                else
                {
                    mydrv = ds.Tables[0].DefaultView[i + (9 * GridView1.PageIndex)];//每页的行数
                    gIntro = Convert.ToString(mydrv["Unit"]);
                    GridView1.Rows[i].Cells[3].Text = SubStr(gIntro, 4);
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //  int i;
            //for (i = 0; i < GridView1.Rows.Count; i++)
            //{
            if (e.Row.RowType == DataControlRowType.DataRow)    //鼠标遇到每一行时更改颜色
            {
                //鼠标移动到每项时颜色交替效果    
                e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor='White';");
                e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor='#f7f7f7';");

            }
            // }
            foreach (TableCell tc in e.Row.Cells)               //设置每一行的宽度
            {
                tc.Attributes["style"] = "width:100px;";

            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }


        //protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        //{
        //    // string str = GridView1.DataKeys[GridView1.SelectedIndex]["PK_UserID"].ToString();
        //    int index = e.RowIndex;
        //    GridViewRow row = GridView1.Rows[index];
        //    string uid = row.Cells[0].Text.Trim();
        //    users.Delete(uid);
        //    bind();
        //}
        public string SubStr(string sString, int nLeng)
        {
            if (sString.Length <= nLeng)
            {
                return sString;
            }
            string sNewStr = sString.Substring(0, nLeng);
            sNewStr = sNewStr + "...";
            return sNewStr;
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;              //选中的行号
            GridViewRow row = GridView1.Rows[index];     //在gridview中的行号
            string uid = row.Cells[0].Text.Trim();      //gridview中的第0列字段内容
            
            //sr_User users = new sr_User();
            ZQUSR.Model.sr_User model = users.GetModel(uid);

            TB_UserID.Text = model.PK_UserID;

            TB_UserName.Text = model.UserName;
            string sex = model.Sex.Trim().ToString();
            string unit = model.Unit.Trim().ToString();
            string TDegree = model.Education.Trim().ToString();
            string ZhiCheng = model.ZhiCheng.Trim().ToString();
              
            if(sex!="")
                 DropDL_Sex.SelectedValue = model.Sex;
            if (unit != "")
            TB_Unit.SelectedValue = model.Unit;
            if (TDegree != "")
            DropDL_Degree.SelectedValue = model.Education;
            if (TDegree != "")
            TB_ZhiCheng.SelectedValue = model.ZhiCheng;

            TB_Telephone.Text = model.Telephone;
            int i = int.Parse(model.InOffice.ToString());
            if (i == 1)
                DropDL_Job.SelectedValue = "在职";
            else
                DropDL_Job.SelectedValue = "不在职";
           
            TB_Email.Text = model.Email;
            int j = model.Status.Value;
            if(j==1)
                DropStatus.SelectedValue = "可以登录";
            else
                DropStatus.SelectedValue = "禁止登录";

            RePwd.Text = "";
            this.Panel1.Visible = true;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string UserID = this.TB_UserID.Text.ToString();
                string UserName = TB_UserName.Text.ToString().Trim();
                string Sex = DropDL_Sex.SelectedValue;
                string Unit = TB_Unit.SelectedValue;
                string Education = DropDL_Degree.SelectedValue;
                string ZhiCheng = TB_ZhiCheng.SelectedValue;

                string Telephone = TB_Telephone.Text.ToString().Trim();
                string InOffice = DropDL_Job.SelectedIndex.ToString();//...
                string Email = TB_Email.Text.ToString().Trim();
                string Status = DropStatus.SelectedIndex.ToString();
                string Pwd = RePwd.Text.Trim().ToString();
                string tempPwd ;
                if (Pwd == "")
                {
                    users.ChangeGeRenXinXi(UserName, Sex, Unit, Education, ZhiCheng, Telephone, InOffice, Email, Status, UserID);
                    Response.Write("<script>alert('修改成功')</script>");
                }
                else
                {
                    tempPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(Pwd, "MD5");
                    users.ChangeGeRenXinXi(UserName,tempPwd, Sex, Unit, Education, ZhiCheng, Telephone, InOffice, Email, Status, UserID);
                    Response.Write("<script>alert('修改成功')</script>");
                }
                
                bind();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                Response.Write("<script>alert('系统出错，修改失败，请联系上级管理员')</script>");
            }
            finally
            {
                this.Panel1.Visible = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
        }


    }
}
