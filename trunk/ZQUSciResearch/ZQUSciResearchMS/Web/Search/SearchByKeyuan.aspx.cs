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

namespace Web.Search
{
    public partial class SearchByKeyuan : System.Web.UI.Page
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
            DataSet ds = new DataSet();
            PagedDataSource pds = new PagedDataSource();
            ds = Bll.GetListByKeyuan();
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

        private void BindDataBySort(string strsort)  //按类别返回数据
        {
             DataSet ds1 = new DataSet();
             PagedDataSource pds1 = new PagedDataSource();
             ds1 = Bll.GetListByKeyuanBySort(strsort);
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

        private void BindDataByUnit(string strunit)  //按学院返回数据
        {
            DataSet ds2 = new DataSet();
            PagedDataSource pds2 = new PagedDataSource();
            ds2 = Bll.GetListByKeyuanByUnit(strunit);
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

        private void BindDataByDate(string strStart, string strEnd)//按日期返回数据
        {
             DataSet ds3 = new DataSet();
             PagedDataSource pds3 = new PagedDataSource();
             ds3 = Bll.GetListByKeyuanByDate(strStart, strEnd);
             AspNetPager1.RecordCount = ds3.Tables[0].Rows.Count;
             pds3.AllowPaging = true;
             pds3.PageSize = AspNetPager1.PageSize;
             pds3.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
             pds3.DataSource = ds3.Tables[0].DefaultView;
             GridView1.DataSource = pds3;
             GridView1.DataKeyNames = new string[] { "PK_AID" };
             GridView1.DataBind();
             flag = 3;
        }

        private void BindDataByName(string strname) //按姓名返回数据
        {
             DataSet ds4 = new DataSet();
             PagedDataSource pds4 = new PagedDataSource();
             ds4 = Bll.GetListByKeyuanByName(strname);
             AspNetPager1.RecordCount = ds4.Tables[0].Rows.Count;
             pds4.AllowPaging = true;
             pds4.PageSize = AspNetPager1.PageSize;
             pds4.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
             pds4.DataSource = ds4.Tables[0].DefaultView;
             GridView1.DataSource = pds4;
             GridView1.DataKeyNames = new string[] { "PK_AID" };
             GridView1.DataBind();
             flag = 4;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //审核状态
                string state = e.Row.Cells[10].Text;
                e.Row.Cells[10].Text = StateInfo.GetAuditStateByMishu(state);

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
                BindDataByUnit(ddl_Unit.SelectedValue);
            }
            else if (flag == 3)
            {
                BindDataByDate(Tbox_Start.Text, Tbox_End.Text);
            }
            else if (flag == 4)
            {
                BindDataByName(Tbox_Name.Text.Trim());
            }

        }

        protected void ddl_Condition_SelectedIndexChanged(object sender, EventArgs e)//控件的隐藏显示
        {
            if (ddl_Condition.SelectedIndex == 0)
            {
                lb_Start.Visible = false;
                lb_End.Visible = false;
                Tbox_End.Visible = false;
                Tbox_Start.Visible = false;
                Tbox_Name.Visible = false;
                ddl_Unit.Visible = false;
                ddl_Sort.Visible = true;
            }
            else if (ddl_Condition.SelectedIndex==1)
            {
                lb_Start.Visible = false;
                lb_End.Visible = false;
                Tbox_End.Visible = false;
                Tbox_Start.Visible = false;
                ddl_Sort.Visible = false;
                Tbox_Name.Visible = false;
                ddl_Unit.Visible = true;
            }
            else if (ddl_Condition.SelectedIndex == 2)
            {
                lb_Start.Visible = true;
                lb_End.Visible = true;
                Tbox_End.Visible = true;
                Tbox_Start.Visible = true;
                ddl_Sort.Visible = false;
                Tbox_Name.Visible = false;
                ddl_Unit.Visible = false;
            }
            else if(ddl_Condition.SelectedIndex==3)
            {
                lb_Start.Visible = false;
                lb_End.Visible = false;
                Tbox_End.Visible = false;
                Tbox_Start.Visible = false;
                ddl_Sort.Visible = false;
                ddl_Unit.Visible = false;
                Tbox_Name.Visible = true;
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e) //按条件查询
        {
            if (ddl_Condition.SelectedIndex == 0) //按类别查询
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
                    case "创作类成果": BindDataBySort("创作类成果");
                        break;
                    case "科技鉴定成果": BindDataBySort("科技鉴定成果");
                        break;
                    case "社科鉴定成果": BindDataBySort("社科鉴定成果");
                        break;
                    case "科技应用成果": BindDataBySort("科技应用成果");
                        break;
                    case "软科学成果": BindDataBySort("软科学成果");
                        break;
                    case "获奖成果": BindDataBySort("获奖成果");
                        break;
                    case "科研项目": BindDataBySort("科研项目");
                        break;
                    default: ; 
                        break;
                }
            }
            else if (ddl_Condition.SelectedIndex == 1) //按单位查询
            {
                string sort = ddl_Unit.SelectedValue;
                switch (sort)
                {
                    case "经济与管理学院": BindDataByUnit("经济与管理学院");
                        break;
                    case "政法学院": BindDataByUnit("政法学院");
                        break;
                    case "教育学院": BindDataByUnit("教育学院");
                        break;
                    case "体育与健康学院": BindDataByUnit("体育与健康学院");
                        break;
                    case "文学院": BindDataByUnit("文学院");
                        break;
                    case "外国语学院": BindDataByUnit("外国语学院");
                        break;
                    case "美术学院": BindDataByUnit("美术学院");
                        break;
                    case "数学与信息科学学院": BindDataByUnit("数学与信息科学学院");
                        break;
                    case "化学化工学院": BindDataByUnit("化学化工学院");
                        break;
                    case "生命科学学院": BindDataByUnit("生命科学学院");
                        break;
                    case "电子信息与机电工程学院": BindDataByUnit("电子信息与机电工程学院");
                        break;
                    case "计算机学院": BindDataByUnit("计算机学院");
                        break;
                    case "软件学院": BindDataByUnit("软件学院");
                        break;
                    case "旅游学院": BindDataByUnit("旅游学院");
                        break;
                    case "音乐学院": BindDataByUnit("音乐学院");
                        break;
                    default: ; 
                        break;
                }
            }
            else if (ddl_Condition.SelectedIndex == 2) //按日期查询
            {
                if (Tbox_Start.Text != "" && Tbox_End.Text != "")
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
            else if (ddl_Condition.SelectedIndex == 3)//按姓名查询
            {
                if (Tbox_Name.Text != "")
                {
                    string name = Tbox_Name.Text.Trim();
                    BindDataByName(name);
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
