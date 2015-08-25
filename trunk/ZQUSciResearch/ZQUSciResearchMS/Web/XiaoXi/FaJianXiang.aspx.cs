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
    public partial class FaJianXiang : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_Message MsgBll = new ZQUSR.BLL.sr_Message();
        private ZQUSR.Model.sr_Message MsgModel = new ZQUSR.Model.sr_Message();
        private ZQUSR.BLL.sr_User ReceiverBll = new ZQUSR.BLL.sr_User();
        private ZQUSR.Model.sr_User ReceiverModel = new ZQUSR.Model.sr_User();

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {
                ///判断用户是否登录，否则跳转到登录页面
                if (Session["UserID"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                //BindMsgData(Int32.Parse(Session["UserID"].ToString()));
                BindMsgData(Session["UserID"].ToString());
            }
        }

        #region 绑定消息列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        public void BindMsgData(string userID)
        {
            string strWhere = "FK_SenderID='" + userID + "' order by SendTime DESC";
            DataSet ds = new DataSet();
            ds = MsgBll.GetList(strWhere);
            if (ds.Tables[0].Rows.Count==0)
            {
                lblTishi.Visible = true;
                this.GVMsgListBySender.DataSource = ds.Tables[0];
                this.DataBind();
            }
            else
            {
                this.GVMsgListBySender.DataSource = ds.Tables[0];
                this.DataBind();
            }
        }
        #endregion

        #region 取消已选选择
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            CheckBox2.Checked = false;
            for (int i = 0; i <= GVMsgListBySender.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GVMsgListBySender.Rows[i].FindControl("CheckBox1");
                cbox.Checked = false;
            }
        }
        #endregion

        #region 删除选择的短信
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string userID = Session["UserID"].ToString();
            //获得DATASET
            string strWhere = "FK_RecieverID='" + Session["UserID"].ToString() + "' order by SendTime";
            DataSet Delds= MsgBll.GetList(strWhere);
            for (int i = 0; i <= GVMsgListBySender.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GVMsgListBySender.Rows[i].FindControl("CheckBox1");
                if (cbox.Checked == true)
                {
                    //获得主键
                    int DelID = Convert.ToInt32(Delds.Tables[0].Rows[i].ItemArray[0].ToString());
                    MsgBll.Delete(DelID);                    
                }
            }
            BindMsgData(Session["UserID"].ToString());
        }
        #endregion

        #region 全选的取消与选择功能实现
        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= GVMsgListBySender.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GVMsgListBySender.Rows[i].FindControl("CheckBox1");
                if (CheckBox2.Checked == true)
                {
                    cbox.Checked = true;
                }
                else
                {
                    cbox.Checked = false;
                }
            }
        }
        #endregion

        //private void MsgList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        //{
        //    MsgList.CurrentPageIndex = e.NewPageIndex;

        //    ///重新绑定短信列表的数据
        //    BindMsgData(Int32.Parse(Session["UserID"].ToString()));
        //}

        //protected void Read_Click(object sender, System.EventArgs e)
        //{
        //    Message msg = new Message();
        //    foreach (DataGridItem item in MsgList.Items)
        //    {
        //        CheckBox cBox = (CheckBox)item.FindControl("MsgID");
        //        if (cBox != null)
        //        {
        //            if (cBox.Checked == true)
        //            {
        //                msg.UpdateMsgRead(Int32.Parse(MsgList.DataKeys[item.ItemIndex].ToString()));
        //            }
        //        }
        //    }

        //    ///重新绑定短信列表的数据
        //    BindMsgData(Int32.Parse(Session["UserID"].ToString()));
        //}
    }
}
