using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ZQUSR.BLL;
using ZQUSR.Model;

namespace Web.SciResearch
{
    public partial class RuanKeXue : System.Web.UI.Page
    {
        private ZQUSR.BLL.PageValidate PageValidateBll = new ZQUSR.BLL.PageValidate();

        private ZQUSR.BLL.sr_Evaluate EvaluateBll = new ZQUSR.BLL.sr_Evaluate();
        private ZQUSR.Model.sr_Evaluate EvaluateModel = new ZQUSR.Model.sr_Evaluate();
        private ZQUSR.Model.sr_Achievement AchievementModel = new ZQUSR.Model.sr_Achievement();
        private ZQUSR.BLL.sr_Achievement AchievementBll = new ZQUSR.BLL.sr_Achievement();
        private ZQUSR.BLL.sr_LevelScores LevelScoresBll = new ZQUSR.BLL.sr_LevelScores();
        private ZQUSR.Model.sr_Calculate2 Cal2Model = new ZQUSR.Model.sr_Calculate2();
        private ZQUSR.BLL.sr_Calculate2 Cal2Bll = new ZQUSR.BLL.sr_Calculate2();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cmd = Request.QueryString["cmd"].ToString();
                if (cmd == "add")   //若为添加则自动生成编号
                {
                    TabContainer1.Tabs[0].HeaderText = "软科学成果添加";
                    txtAID.Text = "RK" + CreateNumber.GetNumber();
                }
                if (cmd == "modify")    //若为修改则绑定数据到文本框
                {
                    TabContainer1.Tabs[0].HeaderText = "软科学成果修改";
                    string srid = Request.QueryString["srid"].ToString();
                    if (srid != "")
                    {
                        AchievementModel = AchievementBll.GetModel(srid);
                        if (AchievementModel != null)
                        {
                            //绑定数据到文本框
                        }
                    }
                }
                BindDdlUnit();
            }
        }

        #region 绑定采纳部门下拉列表
        private void BindDdlUnit()
        {
            ddlUnit.DataSource = EvaluateBll.GetSourceByClass("软科学成果");
            ddlUnit.DataTextField = "Source";
            //ddlUnit.DataValueField = "PK_EID";
            ddlUnit.DataBind();
            ddlUnit.Items.Insert(0, new ListItem("请选择...", "-1"));
        }
        #endregion

        #region 保存
        private void Save(string strAuditState)
        {
            if (Session["UserID"] != null)
            {
                string cmd = Request.QueryString["cmd"].ToString();
                try
                {
                    if (txtTime.Text == "")
                    {
                        MessageBox.Show(this, "采纳日期不能为空！");
                        txtTime.Focus();
                    }
                    else if (!PageValidateBll.IsDateTime(txtTime.Text))
                    {
                        MessageBox.Show(this, "采纳日期格式不正确！");
                        txtTime.Focus();
                    }
                    else if (txtTitle.Text == "")
                    {
                        MessageBox.Show(this, "成果名称不能为空！");
                        txtTitle.Focus();
                    }
                    else if (ddlUnit.SelectedValue == "-1")
                    {
                        MessageBox.Show(this, "请选择采纳部门！");
                        ddlUnit.Focus();
                    }
                    else if (ddlSchoolSign.SelectedValue == "-1")
                    {
                        MessageBox.Show(this, "请选择学校署名排名！");
                        ddlSchoolSign.Focus();
                    }
                    else if (ddlRank.SelectedValue == "-1")
                    {
                        MessageBox.Show(this, "请选择完成成果排名！");
                        ddlRank.Focus();
                    }
                    else
                    {
                        string strAID = txtAID.Text;    //成果编号
                        string strUserID = Session["UserID"].ToString();     //用户编号
                        string strBigSort = "科研业绩";    //大类别
                        string strSmallSort = "软科学成果";    //小类别
                        string strTitle = txtTitle.Text;    //成果名称
                        DateTime dtAddTime = DateTime.Now;  //提交时间
                        string strUnit = ddlUnit.SelectedItem.Text;  //采纳部门
                        DateTime dtPublishTime = Convert.ToDateTime(txtTime.Text);  //采纳日期
                        int intRank = Convert.ToInt32(ddlRank.SelectedValue);   //完成成果排名
                        string strSchoolSign = ddlSchoolSign.SelectedItem.Text;     //学校署名排名
                        string strRemark = txtRemark.Text;  //备注

                        AchievementModel.PK_AID = strAID;   //成果编号
                        AchievementModel.FK_UserID = strUserID;   //用户编号
                        AchievementModel.BigSort = strBigSort;    //大类别
                        AchievementModel.SmallSort = strSmallSort;  //小类别
                        AchievementModel.Title = strTitle;  //成果名称
                        AchievementModel.AddTime = dtAddTime;   //提交时间
                        AchievementModel.Unit = strUnit;    //采纳部门
                        AchievementModel.PublishTime = dtPublishTime;   //采纳日期
                        AchievementModel.Rank = intRank;    //完成成果排名
                        AchievementModel.SchoolSign = strSchoolSign;    //学校署名排名
                        AchievementModel.Remark = strRemark;    //备注
                        AchievementModel.AuditState = strAuditState;  //审核状态

                        //计算成果总得分
                        EvaluateModel = EvaluateBll.GetRuanKeXueJiBie(AchievementModel);
                        string strJiBie = "";   //级别
                        decimal decLevelFactor = 0;     //级别分系数
                        decimal decScore = 0;   //成果总得分
                        if (EvaluateModel != null)
                        {
                            strJiBie = EvaluateModel.JiBie;
                            decLevelFactor = Convert.ToDecimal(EvaluateModel.LevelFactor);
                            AchievementModel.JiBie = strJiBie;  //级别
                            AchievementModel.LevelFactor = decLevelFactor;  //级别分系数

                            int intScore = LevelScoresBll.GetScoreByJiBie(strJiBie);    //根据级别得到对应的级别分数
                            decScore = intScore * decLevelFactor;
                        }


                        //计算成果个人得分
                        int intPopulation = 1;      //完成人数
                        string strAllAuthor = "";   //参与作者
                        decimal decPerScore = 0;    //个人得分
                        //根据完成成果排名判断是否为多人合作，若是则按多人合作个人所占比例规则计算得分
                        //若否则成果总得分即为个人得分 
                        if (!(intRank == -1 || intRank == 0))
                        {
                            if (txtPopulation.Text == "")
                            {
                                MessageBox.Show(this, "完成人数不能为空！");
                                txtPopulation.Focus();
                            }
                            else if (!PageValidateBll.IsNumber(txtPopulation.Text))
                            {
                                MessageBox.Show(this, "完成人数只能填写数字！");
                                txtPopulation.Focus();
                            }
                            else if (txtAllAuthor.Text == "")
                            {
                                MessageBox.Show(this, "参与作者不能为空！");
                                txtAllAuthor.Focus();
                            }
                            else
                            {
                                intPopulation = Convert.ToInt32(txtPopulation.Text);
                                strAllAuthor = txtAllAuthor.Text;
                                //根据完成人数和完成成果排名返回对应的得分比例
                                Cal2Model = Cal2Bll.GetScoreScale(intPopulation, intRank);
                                if (Cal2Model != null)
                                {
                                    string strScale = Cal2Model.ScoreScale;
                                    string[] str = strScale.Split('/');
                                    int int1 = int.Parse(str[0]);
                                    int int2 = int.Parse(str[1]);
                                    decPerScore = decScore * int1 / int2;
                                    AchievementModel.Population = intPopulation;    //完成人数
                                    AchievementModel.AllAuthor = strAllAuthor;  //参与作者
                                    AchievementModel.PerScore = decPerScore;    //个人得分

                                    if (cmd == "add")   //新增
                                    {
                                        if (!AchievementBll.Exists(strAID))
                                        {
                                            AchievementBll.Add(AchievementModel);
                                        }
                                        else
                                        {
                                            MessageBox.Show(this, "已经存在该记录");
                                        }
                                    }
                                    if (cmd == "modify")  //修改
                                    {
                                        AchievementBll.Update(AchievementModel);
                                    }
                                    Response.Redirect("RuanKeXue_List.aspx");
                                }
                            }
                        }
                        else
                        {
                            decPerScore = decScore;
                            AchievementModel.Population = intPopulation;    //完成人数
                            AchievementModel.AllAuthor = strAllAuthor;  //参与作者
                            AchievementModel.PerScore = decPerScore;    //个人得分
                            if (cmd == "add")   //新增
                            {
                                if (!AchievementBll.Exists(strAID))
                                {
                                    AchievementBll.Add(AchievementModel);
                                }
                                else
                                {
                                    MessageBox.Show(this, "已经存在该记录");
                                }
                            }
                            if (cmd == "modify")  //修改
                            {
                                AchievementBll.Update(AchievementModel);
                            }
                            Response.Redirect("RuanKeXue_List.aspx");
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('您已经与服务器断开连接，请重新登录！');window.location.href='~/../../login.aspx';</script>");
            }
        }
        #endregion

        #region 保存未提交
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save("0");
        }
        #endregion

        #region 保存并提交
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "教师")
                {
                    Save("1");
                }
                else
                {
                    Save("3");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('您已经与服务器断开连接，请重新登录！');window.location.href='~/../../login.aspx';</script>");
            }
        }
        #endregion

        #region 完成成果排名非独立时显示完成人数与参与作者文本框
        protected void ddlRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intRank = Convert.ToInt32(ddlRank.SelectedValue);
            if (intRank == -1 || intRank == 0)
            {
                txtPopulation.Text = "";
                txtAllAuthor.Text = "";
                lblPopulation1.Visible = false;
                lblPopulation2.Visible = false;
                txtPopulation.Visible = false;
                reqPopulation.Visible = false;
                lblAllAuthor1.Visible = false;
                lblAllAuthor2.Visible = false;
                txtAllAuthor.Visible = false;
                reqAllAuthor.Visible = false;
            }
            else
            {
                lblPopulation1.Visible = true;
                lblPopulation2.Visible = true;
                txtPopulation.Visible = true;
                reqPopulation.Visible = true;
                lblAllAuthor1.Visible = true;
                lblAllAuthor2.Visible = true;
                txtAllAuthor.Visible = true;
                reqAllAuthor.Visible = true;
            }
        }
        #endregion
    }
}

