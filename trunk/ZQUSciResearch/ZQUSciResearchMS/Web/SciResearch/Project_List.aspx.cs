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

namespace Web.SciResearch  
{
    public partial class Project_List : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Project ProBll = new ZQUSR.BLL.sr_Project();
        private ZQUSR.Model.sr_Project ProModel = new ZQUSR.Model.sr_Project();
        private ZQUSR.Model.sr_Periods PeriodsModel = new ZQUSR.Model.sr_Periods();
        private ZQUSR.BLL.sr_Periods PeriodsBll = new ZQUSR.BLL.sr_Periods();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    PeriodsModel = PeriodsBll.GetModel(1);
                    if (!((Convert.ToDateTime(PeriodsModel.StartTime)) <= (Convert.ToDateTime(DateTime.Now.ToString("yy-MM-dd"))) && (Convert.ToDateTime(DateTime.Now.ToString("yy-MM-dd")) <= (Convert.ToDateTime(PeriodsModel.EndTime)))))
                    {
                        Response.Redirect("/Message/TimeSetMessage.aspx?tid=1");
                    }
                    else
                    {
                        string userID = Session["UserID"].ToString();
                        if (userID != "")
                        {
                            BindData();     //数据填充
                        }
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('您已经与服务器断开连接，请重新登录！');window.location.href='~/../../login.aspx';</script>");
                }
            }
        }

        private void BindData()
        {
            ProModel.FK_UserID = Session["UserID"].ToString();
            ProModel.SmallSort = "科研项目";
            DataSet ds = new DataSet();
            ds = ProBll.GetProject(ProModel);
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "PK_PID" };
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //审核状态
                string state = e.Row.Cells[7].Text;
                e.Row.Cells[7].Text = StateInfo.GetAuditState(state);


                //设置在以下审核状态时不可修改
                if (state == "1" || state == "3" || state == "5" || state == "7")
                {
                    e.Row.Cells[9].Enabled = false;
                }

                //设置在非0（未提交）状态下不可删除
                if (state != "0")
                {
                    e.Row.Cells[10].Enabled = false;
                }


                //鼠标移动到每项时颜色交替效果    
                e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor='White';");
                e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor='#f7f7f7';");

                //设置悬浮鼠标指针形状为"小手"    
                e.Row.Attributes["style"] = "Cursor:hand";
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strPID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            ProBll.Delete(strPID);
            BindData();
        }
    }
}
