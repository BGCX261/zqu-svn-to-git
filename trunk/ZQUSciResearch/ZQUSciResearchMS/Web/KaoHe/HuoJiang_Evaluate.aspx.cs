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

namespace Web.KaoHe
{
    public partial class HuoJiang_Evaluate : System.Web.UI.Page
    {
        private ZQUSR.Model.sr_Evaluate EvalModel = new ZQUSR.Model.sr_Evaluate();
        private ZQUSR.BLL.sr_Evaluate EvalBll = new ZQUSR.BLL.sr_Evaluate();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            //DataSet ds = new DataSet();
            //ds = EvalBll.GetEvaluateBySort("获奖成果");
            //GridView1.DataSource = ds;
            //GridView1.DataKeyNames = new string[] { "PK_EID" };
            //GridView1.DataBind();

            PagedDataSource pds = new PagedDataSource();
            DataSet ds = new DataSet();
            ds = EvalBll.GetEvaluateBySort("获奖成果");
            AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataSource = pds;
            GridView1.DataKeyNames = new string[] { "PK_EID" };
            GridView1.DataBind();
        }

        #region GridView相关操作
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int intEID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            EvalBll.Delete(intEID);
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
            int intEID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            decimal decLevelFactor = Convert.ToDecimal(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtLevelFactor")).Text);
            string strJiBie = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlJiBie")).SelectedValue;

            EvalModel.PK_EID = intEID;
            EvalModel.LevelFactor = decLevelFactor;
            EvalModel.JiBie = strJiBie;

            //更新
            EvalBll.UpdateJiBie(EvalModel);

            GridView1.EditIndex = -1;
            BindData();
        }
        #endregion

        #region 保存
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strType = ddlType.SelectedValue;
            string strGrade = txtGrade.Text;
            string strAwardGrade = ddlAwardGrade.SelectedValue;
            decimal decLevelFactor = Convert.ToDecimal(txtLevelFactor.Text);
            string strJiBie = ddlJiBie.SelectedValue;

            EvalModel.Sort = "获奖成果";
            EvalModel.Type = strType;
            EvalModel.Grade = strGrade;
            EvalModel.AwardGrade = strAwardGrade;
            EvalModel.LevelFactor = decLevelFactor;
            EvalModel.JiBie = strJiBie;

            if (EvalBll.ExistsTypeGradeAwardGrade(EvalModel))
            {
                MessageBox.Show(this, "已经存在该记录！");
            }
            else
            {
                EvalBll.Add(EvalModel);
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
