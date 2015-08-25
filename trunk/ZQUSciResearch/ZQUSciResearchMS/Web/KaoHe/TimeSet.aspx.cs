using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Web.KaoHe
{
    public partial class TimeSet : System.Web.UI.Page
    {
        private ZQUSR.Model.sr_Periods PeriodsModel = new ZQUSR.Model.sr_Periods();
        private ZQUSR.BLL.sr_Periods PeriodsBll = new ZQUSR.BLL.sr_Periods();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region 绑定数据列表
        private void BindData()
        {
            DataSet ds = new DataSet();
            ds = PeriodsBll.GetList();
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "PK_PID" };
            GridView1.DataBind();
        }
        #endregion

        #region GridView1 相关操作
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //鼠标移动到每项时颜色交替效果    
                e.Row.Attributes.Add("OnMouseOut", "this.style.backgroundColor='White';");
                e.Row.Attributes.Add("OnMouseOver", "this.style.backgroundColor='#EFEFEF';");

                //设置悬浮鼠标指针形状为"小手"    
                e.Row.Attributes["style"] = "Cursor:hand";
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int intPID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            DateTime dtStartTime = Convert.ToDateTime(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStartTime")).Text);
            DateTime dtEndTime = Convert.ToDateTime(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEndTime")).Text);

            PeriodsModel.PK_PID = intPID;
            PeriodsModel.StartTime = dtStartTime;
            PeriodsModel.EndTime = dtEndTime;

            //更新
            PeriodsBll.UpdateTime(PeriodsModel);

            GridView1.EditIndex = -1;
            BindData();
        }
        #endregion
    }
}