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
using System.Data;
using ZQUSR.BLL;
using System.IO;
using System.Text;

namespace Web.Print
{
    public partial class PrintConditionByTeacher : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Achievement Bll = new ZQUSR.BLL.sr_Achievement();
        private ZQUSR.BLL.sr_User UserBll = new ZQUSR.BLL.sr_User();
        static int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            if (Session["UserID"] != null)
            {
                string UserID = Session["UserID"].ToString();
                if (UserID != "")
                {
                    DataSet ds = new DataSet();
                    PagedDataSource pds = new PagedDataSource();
                    ds = Bll.GetListByJiaoshiAudit(UserID);
                    AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
                    pds.AllowPaging = true;
                    pds.PageSize = AspNetPager1.PageSize;
                    pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                    pds.DataSource = ds.Tables[0].DefaultView;
                    GridView1.DataSource = pds;
                    GridView1.DataKeyNames = new string[] { "PK_AID" };
                    GridView1.DataBind();
                    Session["flag"] = 0;
                }
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        private void BindDataByDate(string strStart, string strEnd,string strAuditState) //按条件查询
        {
            if (Session["UserID"] != null)
            {
                string UserID = Session["UserID"].ToString();
                if (UserID != "")
                {
                    DataSet ds2 = new DataSet();
                    PagedDataSource pds2 = new PagedDataSource();
                    if (strAuditState=="-1"&&strStart!=""&&strEnd!="")//按日期查询
                    {
                        ds2 = Bll.GetListByJiaoshibyDate(UserID, strStart, strEnd);
                    }
                    else if (strAuditState!="-1"&&strStart==""&&strEnd=="")//按审核状态查询
                    {
                        ds2 = Bll.GetListByJiaoshibyAudit(UserID, ddl_PrintCondition.SelectedValue.ToString());
                    }
                    else if (strAuditState != "-1" && strStart != "" && strEnd != "") //按审核状态与日期查询
                    {
                        ds2 = Bll.GetListByJiaoshibyDateAudit(UserID,strStart,strEnd,strAuditState);
                    }
                    AspNetPager1.RecordCount = ds2.Tables[0].Rows.Count;
                    pds2.AllowPaging = true;
                    pds2.PageSize = AspNetPager1.PageSize;
                    pds2.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                    pds2.DataSource = ds2.Tables[0].DefaultView;
                    GridView1.DataSource = pds2;
                    GridView1.DataKeyNames = new string[] { "PK_AID" };
                    GridView1.DataBind();
                    Session["ds"] = ds2;
                    Session["flag"] = 1;
                }
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //审核状态
                string state = e.Row.Cells[9].Text;
                e.Row.Cells[9].Text = StateInfo.GetAuditState(state);

                //完成成果排名
                string rank = e.Row.Cells[3].Text;
                e.Row.Cells[3].Text = StateInfo.GetRank(rank);

                //鼠标移动到每项时颜色交替效果    
                e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor='White';");
                e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor='#EFEFEF';");

                //设置悬浮鼠标指针形状为"小手"    
                e.Row.Attributes["style"] = "Cursor:hand";
            }
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            if (flag==0)
            {
                BindData();
            }
            else
            {
                BindDataByDate(Tbox_Start.Text, Tbox_End.Text, ddl_PrintCondition.SelectedValue.ToString());
            }
           
        }


        protected void btn_Print_Click(object sender, EventArgs e) //按条件查询打印
        {
            if (Tbox_Start.Text != "" || Tbox_End.Text != "" || ddl_PrintCondition.SelectedValue.ToString() != "-1")
            {
                 string start = Tbox_Start.Text.Trim();
                 string end = Tbox_End.Text.Trim();
                 string AuditSate = ddl_PrintCondition.SelectedValue.ToString();
                 try
                 {
                      BindDataByDate(start, end,AuditSate);
                      flag = 1;
                      Session["flag"] = 1;
                 }
                 catch (System.Exception ex)
                 {
                     Response.Write("<font color='red'>查询失败，输入时间段不符合或时间值越界！</font>");
                 }
             }
        }

        protected void btn_All_Click(object sender, EventArgs e) //打印全部
        {
            BindData();
            flag = 0;
            Session["flag"] = 0;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)//导出到Excel
        {
            Export("application/ms-excel", "科研成果与业绩报表.xls");
        }
        private void Export(string FileType, string FileName)
        {
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.UTF7;
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
            Response.ContentType = FileType;
            this.EnableViewState = false;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            GridView1.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

    }
}
