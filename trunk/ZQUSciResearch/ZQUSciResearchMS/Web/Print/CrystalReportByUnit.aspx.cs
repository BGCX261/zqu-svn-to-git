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
using System.Data.SqlClient;

namespace Web.Print
{
    public partial class CrystalReportByUnit : System.Web.UI.Page
    {
        ZQUSR.BLL.sr_Achievement bll = new ZQUSR.BLL.sr_Achievement();
        ZQUSR.BLL.sr_User UserBll = new ZQUSR.BLL.sr_User();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {
            if (Session["UserID"] != null)
            {
                string userid = Session["UserID"].ToString();
                string Unit = UserBll.GetUnitByUserID(userid);
                DataSet ds = new DataSet();
                ds = bll.GetListByMishuPrint(Unit);
                CRSource1.ReportDocument.Load(Server.MapPath("CrystalReport2.rpt"));
                CRSource1.ReportDocument.SetDataSource(ds.Tables[0]);
                CRSource1.DataBind();
                CRViewer1.ReportSource = CRSource1;
                CRViewer1.DataBind();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

    }
}
