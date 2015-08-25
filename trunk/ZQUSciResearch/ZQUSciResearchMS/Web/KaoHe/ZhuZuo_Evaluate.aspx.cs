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
    public partial class ZhuZuo_Evaluate : System.Web.UI.Page
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
            DataSet ds = new DataSet();
            ds = EvalBll.GetEvaluateBySort("学术著作");
            GridView1.DataSource = ds;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strSource = txtSource.Text;
            string strType = ddlType.SelectedValue;
            decimal decLevelFactor = Convert.ToDecimal(txtLevelFactor.Text);
            string strJiBie = ddlJiBie.SelectedValue;

            EvalModel.Sort = "学术著作";
            EvalModel.Source = strSource;
            EvalModel.Type = strType;
            EvalModel.LevelFactor = decLevelFactor;
            EvalModel.JiBie = strJiBie;

            if (EvalBll.ExistsTypeSource(EvalModel))
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
    }
}
