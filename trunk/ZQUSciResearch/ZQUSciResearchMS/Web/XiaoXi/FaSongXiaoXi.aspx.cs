/*dancy编写*/
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
using ZQUSR.Model;

namespace Web.XiaoXi
{
    public partial class FaSongXiaoXi : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Message MsgBll = new ZQUSR.BLL.sr_Message();
        private ZQUSR.Model.sr_Message MsgModel = new ZQUSR.Model.sr_Message();
        private ZQUSR.BLL.sr_User ReceiverBll = new ZQUSR.BLL.sr_User();
        private ZQUSR.Model.sr_User ReceiverModel = new ZQUSR.Model.sr_User();

        protected void Page_Load(object sender, EventArgs e)
        {
            string userID = Session["UserID"].ToString();
            lblErrorReceiver.Text = "";
            if (!IsPostBack)
            {
                BindDdlReXueYuan();
                ddlReName.Items.Insert(0, new ListItem("请选择...", "-1"));
            }
        }

        #region 绑定学院下拉列表
        private void BindDdlReXueYuan()
        {
            ddlReXueYuan.Items.Clear();
            ddlReXueYuan.DataSource = ReceiverBll.GetXueYuan();
            ddlReXueYuan.DataTextField = "Unit";
            ddlReXueYuan.DataBind();
            ddlReXueYuan.Items.Insert(0, new ListItem("请选择...", "-1"));
        }
        #endregion

        #region 根据学院显示对应的教师名单
        protected void ddlReXueYuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlReName.Items.Clear();
            string strXueYuan = ddlReXueYuan.SelectedItem.Text;
            ddlReName.DataSource = ReceiverBll.GetNameByXueyuan(strXueYuan);
            ddlReName.DataTextField = "UserName";
            ddlReName.DataBind();
            ddlReName.Items.Insert(0, new ListItem("请选择...", "-1"));
        }
        #endregion

        #region 发送消息
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMsgTitle.Text=="")
                {
                    txtMsgTitle.Focus();
                    lblErrorMsgTitle.Text = "信息标题不能为空！";
                }

                else if (txtReceiver.Text == "")
                {
                    lblErrorMsgTitle.Text = "";
                    txtReceiver.Focus();
                    lblErrorReceiver.Text = "接收人不能为空！";
                }
                else if (txtMsgContent.Text == "")
                {
                    lblErrorMsgTitle.Text = "";
                    lblErrorReceiver.Text = "";
                    txtMsgContent.Focus();
                    lblErrorMsgContent.Text = "发送内容不能为空！";
                }
                else 
                {
                    lblErrorMsgTitle.Text = "";
                    lblErrorReceiver.Text = "";
                    lblErrorMsgContent.Text = "";
                    //判断数据库中是否包含接收人
                    string strID = ReceiverBll.isExistUser(txtReceiver.Text, ddlReXueYuan.SelectedItem.Text);
                    if (strID == null)
                    {
                        txtReceiver.Text = "";
                        txtReceiver.Focus();
                        lblErrorReceiver.Text = "接收人不存在，请重新输入！";
                    }
                    else
                    {
                        string userID = Session["UserID"].ToString();
                        string strMsgTitle = txtMsgTitle.Text;    //信息标题
                        string strReceiverID = strID;     //接收人编号
                        string strMsgContent = txtMsgContent.Text;  //发送内容

                        MsgModel.Title = strMsgTitle;  //信息标题
                        MsgModel.MessContent = strMsgContent;   //发送内容
                        MsgModel.FK_RecieverID = strReceiverID; //接收人
                        MsgModel.FK_SenderID = userID;       //发送人
                        MsgModel.SendTime = DateTime.Now;    //获得当前时间
                        MsgModel.IsRead = 0;                     //未读


                        //写入数据库
                        MsgBll.Add(MsgModel);                    //新增一条消息记录
                        Response.Redirect("ShouJianXiang.aspx");
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


        protected void btnReturn_Click(object sender, EventArgs e)
        {

        }

        protected void ddlReName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReName.SelectedItem.Value!="-1")
            {
                txtReceiver.Text = ddlReName.SelectedItem.Text;
            }
            
        }

        

        
    }
}
