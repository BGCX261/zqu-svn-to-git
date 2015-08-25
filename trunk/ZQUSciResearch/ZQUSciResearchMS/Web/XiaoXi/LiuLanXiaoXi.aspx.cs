/*dancy编写*/
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
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
    public partial class LiuLanXiaoXi : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Message MsgBll = new ZQUSR.BLL.sr_Message();
        private ZQUSR.Model.sr_Message MsgModel = new ZQUSR.Model.sr_Message();
        private ZQUSR.BLL.sr_User UserBll = new ZQUSR.BLL.sr_User();
        private ZQUSR.Model.sr_User UserModel = new ZQUSR.Model.sr_User();

        protected void Page_Load(object sender, EventArgs e)
        {
            string userID = Session["UserID"].ToString();
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region 绑定消息
        public void BindData()
        {
            //获取消息Id
            int id=Convert.ToInt32(Request.QueryString.GetValues(0)[0]);
            MsgModel = MsgBll.GetModel(id);
            lblMsgTitle.Text = MsgModel.Title;
            //从ID获取用户姓名
            string receiverID = MsgModel.FK_RecieverID;
            lblReceiver.Text = UserBll.GetUserName(receiverID);
            lblSender.Text = UserBll.GetUserName(MsgModel.FK_SenderID);
            lblSendTime.Text = MsgModel.SendTime.ToString();
            lblMsgContend.Text = MsgModel.MessContent;
            //若消息状态为未读，则修改为已读。
            if (MsgModel.IsRead==0)
            {
                MsgModel.IsRead = 1;
                MsgBll.Update(MsgModel);
            }

        }
        #endregion

        //返回到收件箱
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShouJianXiang.aspx");
        }
    }
}