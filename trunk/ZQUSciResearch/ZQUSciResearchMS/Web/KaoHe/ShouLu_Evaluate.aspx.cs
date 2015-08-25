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
    public partial class ShouLu_Evaluate : System.Web.UI.Page
    {
        private ZQUSR.Model.sr_Lunwen LunwenModel = new ZQUSR.Model.sr_Lunwen();
        private ZQUSR.BLL.sr_Lunwen LunwenBll = new ZQUSR.BLL.sr_Lunwen();

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
            ds = LunwenBll.GetData();
            AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataSource = pds;
            GridView1.DataKeyNames = new string[] { "PK_LID" };
            GridView1.DataBind();
        }

        #region GridView相关操作
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int intPID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            LunwenBll.Delete(intPID);
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
            decimal decLevelFactor = Convert.ToDecimal(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtLevelFactor")).Text);
            string strJiBie = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlJiBie")).SelectedValue;

            LunwenModel.PK_LID = intPID;
            LunwenModel.LevelFactor = decLevelFactor;
            LunwenModel.JiBie = strJiBie;

            //更新
            LunwenBll.UpdateJiBie(LunwenModel);

            GridView1.EditIndex = -1;
            BindData();
        }
        #endregion

        #region 保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strType = ddlType.SelectedValue;
            string strSituation = txtSituation.Text;
            decimal decLevelFactor = Convert.ToDecimal(txtLevelFactor.Text);
            string strJiBie = ddlJiBie.SelectedValue;

            LunwenModel.Type = strType;
            LunwenModel.Situation = strSituation;
            LunwenModel.LevelFactor = decLevelFactor;
            LunwenModel.JiBie = strJiBie;

            if (LunwenBll.Exists(LunwenModel))
            {
                MessageBox.Show(this, "已经存在该记录！");
            }
            else
            {
                LunwenBll.Add(LunwenModel);
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
