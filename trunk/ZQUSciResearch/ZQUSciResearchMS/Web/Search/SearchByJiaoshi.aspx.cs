using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using ZQUSR.BLL;

namespace Web.Search
{
    public partial class SearchByJiaoshi : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Achievement Bll = new ZQUSR.BLL.sr_Achievement();
        private ZQUSR.BLL.sr_User UserBll = new ZQUSR.BLL.sr_User();
        static int flag = 0; //依据返回的ds，用于分页控件的分页标志
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
                    ds = Bll.GetListByJiaoshi(UserID);
                    AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
                    pds.AllowPaging = true;
                    pds.PageSize = AspNetPager1.PageSize;
                    pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                    pds.DataSource = ds.Tables[0].DefaultView;
                    GridView1.DataSource = pds;
                    GridView1.DataKeyNames = new string[] { "PK_AID" };
                    GridView1.DataBind();
                    flag = 0;
                }
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        private void BindDataBySort(string strsort)
        {
            if (Session["UserID"] != null)
            {
                string UserID = Session["UserID"].ToString();
                if (UserID != "")
                {
                    DataSet ds1 = new DataSet();
                    PagedDataSource pds1 = new PagedDataSource();
                    ds1 = Bll.GetListByJiaoshibySort(UserID, strsort);
                    AspNetPager1.RecordCount = ds1.Tables[0].Rows.Count;
                    pds1.AllowPaging = true;
                    pds1.PageSize = AspNetPager1.PageSize;
                    pds1.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                    pds1.DataSource = ds1.Tables[0].DefaultView;
                    GridView1.DataSource = pds1;
                    GridView1.DataKeyNames = new string[] { "PK_AID" };
                    GridView1.DataBind();
                    flag = 1;
                }
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        private void BindDataByDate(string strStart,string strEnd)
        {
            if (Session["UserID"] != null)
            {
                string UserID = Session["UserID"].ToString();
                if (UserID != "")
                {
                    DataSet ds2 = new DataSet();
                    PagedDataSource pds2 = new PagedDataSource();
                    ds2 = Bll.GetListByJiaoshibyDate(UserID,strStart,strEnd);
                    AspNetPager1.RecordCount = ds2.Tables[0].Rows.Count;
                    pds2.AllowPaging = true;
                    pds2.PageSize = AspNetPager1.PageSize;
                    pds2.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                    pds2.DataSource = ds2.Tables[0].DefaultView;
                    GridView1.DataSource = pds2;
                    GridView1.DataKeyNames = new string[] { "PK_AID" };
                    GridView1.DataBind();
                    flag = 2;
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
            if (flag == 0)
            {
                BindData();
            }
            else if (flag == 1)
            {
                BindDataBySort(ddl_Sort.SelectedValue);
            }
            else if (flag == 2)
            {
                BindDataByDate(Tbox_Start.Text, Tbox_End.Text);
            }
        }

        protected void ddl_Condition_SelectedIndexChanged(object sender, EventArgs e)//控件的隐藏显示
        {
            if (ddl_Condition.SelectedIndex==0)
            {
                lb_Start.Visible = false;
                lb_End.Visible = false;
                Tbox_End.Visible = false;
                Tbox_Start.Visible = false;
                ddl_Sort.Visible = true;
            } 
            else
            {
                lb_Start.Visible = true;
                lb_End.Visible = true;
                Tbox_End.Visible = true;
                Tbox_Start.Visible = true;
                ddl_Sort.Visible = false;
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e) //按条件查询
        {
            if (ddl_Condition.SelectedIndex == 0)
            {
                string sort = ddl_Sort.SelectedValue;
                switch (sort)
                {
                    case "学术论文": BindDataBySort("学术论文");
                        break;
                    case "学术著作": BindDataBySort("学术著作");
                        break;
                    case "专利成果": BindDataBySort("专利成果");
                        break;
                        break;
                    case "创作类成果": BindDataBySort("创作类成果");
                        break;
                        break;
                    case "科技鉴定成果": BindDataBySort("科技鉴定成果");
                        break;
                        break;
                    case "社科鉴定成果": BindDataBySort("社科鉴定成果");
                        break;
                        break;
                    case "科技应用成果": BindDataBySort("科技应用成果");
                        break;
                        break;
                    case "软科学成果": BindDataBySort("软科学成果");
                        break;
                    case "获奖成果": BindDataBySort("获奖成果");
                        break;
                    case "科研项目": BindDataBySort("科研项目");
                        break;
                }
            }
            else
            {
                if (Tbox_Start.Text!=""&&Tbox_End.Text!="")
                {
                    string start = Tbox_Start.Text;
                    string end = Tbox_End.Text;
                    try
                    {
                        BindDataByDate(start, end);
                    }
                    catch (System.Exception ex)
                    {
                        Response.Write("<font color='red'>查询失败，输入时间段不符合或时间值越界！</font>");
                    }
                    
                }
            }
        }

        protected void btn_All_Click(object sender, EventArgs e) //查询全部
        {
            BindData();
        }

        protected void btn_Print_Click(object sender, EventArgs e)//打印
        {
            Response.Redirect("");
        }
    }
}
