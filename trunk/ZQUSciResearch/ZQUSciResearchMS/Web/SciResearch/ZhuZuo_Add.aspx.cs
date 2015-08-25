using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ZQUSR.BLL;

namespace Web.SciResearch
{
    public partial class ZhuZuo_Add : System.Web.UI.Page
    {
        private ZQUSR.BLL.PageValidate PageValidateBll = new ZQUSR.BLL.PageValidate();
        private ZQUSR.BLL.sr_LwZzJc LZJBll = new ZQUSR.BLL.sr_LwZzJc();
        private ZQUSR.Model.sr_LwZzJc LZJModel = new ZQUSR.Model.sr_LwZzJc();
        private ZQUSR.BLL.sr_Evaluate EvaluateBll = new ZQUSR.BLL.sr_Evaluate();
        private ZQUSR.Model.sr_Evaluate EvaluateModel = new ZQUSR.Model.sr_Evaluate();
        private ZQUSR.BLL.sr_LevelScores LevelScoresBll = new ZQUSR.BLL.sr_LevelScores();
        private ZQUSR.BLL.sr_WordsFunds WordsFundsBll = new ZQUSR.BLL.sr_WordsFunds();
        private ZQUSR.Model.sr_WordsFunds WordsFundsModel = new ZQUSR.Model.sr_WordsFunds();
        private ZQUSR.Model.sr_Calculate2 Cal2Model = new ZQUSR.Model.sr_Calculate2();
        private ZQUSR.BLL.sr_Calculate2 Cal2Bll = new ZQUSR.BLL.sr_Calculate2();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDdlType();  //绑定著作类型下拉列表
                BindDdlSource();    //绑定著作来源下拉列表
                //BindDdlSchoolSign();    //绑定学校署名排名下拉列表
                string cmd = Request.QueryString["cmd"].ToString();
                if (cmd == "add")   //若为添加则自动生成编号
                {
                    TabContainer1.Tabs[0].HeaderText = "学术著作添加";
                    txtLZID.Text = "ZZ" + CreateNumber.GetNumber();
                }
                if (cmd == "modify")    //若为修改则绑定数据到文本框
                {
                    TabContainer1.Tabs[0].HeaderText = "学术著作修改";
                    string srid = Request.QueryString["srid"].ToString();
                    if (srid != "")
                    {
                        LZJModel = LZJBll.GetModel(srid);
                        if (LZJModel != null)
                        {
                            txtLZID.Text = LZJModel.PK_LZID;
                            ddlType.Text = LZJModel.Type;
                            txtTitle.Text = LZJModel.Title;
                            txtUnit.Text = LZJModel.Unit;
                            txtTime.Text = string.Format("{0:yyyy-MM-dd}", LZJModel.PublishTime);
                            ddlSource.Text = LZJModel.Source;
                            //txtISBN.Text = LZJModel.Number1;
                            txtWord.Text = LZJModel.Word.ToString();
                            ddlSchoolSign.Text = LZJModel.SchoolSign;
                            ddlRank.Text = StateInfo.GetRank((LZJModel.Rank).ToString());
                            txtPopulation.Text = LZJModel.Population.ToString();
                            txtAllAuthor.Text = LZJModel.AllAuthor;
                            txtRemark.Text = LZJModel.Remark;
                        }
                    }
                }
            }
        }

        #region 绑定著作类型下拉列表
        private void BindDdlType()
        {
            ddlType.DataSource = EvaluateBll.GetTypeBySort("学术著作");
            ddlType.DataTextField = "Type";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("请选择...", "-1"));
        } 
        #endregion

        #region 绑定著作来源下拉列表
        private void BindDdlSource()
        {
            ddlSource.DataSource = EvaluateBll.GetSourceByClass("学术著作");
            ddlSource.DataTextField = "Source";
            ddlSource.DataBind();
            ddlSource.Items.Insert(0, new ListItem("请选择...", "-1"));
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
                    if (ddlType.SelectedValue == "-1")
                    {
                        MessageBox.Show(this, "请选择著作类型！");
                        ddlType.Focus();
                    }
                    else if (txtTitle.Text == "")
                    {
                        MessageBox.Show(this, "著作名称不能为空！");
                        txtTitle.Focus();
                    }
                    else if (txtUnit.Text == "")
                    {
                        MessageBox.Show(this, "出版单位不能为空！");
                        txtUnit.Focus();
                    }
                    else if (txtTime.Text == "")
                    {
                        MessageBox.Show(this, "出版日期不能为空！");
                        txtTime.Focus();
                    }
                    else if (!PageValidateBll.IsDateTime(txtTime.Text))
                    {
                        MessageBox.Show(this, "出版日期格式不正确！");
                        txtTime.Focus();
                    }
                    else if (ddlSource.SelectedValue == "-1")
                    {
                        MessageBox.Show(this, "请选择来源！");
                        ddlSource.Focus();
                    }
                    //else if (txtISBN.Text == "")
                    //{
                    //    MessageBox.Show(this, "ISBN号不能为空！");
                    //    txtISBN.Focus();
                    //}
                    else if (txtWord.Text == "")
                    {
                        MessageBox.Show(this, "字数不能为空！");
                        txtWord.Focus();
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
                        string strLZID = txtLZID.Text;    //著作编号
                        string strUserID = Session["UserID"].ToString();     //用户编号
                        string strBigSort = "科研成果";    //大类别
                        string strSmallSort = "学术著作";    //小类别
                        string strType = ddlType.SelectedItem.Text;     //著作类型
                        string strTitle = txtTitle.Text;    //著作名称
                        DateTime dtAddTime = DateTime.Now;  //提交时间
                        string strUnit = txtUnit.Text;  //出版单位
                        string strSource = ddlSource.SelectedItem.Text;  //来源
                        DateTime dtPublishTime = Convert.ToDateTime(txtTime.Text);  //出版日期
                        //string strNumber = txtISBN.Text;   //ISBN号
                        int intRank = Convert.ToInt32(ddlRank.SelectedValue);   //完成成果排名
                        string strSchoolSign = ddlSchoolSign.SelectedItem.Text;     //学校署名排名
                        decimal decWord = decimal.Parse(txtWord.Text);  //字数
                        string strRemark = txtRemark.Text;  //备注

                        LZJModel.PK_LZID = strLZID;     //著作编号
                        LZJModel.FK_UserID = strUserID;     //用户编号
                        LZJModel.BigSort = strBigSort;      //大类别
                        LZJModel.SmallSort = strSmallSort;    //小类别
                        LZJModel.Type = strType;     //著作类型
                        LZJModel.Title = strTitle;    //著作名称
                        LZJModel.Unit = strUnit;  //出版单位
                        LZJModel.Source = strSource;  //来源
                        LZJModel.PublishTime = dtPublishTime;  //出版日期
                        //LZJModel.Number1 = strNumber;   //ISBN号
                        LZJModel.Rank = intRank;   //完成成果排名
                        LZJModel.SchoolSign = strSchoolSign;     //学校署名排名
                        LZJModel.Word = decWord;  //字数
                        LZJModel.Remark = strRemark;  //备注
                        LZJModel.AddTime = dtAddTime;  //提交时间
                        LZJModel.AuditState = strAuditState;  //审核状态

                        //计算级别分
                        EvaluateModel = EvaluateBll.GetZhuZuoJiBie(LZJModel);
                        string strJiBie = "";   //级别
                        decimal decLevelFactor = 0;     //级别分系数
                        decimal decJiBieScore = 0;      //级别分

                        if (EvaluateModel != null)
                        {
                            strJiBie = EvaluateModel.JiBie;
                            decLevelFactor = Convert.ToDecimal(EvaluateModel.LevelFactor);
                            LZJModel.JiBie = strJiBie;  //级别
                            LZJModel.LevelFactor = decLevelFactor;  //级别分系数

                            int intScore = LevelScoresBll.GetScoreByJiBie(strJiBie);    //根据级别得到对应的级别分数
                            decJiBieScore = intScore * decLevelFactor;  //级别分
                        }

                        //计算字数分
                        WordsFundsModel = WordsFundsBll.GetModel("学术著作");
                        decimal decWordScore = 0;
                        if (decWord <= WordsFundsModel.Digit2)
                        {
                            decWordScore = decWord * Convert.ToDecimal(WordsFundsModel.Digit1);
                        }
                        else if (decWord > WordsFundsModel.Digit2)
                        {
                            decWordScore = Convert.ToDecimal(WordsFundsModel.Digit2) * Convert.ToDecimal(WordsFundsModel.Digit1) + Convert.ToDecimal(decWord - WordsFundsModel.Digit2) * Convert.ToDecimal(WordsFundsModel.Digit3);
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
                                    decPerScore = (decJiBieScore + decWordScore) * int1 / int2;   //个人得分=（级别分+字数分） * 比例

                                    LZJModel.Population = intPopulation;    //完成人数
                                    LZJModel.AllAuthor = strAllAuthor;  //参与作者
                                    LZJModel.PerScore = decPerScore;    //个人得分

                                    if (cmd == "add")   //新增
                                    {
                                        if (!LZJBll.Exists(strLZID))
                                        {
                                            LZJBll.Add(LZJModel);
                                        }
                                        else
                                        {
                                            MessageBox.Show(this, "已经存在该记录产！");
                                        }
                                    }
                                    if (cmd == "modify")  //修改
                                    {
                                        LZJBll.Update(LZJModel);
                                    }
                                    Response.Redirect("ZhuZuo_List.aspx");
                                }
                            }
                        }
                        else
                        {
                            decPerScore = decJiBieScore + decWordScore;
                            LZJModel.Population = intPopulation;    //完成人数
                            LZJModel.AllAuthor = strAllAuthor;  //参与作者
                            LZJModel.PerScore = decPerScore;    //个人得分

                            if (cmd == "add")   //新增
                            {
                                if (!LZJBll.Exists(strLZID))
                                {
                                    LZJBll.Add(LZJModel);
                                }
                                else
                                {
                                    MessageBox.Show(this, "已经存在该记录产！");
                                }
                            }
                            if (cmd == "modify")  //修改
                            {
                                LZJBll.Update(LZJModel);
                            }
                            Response.Redirect("ZhuZuo_List.aspx");
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
