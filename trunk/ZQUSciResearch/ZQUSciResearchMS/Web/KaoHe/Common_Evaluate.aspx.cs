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

namespace Web.KaoHe
{
    public partial class Common_Evaluate : System.Web.UI.Page
    {
        private ZQUSR.Model.sr_LevelScores LevelScoresModel = new ZQUSR.Model.sr_LevelScores();
        private ZQUSR.BLL.sr_LevelScores LevelScoresBll = new ZQUSR.BLL.sr_LevelScores();

        private ZQUSR.Model.sr_Calculate1 Cal1Model = new ZQUSR.Model.sr_Calculate1();
        private ZQUSR.BLL.sr_Calculate1 Cal1Bll = new ZQUSR.BLL.sr_Calculate1();

        private ZQUSR.Model.sr_Calculate2 Cal2Model = new ZQUSR.Model.sr_Calculate2();
        private ZQUSR.BLL.sr_Calculate2 Cal2Bll = new ZQUSR.BLL.sr_Calculate2();

        private ZQUSR.Model.sr_Calculate3 Cal3Model = new ZQUSR.Model.sr_Calculate3();
        private ZQUSR.BLL.sr_Calculate3 Cal3Bll = new ZQUSR.BLL.sr_Calculate3();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData_GridView1();
                //BindData_GridView2();
                BindData_GridView3();
                BindData_GridView4();
            }
        }

        #region 级别分数
        private void BindData_GridView1()
        {
            DataSet ds = new DataSet();
            ds = LevelScoresBll.GetList();
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "PK_ID" };
            GridView1.DataBind();
        } 
        #endregion

        //private void BindData_GridView2()
        //{
        //    DataSet ds = new DataSet();
        //    ds = EvalBll.GetEvaluateBySort("专利成果");
        //    GridView2.DataSource = ds;
        //    GridView2.DataKeyNames = new string[] { "PK_EID" };
        //    GridView2.DataBind();
        //}

        #region 计分通则二
        private void BindData_GridView3()
        {
            PagedDataSource pds = new PagedDataSource();
            DataSet ds = new DataSet();
            ds = Cal2Bll.GetList();
            AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = ds.Tables[0].DefaultView;
            GridView3.DataSource = pds;
            GridView3.DataKeyNames = new string[] { "PK_CID" };
            GridView3.DataBind();
        } 
        #endregion

        #region 计分通则三
        private void BindData_GridView4()
        {
            DataSet ds = new DataSet();
            ds = Cal3Bll.GetList();
            GridView4.DataSource = ds;
            GridView4.DataKeyNames = new string[] { "PK_CID" };
            GridView4.DataBind();
        } 
        #endregion

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData_GridView3();
        }

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
            BindData_GridView1();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData_GridView1();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int intID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            int intScore = Convert.ToInt32(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtScore")).Text);

            LevelScoresModel.PK_ID = intID;
            LevelScoresModel.Score = intScore;

            //更新
            LevelScoresBll.UpdateScore(LevelScoresModel);

            GridView1.EditIndex = -1;
            BindData_GridView1();
        }
        #endregion

        #region GridView3 相关操作
        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView3.EditIndex = e.NewEditIndex;
            BindData_GridView3();
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            BindData_GridView3();
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int intCID = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value);
            string strScoreScale = ((TextBox)GridView3.Rows[e.RowIndex].FindControl("txtScoreScale")).Text;

            Cal2Model.PK_CID = intCID;
            Cal2Model.ScoreScale = strScoreScale;

            //更新
            Cal2Bll.UpdateScoreScale(Cal2Model);

            GridView3.EditIndex = -1;
            BindData_GridView3();
        } 
        #endregion

        #region GridView4 相关操作
        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
            BindData_GridView4();
        }

        protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView4.EditIndex = -1;
            BindData_GridView4();
        }

        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int intCID = Convert.ToInt32(GridView4.DataKeys[e.RowIndex].Value);
            decimal decScale = Convert.ToDecimal(((TextBox)GridView4.Rows[e.RowIndex].FindControl("txtScale")).Text);

            Cal3Model.PK_CID = intCID;
            Cal3Model.Scale = decScale;

            //更新
            Cal3Bll.UpdateScale(Cal3Model);

            GridView4.EditIndex = -1;
            BindData_GridView4();
        }
        #endregion
    }
}