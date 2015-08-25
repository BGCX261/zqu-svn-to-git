using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using ZQUSR.BLL;

namespace Web.SciResearch
{
    public partial class Thesis_List : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_LwZzJc LwZzBll = new ZQUSR.BLL.sr_LwZzJc();
        private ZQUSR.Model.sr_LwZzJc LwZzModel = new ZQUSR.Model.sr_LwZzJc();
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
            LwZzModel.FK_UserID = Session["UserID"].ToString();
            LwZzModel.SmallSort = "学术论文";
            DataSet ds = new DataSet();
            ds = LwZzBll.GetLwZzJcByJs(LwZzModel);
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "PK_LZID" };
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //审核状态
                string state = e.Row.Cells[4].Text;
                e.Row.Cells[4].Text = StateInfo.GetAuditState(state);

                //完成成果排名
                string rank = e.Row.Cells[1].Text;
                e.Row.Cells[1].Text = StateInfo.GetRank(rank);


                //设置在以下审核状态时不可修改
                if (state == "1" || state == "3" || state == "5" || state == "7")
                {
                    e.Row.Cells[8].Enabled = false;
                }

                //设置在非0（未提交）状态下不可删除
                if (state != "0")
                {
                    e.Row.Cells[9].Enabled = false;
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
            string strLZID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            LwZzBll.Delete(strLZID);
            BindData();
        }
    }
}
