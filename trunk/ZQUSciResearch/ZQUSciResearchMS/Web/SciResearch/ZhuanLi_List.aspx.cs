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
    public partial class ZhuanLi_List : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Achievement AchievementBll = new ZQUSR.BLL.sr_Achievement();
        private ZQUSR.Model.sr_Achievement AchievementModel = new ZQUSR.Model.sr_Achievement();
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
            //AchievementModel.FK_UserID = Session["UserID"].ToString();
            //AchievementModel.SmallSort = "专利成果";
            //DataSet ds = new DataSet();
            //ds = AchievementBll.GetAchievementByJs(AchievementModel);
            //GridView1.DataSource = ds;
            //GridView1.DataKeyNames = new string[] { "PK_AID" };
            //GridView1.DataBind();

            AchievementModel.FK_UserID = Session["UserID"].ToString();
            AchievementModel.SmallSort = "专利成果";
            DataSet ds = new DataSet();
            ds = AchievementBll.GetAchievementByJs(AchievementModel);
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataSource = pds;
            GridView1.DataKeyNames = new string[] { "PK_AID" };
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //审核状态
                string state = e.Row.Cells[5].Text;
                e.Row.Cells[5].Text = StateInfo.GetAuditState(state);

                //完成成果排名
                string rank = e.Row.Cells[2].Text;
                e.Row.Cells[2].Text = StateInfo.GetRank(rank);


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
                e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor='#EFEFEF';");

                //设置悬浮鼠标指针形状为"小手"    
                e.Row.Attributes["style"] = "Cursor:hand";
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strAID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            AchievementBll.Delete(strAID);
            BindData();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
    }
}
