using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using ZQUSR.BLL;

namespace Web.Audit
{
    public partial class SecondAudited : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Achievement Bll = new ZQUSR.BLL.sr_Achievement();
        private ZQUSR.Model.sr_Periods PeriodsModel = new ZQUSR.Model.sr_Periods();
        private ZQUSR.BLL.sr_Periods PeriodsBll = new ZQUSR.BLL.sr_Periods();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    PeriodsModel = PeriodsBll.GetModel(3);
            //    if (!((Convert.ToDateTime(PeriodsModel.StartTime)) <= (Convert.ToDateTime(DateTime.Now.ToString("yy-MM-dd"))) && (Convert.ToDateTime(DateTime.Now.ToString("yy-MM-dd")) <= (Convert.ToDateTime(PeriodsModel.EndTime)))))
            //    {
            //        Response.Redirect("/Message/TimeSetMessage.aspx?tid=3");
            //    }
            //    else
            //    {
                    BindData();
                //}
            //}
        }

        private void BindData()
        {
            DataSet ds = new DataSet();
            PagedDataSource pds = new PagedDataSource();
            ds = Bll.GetListByKeyuanAudited();
            AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataSource = pds;
            GridView1.DataKeyNames = new string[] { "PK_AID" };
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //审核状态
                string state = e.Row.Cells[10].Text;
                e.Row.Cells[10].Text = StateInfo.GetAuditStateByKeyuan(state);

                //完成成果排名
                string rank = e.Row.Cells[4].Text;
                e.Row.Cells[4].Text = StateInfo.GetRank(rank);

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
            BindData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Audit")
            {
                string strID = e.CommandArgument.ToString();
                string strResult = strID.Substring(0, 2);
                Response.Write("<script>alert('" + strResult + "')</script>");
                switch (strResult)
                {
                    case "LW":
                        Response.Redirect("/Preview/Thesis_Preview.aspx?cmd=audit&srid=" + strID + "");
                        break;
                    case "ZZ":
                        Response.Redirect("/Preview/ZhuZuo_Preview.aspx?cmd=audit&srid=" + strID + "");
                        break;
                    case "ZL":
                        Response.Redirect("/Preview/ZhuanLi_Preview.aspx?cmd=audit&srid=" + strID + "");
                        break;
                    case "CZ":
                        Response.Redirect("/Preview/ChuangZuo_Preview.aspx?cmd=audit&srid=" + strID + "");
                        break;
                    case "KJ":
                        Response.Redirect("/Preview/KJJD_Preview.aspx?cmd=audit&srid=" + strID + "");
                        break;
                    case "SK":
                        Response.Redirect("/Preview/SKJD_Preview.aspx?cmd=audit&srid=" + strID + "");
                        break;
                    case "YY":
                        Response.Redirect("/Preview/KJYY_Preview.aspx?cmd=audit&srid=" + strID + "");
                        break;
                    case "RK":
                        Response.Redirect("/Preview/RuanKeXue_Preview.aspx?cmd=audit&srid=" + strID + "");
                        break;
                    case "HJ":
                        Response.Redirect("/Preview/HuoJiang_Preview.aspx?cmd=audit&srid=" + strID + "");
                        break;
                    case "KY":
                        Response.Redirect("/Preview/Project_Preview.aspx?cmd=audit&srid=" + strID + "");
                        break;
                    case "SB":
                        Response.Redirect("/Preview/Project_Preview.aspx?cmd=audit&srid=" + strID + "");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
