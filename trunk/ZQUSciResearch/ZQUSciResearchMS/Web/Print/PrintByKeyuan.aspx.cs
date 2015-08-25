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
    public partial class PrintByKeyuan : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Achievement Bll = new ZQUSR.BLL.sr_Achievement();
        private ZQUSR.BLL.sr_Project ProjecrBll = new ZQUSR.BLL.sr_Project();
        private ZQUSR.BLL.sr_LwZzJc LwZuJcBll = new ZQUSR.BLL.sr_LwZzJc();
        private ZQUSR.BLL.sr_User UserBll = new ZQUSR.BLL.sr_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindInformation();
        }

        void BindInformation()
        {
            if (Session["UserID"] != null)
            {
                DataSet ds = new DataSet();
                string lwCounts = LwZuJcBll.GetNumBySortCount("SmallSort='学术论文' and  AuditState in (5,7)");
                string zzCounts = LwZuJcBll.GetNumBySortCount("SmallSort in ('学术著作','教材') and  AuditState in (5,7)");
                string zlCounts = Bll.GetNumBySortCount("SmallSort='专利成果' and  AuditState in (5,7)");
                string hjCounts = Bll.GetNumBySortCount("SmallSort='获奖成果' and  AuditState in (5,7)");
                string OtherHJCounts = Bll.GetNumBySortCount("SmallSort not in ('获奖成果') and  AuditState in (5,7)"); //其他成果类，除了获奖成果
                string ProjectCounts = ProjecrBll.GetNumBySortCount("SmallSort='科研项目' and  AuditState in (5,7)");
                string OtherPrCounts = ProjecrBll.GetNumBySortCount("SmallSort not in ('科研项目') and  AuditState in (5,7)"); //其他项目类（科研申报等），除了科研项目
                int OtherCounts = Int32.Parse(OtherHJCounts) + Int32.Parse(OtherPrCounts);
                if (Session["flag"].ToString()=="0")
                {
                    lb_Information.Visible = true;
                    DataSet Userds = new DataSet();
                    lb_Information.Text = "学校汇总：学术论文" + lwCounts + "篇\t学术著作(教材)" + zzCounts + "篇\t科研项目" + ProjectCounts + "篇\t其他" + OtherCounts + "篇";
                    ds = Bll.GetListByKeyuanPrint();
                }
                else if(Session["flag"].ToString()=="1"&&Session["ds"]!=null)
                {
                    ds = (DataSet)Session["ds"];
                    lb_Information.Visible = false;
                }
                GV_Print.DataSource = ds.Tables[0].DefaultView;
                GV_Print.DataKeyNames = new string[] { "PK_AID" };
                GV_Print.DataBind();
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
    }
}
