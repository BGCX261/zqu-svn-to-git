using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Message
{
    public partial class TimeSetMessage : System.Web.UI.Page
    {
        private ZQUSR.Model.sr_Periods PeriodsModel = new ZQUSR.Model.sr_Periods();
        private ZQUSR.BLL.sr_Periods PeriodsBll = new ZQUSR.BLL.sr_Periods();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNowTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                int intTid = Convert.ToInt32(Request.QueryString["tid"]);
                PeriodsModel = PeriodsBll.GetModel(intTid);
                lblName.Text = PeriodsModel.PeriName;
                lblStartTime.Text = PeriodsModel.StartTime.ToString("yyyy-MM-dd");
                lblEndTime.Text = PeriodsModel.EndTime.ToString("yyyy-MM-dd");
            }
        }
    }
}
