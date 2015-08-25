using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ZQUSR.BLL;

namespace Web.SciResearch
{
    public partial class Project_Add : System.Web.UI.Page
    {
        private ZQUSR.BLL.PageValidate PageValidateBll = new ZQUSR.BLL.PageValidate();
        private ZQUSR.BLL.sr_Project ProBll = new ZQUSR.BLL.sr_Project();
        private ZQUSR.Model.sr_Project ProModel = new ZQUSR.Model.sr_Project();
        private ZQUSR.BLL.sr_Evaluate EvaluateBll = new ZQUSR.BLL.sr_Evaluate();
        private ZQUSR.Model.sr_Evaluate EvaluateModel = new ZQUSR.Model.sr_Evaluate();
        private ZQUSR.BLL.sr_LevelScores LevelScoresBll = new ZQUSR.BLL.sr_LevelScores();
        private ZQUSR.BLL.sr_WordsFunds WordsFundsBll = new ZQUSR.BLL.sr_WordsFunds();
        private ZQUSR.Model.sr_WordsFunds WordsFundsModel = new ZQUSR.Model.sr_WordsFunds();
        private ZQUSR.BLL.sr_Calculate3 Cal3Bll = new ZQUSR.BLL.sr_Calculate3();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cmd = Request.QueryString["cmd"].ToString();
                if (cmd == "add")   //若为添加则自动生成编号
                {
                    TabContainer1.Tabs[0].HeaderText = "科研项目添加";
                    txtPID.Text = "KY" + CreateNumber.GetNumber();
                }
                if (cmd == "modify")    //若为修改则绑定数据到文本框
                {
                    TabContainer1.Tabs[0].HeaderText = "科研项目修改";
                    string srid = Request.QueryString["srid"].ToString();
                    if (srid != "")
                    {
                        ProModel = ProBll.GetModel(srid);
                        if (ProModel != null)
                        {
                            txtPID.Text = ProModel.PK_PID;
                            txtFinishTime.Text = string.Format("{0:yyyy-MM-dd}", ProModel.PublishTime1);
                        }
                    }
                }
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSource.DataSource = EvaluateBll.GetSourceBySortType("科研项目", ddlType.SelectedValue);
            ddlSource.DataTextField = "Source";
            ddlSource.DataBind();
            ddlSource.Items.Insert(0, new ListItem("请选择...", "-1"));
        }

        #region 保存函数
        private void Save(string strAuditState)
        {
            if (Session["UserID"] != null)
            {
                string cmd = Request.QueryString["cmd"].ToString();
                try
                {
                    if (ddlType.SelectedValue == "-1")
                    {
                        MessageBox.Show(this, "请选择项目类型！");
                        ddlType.Focus();
                    }
                    else if (txtTitle.Text == "")
                    {
                        MessageBox.Show(this, "项目名称不能为空！");
                        txtTitle.Focus();
                    }
                    else if (ddlSource.SelectedValue == "-1")
                    {
                        MessageBox.Show(this, "请选择项目来源！");
                        ddlSource.Focus();
                    }
                    else if (txtFinishTime.Text == "")
                    {
                        MessageBox.Show(this, "项目完成日期不能为空！");
                        txtFinishTime.Focus();
                    }
                    else if (!PageValidateBll.IsDateTime(txtFinishTime.Text))
                    {
                        MessageBox.Show(this, "项目完成日期格式不正确！");
                        txtFinishTime.Focus();
                    }
                    else if (txtFund1.Text == "")
                    {
                        MessageBox.Show(this, "实到经费不能为空！");
                        txtFund1.Focus();
                    }
                    else if (ddlSchoolSign.SelectedValue == "-1")
                    {
                        MessageBox.Show(this, "请选择学校署名排名！");
                        ddlSchoolSign.Focus();
                    }
                    else if (ddlAnchorperson.SelectedValue == "-1")
                    {
                        MessageBox.Show(this, "请选择是否项目主持人！");
                        ddlAnchorperson.Focus();
                    }
                    else if (txtPopulation.Text == "")
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
                        string strPID = txtPID.Text;    //项目编号
                        string strUserID = Session["UserID"].ToString();     //用户编号
                        string strBigSort = "科研业绩";    //大类别
                        string strSmallSort = "科研项目";    //小类别
                        string strType = ddlType.SelectedValue;     //项目类型
                        string strTitle = txtTitle.Text;    //项目名称
                        DateTime dtAddTime = DateTime.Now;  //提交时间
                        string strSource = ddlSource.SelectedItem.Text;  //项目来源
                        DateTime dtPublishTime = Convert.ToDateTime(txtFinishTime.Text);  //项目完成日期
                        decimal decFunds1 = decimal.Parse(txtFund1.Text);   //实到经费
                        string strSchoolSign = ddlSchoolSign.SelectedItem.Text;     //学校署名排名
                        int intAnchorPerson = Convert.ToInt32(ddlAnchorperson.SelectedValue);   //是否项目主持人
                        int intPopulation = Convert.ToInt32(txtPopulation.Text);    //完成人数
                        string strAllAuthor = txtAllAuthor.Text;    //参与作者
                        string strRemark = txtRemark.Text;  //备注

                        ProModel.PK_PID = strPID;
                        ProModel.FK_UserID = strUserID;
                        ProModel.BigSort = strBigSort;
                        ProModel.SmallSort = strSmallSort;
                        ProModel.Type = strType;
                        ProModel.Title = strTitle;
                        ProModel.AddTime = dtAddTime;
                        ProModel.Source = strSource;
                        ProModel.PublishTime1 = dtPublishTime;
                        ProModel.Funds1 = decFunds1;
                        ProModel.Anchorperson = intAnchorPerson;
                        ProModel.Population = intPopulation;
                        ProModel.AllAuthor = strAllAuthor;
                        ProModel.SchoolSign = strSchoolSign;
                        ProModel.Remark = strRemark;
                        ProModel.AuditState = strAuditState;

                        //计算级别分
                        EvaluateModel = EvaluateBll.GetXiangMuJiBie(ProModel);
                        string strJiBie = "";   //级别
                        decimal decLevelFactor = 0;     //级别分系数
                        decimal decJiBieScore = 0;      //级别分

                        if (EvaluateModel != null)
                        {
                            strJiBie = EvaluateModel.JiBie;
                            decLevelFactor = Convert.ToDecimal(EvaluateModel.LevelFactor);
                            ProModel.JiBie = strJiBie;  //级别
                            ProModel.LevelFactor = decLevelFactor;  //级别分系数

                            int intScore = LevelScoresBll.GetScoreByJiBie(strJiBie);    //根据级别得到对应的级别分数
                            decJiBieScore = intScore * decLevelFactor;  //级别分
                        }

                        //计算经费分
                        decimal decFundScore = 0;
                        WordsFundsModel = WordsFundsBll.GetModel(strSmallSort, strType); ;
                        if (decFunds1 <= WordsFundsModel.Digit2)
                        {
                            decFundScore = decFunds1 * Convert.ToDecimal(WordsFundsModel.Digit1);
                        }
                        else if (decFunds1 > WordsFundsModel.Digit2 && decFunds1 <= WordsFundsModel.Digit4)
                        {
                            decFundScore = Convert.ToDecimal(WordsFundsModel.Digit2) * Convert.ToDecimal(WordsFundsModel.Digit1) + (decFunds1 - Convert.ToDecimal(WordsFundsModel.Digit2)) * Convert.ToDecimal(WordsFundsModel.Digit3);
                        }
                        else if (decFunds1 > WordsFundsModel.Digit4 && decFunds1 <= WordsFundsModel.Digit6)
                        {
                            decFundScore = Convert.ToDecimal(WordsFundsModel.Digit2) * Convert.ToDecimal(WordsFundsModel.Digit1) + (Convert.ToDecimal(WordsFundsModel.Digit4) - Convert.ToDecimal(WordsFundsModel.Digit2)) * Convert.ToDecimal(WordsFundsModel.Digit3) + (decFunds1 - Convert.ToDecimal(WordsFundsModel.Digit4)) * Convert.ToDecimal(WordsFundsModel.Digit5);
                        }
                        else if (decFunds1 > 100)
                        {
                            decFundScore = Convert.ToDecimal(WordsFundsModel.Digit2) * Convert.ToDecimal(WordsFundsModel.Digit1) + (Convert.ToDecimal(WordsFundsModel.Digit4) - Convert.ToDecimal(WordsFundsModel.Digit2)) * Convert.ToDecimal(WordsFundsModel.Digit3) + (Convert.ToDecimal(WordsFundsModel.Digit6) - Convert.ToDecimal(WordsFundsModel.Digit4)) * Convert.ToDecimal(WordsFundsModel.Digit5) + (decFunds1 - Convert.ToDecimal(WordsFundsModel.Digit6)) * Convert.ToDecimal(WordsFundsModel.Digit7);
                        }

                        //计算个人得分
                        decimal decPerScore = 0;    //个人得分
                        //判断是否多人合作
                        if (intPopulation > 1)
                        {
                            decimal decScale = Cal3Bll.GetProjectScale("是");
                            //是否项目主持人
                            if (ddlAnchorperson.SelectedValue == "0")
                            {
                                decPerScore = (decJiBieScore + decFundScore) * decScale;
                            }
                            else
                            {
                                decPerScore = (decJiBieScore + decFundScore) * (1 - decScale) / (intPopulation - 1);
                            }

                            ProModel.PerScore = decPerScore;    //个人得分

                            if (cmd == "add")   //新增
                            {
                                if (!ProBll.Exists(strPID))
                                {
                                    ProBll.Add(ProModel);
                                }
                                else
                                {
                                    MessageBox.Show(this, "已经存在该记录！");
                                }
                            }
                            if (cmd == "modify")  //修改
                            {
                                ProBll.Update(ProModel);
                            }
                            Response.Redirect("Project_List.aspx");
                        }
                        else
                        {
                            decPerScore = decJiBieScore + decFundScore;
                            ProModel.PerScore = decPerScore;    //个人得分

                            if (cmd == "add")   //新增
                            {
                                if (!ProBll.Exists(strPID))
                                {
                                    ProBll.Add(ProModel);
                                }
                                else
                                {
                                    MessageBox.Show(this, "已经存在该记录！");
                                }
                            }
                            if (cmd == "modify")  //修改
                            {
                                ProBll.Update(ProModel);
                            }
                            Response.Redirect("Project_List.aspx");
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
    }
}
