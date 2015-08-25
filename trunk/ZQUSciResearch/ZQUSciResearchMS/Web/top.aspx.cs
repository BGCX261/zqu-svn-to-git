using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ZQUSR.BLL;
using ZQUSR.Model;
using System.Data;

namespace Web
{
    public partial class top : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Message MsgBll = new ZQUSR.BLL.sr_Message();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    Lb_UserName.Text = Session["UserName"].ToString();
                    Lb_Role.Text = Session["Role"].ToString();
                    Lb_Unit.Text = Session["Unit"].ToString();
                    BindMsgCount();
                }
            }
        }
        public void BindMsgCount()
        {
            string strWhere = "FK_RecieverID='" + Session["UserID"].ToString() + "'AND IsRead='0'";
            DataSet ds = MsgBll.GetList(strWhere);
            lblCount.Text=ds.Tables[0].Rows.Count.ToString();
        }
    }
}
