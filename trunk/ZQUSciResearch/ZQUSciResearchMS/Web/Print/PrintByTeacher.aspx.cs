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

namespace Web.Print
{
    public partial class PrintByTeacher : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Achievement Bll = new ZQUSR.BLL.sr_Achievement();
        private ZQUSR.BLL.sr_User UserBll = new ZQUSR.BLL.sr_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindInformation();
            PrintTime();
        }

        void PrintTime()
        {
            DateTime dt = DateTime.Now;
            lb_PrintTime.Text="打印时间："+dt.ToString("yyyy-MM-dd hh:mm:ss");
        }

        void BindInformation()
        {
            if (Session["UserID"]!=null)
            {
                string userid = Session["UserID"].ToString();
                if (userid!="")
                {
                    DataSet ds = new DataSet();
                    DataSet Userds = new DataSet();
                    Userds = UserBll.GetList("PK_UserID='" + userid + "'");
                    if (Userds.Tables[0].Rows.Count==1)
                    {
                        lb_Information.Text = "姓名："+Userds.Tables[0].Rows[0]["UserName"] + "     单位："+Userds.Tables[0].Rows[0]["Unit"] + "     职称："+Userds.Tables[0].Rows[0]["ZhiCheng"];
                    }
                    if (Session["flag"].ToString()=="0")
                    {
                        ds = Bll.GetListByJiaoshiPrint(userid);
                    }
                    else if(Session["flag"].ToString()=="1"&&Session["ds"]!=null)
                    {
                        ds = (DataSet)Session["ds"];
                    }
                    GV_Print.DataSource = ds.Tables[0].DefaultView;
                    GV_Print.DataKeyNames = new string[] { "PK_AID" };
                    GV_Print.DataBind();
                }
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void GV_Print_RowDataBound(object sender, GridViewRowEventArgs e)
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
    }
}
