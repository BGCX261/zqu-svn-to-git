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
    public partial class PrintByMishu : System.Web.UI.Page
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
                string userid = Session["UserID"].ToString();
                string Unit = UserBll.GetUnitByUserID(userid);
                string lwSql= " where UserUnit='" + Unit + "' and SmallSort='学术论文' and  AuditState in (5,7)"; //学术论文类
                string zzSql = " where UserUnit='" + Unit + "' and SmallSort in ('学术著作','教材') and  AuditState in (5,7)";//学术著作
                string ProjectSql = " where UserUnit='" + Unit + "' and SmallSort='科研项目' and  AuditState in (5,7)";//科研项目
                string OtherSql = " where UserUnit='" + Unit + "' and SmallSort not in ('学术论文','学术著作','教材','科研项目') and  AuditState in (5,7)"; //其他
                int lwCounts = Int32.Parse(Bll.GetCountByMishuAch(lwSql)) + Int32.Parse(Bll.GetCountByMishuLw(lwSql)) + Int32.Parse(Bll.GetCountByMishuPro(lwSql));
                int zzCounts = Int32.Parse(Bll.GetCountByMishuAch(zzSql)) + Int32.Parse(Bll.GetCountByMishuLw(zzSql)) + Int32.Parse(Bll.GetCountByMishuPro(zzSql));
                int ProjectCounts = Int32.Parse(Bll.GetCountByMishuAch(ProjectSql)) + Int32.Parse(Bll.GetCountByMishuLw(ProjectSql)) + Int32.Parse(Bll.GetCountByMishuPro(ProjectSql));
                int OtherCounts = Int32.Parse(Bll.GetCountByMishuAch(OtherSql)) + Int32.Parse(Bll.GetCountByMishuLw(OtherSql)) + Int32.Parse(Bll.GetCountByMishuPro(OtherSql));
                if (Session["flag"].ToString()=="0")
                {
                    lb_Information.Visible = true;
                    lb_Information.Text = "单位名称:(盖章)：" + Unit +"\t单位汇总：学术论文" + lwCounts + "篇\t学术著作(教材)" + zzCounts+"篇\t科研项目"+ProjectCounts+"篇\t其他"+OtherCounts+"篇";
                    ds = Bll.GetListByMishuPrint(Unit);
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
