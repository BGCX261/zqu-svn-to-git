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
    public partial class CrystalReport : System.Web.UI.Page
    {
        ZQUSR.BLL.sr_Achievement bll = new ZQUSR.BLL.sr_Achievement();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        void BindData()
        {
            DataSet ds = new DataSet();
            ds = bll.GetListByKeyuanPrint();
            CRSource1.ReportDocument.Load(Server.MapPath("CrystalReport1.rpt"));
            CRSource1.ReportDocument.SetDataSource(ds.Tables[0]);
            CRSource1.DataBind();
            CRViewer1.ReportSource = CRSource1;
            CRViewer1.DataBind();
        }
    }
}
