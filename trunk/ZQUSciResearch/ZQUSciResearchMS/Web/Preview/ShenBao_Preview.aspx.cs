using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ZQUSR.BLL;

namespace Web.Preview
{
    public partial class ShenBao_Preview : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Project ProjectBll = new ZQUSR.BLL.sr_Project();
        private ZQUSR.Model.sr_Project ProjectModel = new ZQUSR.Model.sr_Project();
        private ZQUSR.Model.sr_User UserModel = new ZQUSR.Model.sr_User();
        private ZQUSR.BLL.sr_User UserBll = new ZQUSR.BLL.sr_User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Role"] != null)
                {
                    string srid = Request.QueryString["srid"].ToString();  //获得成果编号

                    if (srid != "")
                    {
                        BindData(srid);

                        ProjectModel = ProjectBll.GetModel(srid);
                        string state = (ProjectModel.AuditState).ToString();

                        string cmd = Request.QueryString["cmd"].ToString();
                        if ((cmd == "preview") && (state == "0" || state == "2" || state == "4" || state == "6"))
                        {
                            Panel1.Visible = true;  //显示提交、修改按钮（公用）
                        }

                        string role = Session["Role"].ToString();   //角色
                        switch (role)   //根据角色不同显示不同的操作按钮
                        {
                            //case "教师":
                            //    if (state == "0" || state == "2" || state == "4" || state == "6")
                            //    {
                            //        Panel1.Visible = true;
                            //    }
                            //    break;
                            case "管理员":
                                if (state == "1")
                                {
                                    Panel2.Visible = true;
                                }
                                break;
                            case "系统管理员":
                                if (state == "3")
                                {
                                    Panel3.Visible = true;
                                    lbtnUpdateJiBie.Visible = true;
                                }
                                break;
                            case "超级管理员":
                                if (state == "3")
                                {
                                    Panel3.Visible = true;
                                    lbtnUpdateJiBie.Visible = true;
                                }
                                if (state == "5" || state == "6" || state == "7")
                                {
                                    CheckBox1.Visible = true;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('您已经与服务器断开连接，请重新登录！');window.location.href='~/../../login.aspx';</script>");
                    //Response.Redirect("~/login.aspx");
                }
            }
        }

        private void BindData(string srid)
        {
            //得到对象实体
            ProjectModel = ProjectBll.GetModel(srid);
            UserModel = UserBll.GetModel(ProjectModel.FK_UserID);

            //绑定数据到Label
            lblUserName.Text = UserModel.UserName;
            lblUserUnit.Text = UserModel.Unit;
            lblSex.Text = UserModel.Sex;
            lblZhiCheng.Text = UserModel.ZhiCheng;

            lblBigSort.Text = ProjectModel.BigSort;
            lblSchoolSign.Text = ProjectModel.SchoolSign;
            lblPopulation.Text = (ProjectModel.Population).ToString();
            lblAllAuthor.Text = ProjectModel.AllAuthor;
            lblRemark.Text = ProjectModel.Remark;
            lblJiBie.Text = (ProjectModel.LevelFactor).ToString() + ProjectModel.JiBie;
            lblPerScore.Text = (ProjectModel.PerScore).ToString();
            string state = (ProjectModel.AuditState).ToString();
            lblAuditState.Text = StateInfo.GetAuditState(state);
            lblReason.Text = ProjectModel.Extra1;

            if (state == "2" || state == "4" || state == "6")
            {
                PanelReasonVisible.Visible = true;
            }

            lblSRID.Text = ProjectModel.PK_PID;
            lblTitle.Text = ProjectModel.Title;
            lblTime.Text = string.Format("{0:yyyy-MM-dd}", ProjectModel.PublishTime1);
            lblType.Text = ProjectModel.Type;
            lblSource.Text = ProjectModel.Source;
            lblReviewState.Text = ProjectModel.ReviewState;
            lblAnchorperson.Text = ProjectModel.Anchorperson.ToString();


            //if (state == "1" || state == "3" || state == "5" || state == "7")
            //{
            //    Button1.Enabled = false;
            //    Button2.Enabled = false;
            //}
            //if (state == "3" || state == "5" || state == "7")
            //{
            //    Button3.Enabled = false;
            //    Button4.Enabled = false;
            //}
            //if (state == "5" || state == "7")
            //{
            //    Button5.Enabled = false;
            //    Button6.Enabled = false;
            //}
            //if (state == "7")
            //{
            //    Button7.Enabled = false;
            //    Button8.Enabled = false;
            //}
        }

        private void UpdateAuditState(string state)
        {
            string srid = lblSRID.Text;
            ProjectBll.UpdateAuditState(srid, state);
        }

        private void UpdateAuditState(string state, string reason)
        {
            string srid = lblSRID.Text;
            ProjectBll.UpdateAuditState(srid, state, reason);
        }

        #region 教师相关操作
        protected void Button1_Click(object sender, EventArgs e)    //提交
        {
            //UpdateAuditState("1");
            //Response.Redirect("../SciResearch/ShenBao_List.aspx");
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "教师")
                {
                    UpdateAuditState("1");
                }
                else
                {
                    UpdateAuditState("3");
                }
                Response.Redirect("../SciResearch/ShenBao_List.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>alert('您已经与服务器断开连接，请重新登录！');window.location.href='~/../../login.aspx';</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)    //  修改
        {
            Response.Redirect("../SciResearch/ShenBao_Add.aspx?cmd=modify&srid=" + lblSRID.Text + "");
        }
        #endregion

        #region 秘书相关操作
        protected void Button3_Click(object sender, EventArgs e)    //一审不通过
        {
            Panel2.Visible = false;
            PanelReason.Visible = true;
            Panel5.Visible = true;
            //UpdateAuditState("2");
            //Response.Redirect("../MishuAudit/Achievement_Yishen.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)    //一审通过
        {
            UpdateAuditState("3");
            Response.Redirect("../Audit/FirstAudit.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)   //审核不通过更新审核状态并填写原因
        {
            string strReason = txtReason.Text;
            UpdateAuditState("2", strReason);
            Response.Redirect("../Audit/FirstAudit.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e)   //取消
        {
            PanelReason.Visible = false;
            Panel5.Visible = false;
            Panel2.Visible = true;
        }
        #endregion

        #region 科员相关操作
        protected void Button5_Click(object sender, EventArgs e)    //二审不通过
        {
            Panel3.Visible = false;
            PanelReason.Visible = true;
            Panel6.Visible = true;
            //UpdateAuditState("4");
            //Response.Redirect("../KeyuanAudit/Achievement_Ershen.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)    //二审通过
        {
            UpdateAuditState("5");
            Response.Redirect("../Audit/SecondAudit.aspx");
        }

        protected void Button11_Click(object sender, EventArgs e)   //审核不通过更新审核状态并填写原因
        {
            string strReason = txtReason.Text;
            UpdateAuditState("4", strReason);
            Response.Redirect("../Audit/SecondAudit.aspx");
        }

        protected void Button12_Click(object sender, EventArgs e)   //取消
        {
            PanelReason.Visible = false;
            Panel6.Visible = false;
            Panel3.Visible = true;
        }
        #endregion

        #region 处长相关操作
        protected void Button7_Click(object sender, EventArgs e)    //终审不通过
        {
            Panel4.Visible = false;
            PanelReason.Visible = true;
            Panel7.Visible = true;
            //UpdateAuditState("6");
            //Response.Redirect("../KeyuanAudit/Achievement_Ershen.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)    //终审通过
        {
            UpdateAuditState("7");
            Response.Redirect("../Audit/SecondAudit.aspx");
        }

        protected void Button13_Click(object sender, EventArgs e)   //审核不通过更新审核状态并填写原因
        {
            string strReason = txtReason.Text;
            UpdateAuditState("6", strReason);
            Response.Redirect("../Audit/SecondAudit.aspx");
        }

        protected void Button14_Click(object sender, EventArgs e)   //取消
        {
            PanelReason.Visible = false;
            Panel7.Visible = false;
            Panel4.Visible = true;
        }
        #endregion

        #region 修改级别（弹出新窗口修改）
        protected void lbtnUpdateJiBie_Click(object sender, EventArgs e)
        {
            Response.Write("<script>javascript:window.open('UpdateJiBie.aspx?srid=" + lblSRID.Text + "','科研成果/业绩级别修改','height=200,width=500');</script>");
        }
        #endregion

        #region 启用终审功能
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox1.Checked = false;
            lbtnUpdateJiBie.Visible = true;
            Panel4.Visible = true;
            CheckBox1.Visible = false;
        }
        #endregion

        #region 取消终审
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            CheckBox1.Visible = true;
            lbtnUpdateJiBie.Visible = false;
            Panel4.Visible = false;
        }
        #endregion
    }
}
