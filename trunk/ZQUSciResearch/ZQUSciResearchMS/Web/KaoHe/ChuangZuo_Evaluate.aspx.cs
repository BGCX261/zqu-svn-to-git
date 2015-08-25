﻿using System;
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

namespace Web.KaoHe
{
    public partial class ChuangZuo_Evaluate : System.Web.UI.Page
    {
        private ZQUSR.Model.sr_Produce ProModel = new ZQUSR.Model.sr_Produce();
        private ZQUSR.BLL.sr_Produce ProBll = new ZQUSR.BLL.sr_Produce();

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
            ds = ProBll.GetData();
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
            ProBll.Delete(intPID);
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

            ProModel.PK_PID = intPID;
            ProModel.LevelFactor = decLevelFactor;
            ProModel.JiBie = strJiBie;

            //更新
            ProBll.UpdateJiBie(ProModel);

            GridView1.EditIndex = -1;
            BindData();
        }
        #endregion

        #region 保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strXueKe = ddlXueKe.SelectedValue;
            string strSource = txtSource.Text;
            decimal decLevelFactor = Convert.ToDecimal(txtLevelFactor.Text);
            string strJiBie = ddlJiBie.SelectedValue;

            ProModel.XueKe = strXueKe;
            ProModel.Source = strSource;
            ProModel.LevelFactor = decLevelFactor;
            ProModel.JiBie = strJiBie;

            if (ProBll.Exists(ProModel))
            {
                MessageBox.Show(this, "已经存在该记录！");
            }
            else
            {
                ProBll.Add(ProModel);
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