using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ZQUSR.BLL;

namespace Web.SciResearch
{
    public partial class Thesis_Add : System.Web.UI.Page
    {
        private ZQUSR.BLL.PageValidate PageValidateBll = new ZQUSR.BLL.PageValidate();
        private ZQUSR.Model.sr_Periodicals PeriModel = new ZQUSR.Model.sr_Periodicals();
        private ZQUSR.BLL.sr_Periodicals PeriBll = new ZQUSR.BLL.sr_Periodicals();
        private ZQUSR.BLL.sr_LwZzJc LZJBll = new ZQUSR.BLL.sr_LwZzJc();
        private ZQUSR.Model.sr_LwZzJc LZJModel = new ZQUSR.Model.sr_LwZzJc();
        private ZQUSR.Model.sr_Lunwen LunwenModel = new ZQUSR.Model.sr_Lunwen();
        private ZQUSR.BLL.sr_Lunwen LunwenBll = new ZQUSR.BLL.sr_Lunwen();
        private ZQUSR.BLL.sr_LevelScores LevelScoresBll = new ZQUSR.BLL.sr_LevelScores();
        private ZQUSR.Model.sr_Calculate2 Cal2Model = new ZQUSR.Model.sr_Calculate2();
        private ZQUSR.BLL.sr_Calculate2 Cal2Bll = new ZQUSR.BLL.sr_Calculate2();

        protected void Page_Load(object sender, EventArgs e)
        {
            //txtNumber1、txtNumber2 失去焦点时触发事件
            //this.txtNumber1.Attributes["onblur"] = ClientScript.GetPostBackEventReference(txtNumber1, null);
            //this.txtNumber2.Attributes["onblur"] = ClientScript.GetPostBackEventReference(txtNumber2, null);

            if (!IsPostBack)
            {
                BindDdlState(); //  绑定收录/转载情况下拉列表
                string cmd = Request.QueryString["cmd"].ToString();
                if (cmd == "add")   //若为添加则自动生成编号
                {
                    TabContainer1.Tabs[0].HeaderText = "学术论文添加";
                    txtLZID.Text = "LW" + CreateNumber.GetNumber();
                }
                if (cmd == "modify")    //若为修改则绑定数据到文本框
                {
                    TabContainer1.Tabs[0].HeaderText = "学术论文修改";
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

        #region 绑定收录/转载情况下拉列表
        private void BindDdlState()
        {
            ddlState.DataSource = LunwenBll.GetSituation();
            ddlState.DataTextField = "Situation";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("请选择...", "-1"));
            ddlState.Items.Insert(1, new ListItem("无", "0"));
        }
        #endregion

        #region 当输入期刊号时自动完成期刊名称的输入
        //protected void txtNumber1_TextChanged(object sender, EventArgs e)
        //{
        //    string strName = PeriBll.GetQikanNameByISSN(txtNumber1.Text);
        //    txtUnit.Text = strName;
        //} 
        
        //protected void txtNumber2_TextChanged(object sender, EventArgs e)
        //{
        //    string strName = PeriBll.GetQikanNameByISSN(txtNumber2.Text);
        //    txtStateUnit.Text = strName;
        //} 
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
                        MessageBox.Show(this, "请选择论文类型！");
                        ddlType.Focus();
                    }
                    else if (txtTitle.Text == "")
                    {
                        MessageBox.Show(this, "论文题目不能为空！");
                        txtTitle.Focus();
                    }
                    //else if (txtNumber1.Text == "")
                    //{
                    //    MessageBox.Show(this, "发表刊物期刊号不能为空！");
                    //    txtNumber1.Focus();
                    //}
                    else if (txtUnit.Text == "")
                    {
                        MessageBox.Show(this, "发表刊物名称不能为空！");
                        txtUnit.Focus();
                    }
                    else if (txtTime.Text == "")
                    {
                        MessageBox.Show(this, "发表日期不能为空！");
                        txtTime.Focus();
                    }
                    else if (!PageValidateBll.IsDateTime(txtTime.Text))
                    {
                        MessageBox.Show(this, "发表日期格式不正确！");
                        txtTime.Focus();
                    }
                    else if (ddlState.SelectedValue == "-1")
                    {
                        MessageBox.Show(this, "请选择收录/转载情况！");
                        ddlState.Focus();
                    }
                    //else if (txtNumber2.Text == "")
                    //{
                    //    MessageBox.Show(this, "收录/转载期刊号不能为空！");
                    //    txtNumber2.Focus();
                    //}
                    //else if (txtStateUnit.Text == "")
                    //{
                    //    MessageBox.Show(this, "收录/转载期刊名称不能为空！");
                    //    txtStateUnit.Focus();
                    //}
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
                        string strLZID = txtLZID.Text;    //论文编号
                        string strUserID = Session["UserID"].ToString();     //用户编号
                        string strBigSort = "科研成果";    //大类别
                        string strSmallSort = "学术论文";    //小类别
                        string strType = ddlType.SelectedItem.Text;     //论文类型
                        string strTitle = txtTitle.Text;    //论文题目
                        DateTime dtAddTime = DateTime.Now;  //提交时间
                        //string strNumber1 = txtNumber1.Text;    //发表刊物期刊号
                        string strUnit = txtUnit.Text;  //发表刊物名称
                        DateTime dtPublishTime = Convert.ToDateTime(txtTime.Text);  //发表日期
                        string strState = ddlState.SelectedItem.Text;   //收录/转载情况：
                        int intRank = Convert.ToInt32(ddlRank.SelectedValue);   //完成成果排名
                        string strSchoolSign = ddlSchoolSign.SelectedItem.Text;     //学校署名排名
                        string strRemark = txtRemark.Text;  //备注

                        LZJModel.PK_LZID = strLZID;     //论文编号
                        LZJModel.FK_UserID = strUserID;     //用户编号
                        LZJModel.BigSort = strBigSort;      //大类别
                        LZJModel.SmallSort = strSmallSort;    //小类别
                        LZJModel.Type = strType;     //论文类型
                        LZJModel.Title = strTitle;    //论文题目
                        //LZJModel.Number1 = strNumber1;  //发表刊物期刊号
                        LZJModel.Unit = strUnit;  //发表刊物名称
                        LZJModel.PublishTime = dtPublishTime;  //发表日期
                        LZJModel.Rank = intRank;   //完成成果排名
                        LZJModel.SchoolSign = strSchoolSign;     //学校署名排名
                        LZJModel.Remark = strRemark;  //备注
                        LZJModel.AddTime = dtAddTime;  //提交时间
                        LZJModel.AuditState = strAuditState;  //审核状态



                        //计算级别分

                        string strJiBie = "";   //级别
                        decimal decLevelFactor = 0;     //级别分系数
                        decimal decJiBieScore = 0;      //级别分

                        ///三种情况的级别和级别分系数
                        string jibie1="",jibie2="",jibie3="";
                        decimal levelFactor1=0, levelFactor2=0, levelFactor3=0;


                        PeriModel = PeriBll.GetLunwenJiBieByQikanName(strUnit);
                        if (PeriModel != null)
                        {
                            //情况一：根据发表刊物得到级别和级别分系数
                            jibie1 = PeriModel.JiBie;
                            levelFactor1 = Convert.ToDecimal(PeriModel.LevelFactor);

                            //情况二：
                            //若为SCI收录或SSCI收录：先根据发表刊物得到影响因子，再得到级别和级别分系数
                            if (strState == "被SCI收录" || strState == "被SSCI收录")
                            {
                                decimal decQIF = Convert.ToDecimal(PeriModel.QIF);
                                if (Convert.ToBoolean(decQIF))
                                {
                                    LunwenModel = LunwenBll.GetJiBieByQIF(decQIF);
                                    if (LunwenModel != null)
                                    {
                                        jibie2 = LunwenModel.JiBie;
                                        levelFactor2 = Convert.ToDecimal(LunwenModel.LevelFactor);
                                    }
                                }
                            }
                        }

                        //情况三：根据收录/转载情况得到级别和级别分系数
                        LunwenModel = LunwenBll.GetJiBieBySitution(strState);
                        if (LunwenModel != null)
                        {
                            jibie3 = LunwenModel.JiBie;
                            levelFactor3 = Convert.ToDecimal(LunwenModel.LevelFactor);
                        }

                        //比较大小
                        if (Convert.ToBoolean(jibie1.CompareTo(jibie2)) && Convert.ToBoolean(jibie1.CompareTo(jibie3)))
                        {
                            strJiBie = jibie1;
                            decLevelFactor = levelFactor1;
                        }
                        else if (Convert.ToBoolean(jibie2.CompareTo(jibie1)) && Convert.ToBoolean(jibie2.CompareTo(jibie3)))
                        {
                            strJiBie = jibie2;
                            decLevelFactor = levelFactor2;
                        }
                        else
                        {
                            strJiBie = jibie3;
                            decLevelFactor = levelFactor3;
                        }

                        LZJModel.JiBie = strJiBie;
                        LZJModel.LevelFactor = decLevelFactor;
                        int intScore = LevelScoresBll.GetScoreByJiBie(strJiBie);    //根据级别得到对应的级别分数
                        decJiBieScore = intScore * decLevelFactor;  //级别分


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
                                    decPerScore = decJiBieScore * int1 / int2; 

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
                                    Response.Redirect("Thesis_List.aspx");
                                }
                            }
                        }
                        else
                        {
                            decPerScore = decJiBieScore;
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
                            Response.Redirect("Thesis_List.aspx");
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
