using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using ZQUSR.BLL;

namespace Web.KaoHe
{
    public partial class SCISSCI_Evaluate : System.Web.UI.Page
    {
        private ZQUSR.Model.sr_Periodicals PeriModel = new ZQUSR.Model.sr_Periodicals();
        private ZQUSR.BLL.sr_Periodicals PeriBll = new ZQUSR.BLL.sr_Periodicals();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            PagedDataSource pds = new PagedDataSource();
            DataSet ds = new DataSet();
            ds = PeriBll.GetDatByKey(1);
            AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataSource = pds;
            GridView1.DataKeyNames = new string[] { "PK_PID" };
            GridView1.DataBind();
        }

        #region GridView相关操作
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int intPID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            PeriBll.Delete(intPID);
            BindData();
        }

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
            decimal decQIF= Convert.ToDecimal(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtQIF")).Text);

            PeriModel.PK_PID = intPID;
            PeriModel.QIF = decQIF;

            //更新
            PeriBll.UpdateQIF(PeriModel);

            GridView1.EditIndex = -1;
            BindData();
        }
        #endregion

        #region 保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strQikanKey = ddlQikanKey.SelectedValue;
            string strQikanName = txtQikanName.Text;
            decimal decQIF= Convert.ToDecimal(txtQIF.Text);

            PeriModel.QikanKey = strQikanKey;
            PeriModel.QikanName = strQikanName;
            PeriModel.QIF = decQIF;

            if (PeriBll.Exists(PeriModel))
            {
                MessageBox.Show(this, "已经存在该记录！");
            }
            else
            {
                PeriBll.Add(PeriModel);
                BindData();
                TabContainer1.ActiveTabIndex = TabContainer1.Tabs[0].TabIndex;
            }
        }
        #endregion

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
    }
}
