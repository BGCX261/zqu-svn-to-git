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
    public partial class WordsFunds : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_WordsFunds WFBll = new ZQUSR.BLL.sr_WordsFunds();
        private ZQUSR.Model.sr_WordsFunds WFModel = new ZQUSR.Model.sr_WordsFunds();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindZhuZuoData();
                BindKeJiData();
                BindSheKeData();
            }
        }

        #region 绑定学术著作数据
        private void BindZhuZuoData()
        {
            WFModel = WFBll.GetModel("学术著作");
            txtDigit2.Text = WFModel.Digit2.ToString();
            txtDigit1.Text = WFModel.Digit1.ToString();
            txtDigit3.Text = WFModel.Digit3.ToString();
            lblDigit2.Text = WFModel.Digit2.ToString();
        } 
        #endregion

        #region 绑定科技项目数据
        private void BindKeJiData()
        {
            WFModel = WFBll.GetModel("科研项目", "纵向科技项目");
            TextBox2.Text = WFModel.Digit1.ToString();
            TextBox1.Text = WFModel.Digit2.ToString();
            TextBox4.Text = WFModel.Digit2.ToString();
            Label1.Text = WFModel.Digit2.ToString();
            TextBox6.Text = WFModel.Digit3.ToString();
            TextBox5.Text = WFModel.Digit4.ToString();
            TextBox8.Text = WFModel.Digit4.ToString();
            Label2.Text = WFModel.Digit4.ToString();
            TextBox10.Text = WFModel.Digit5.ToString();
            TextBox9.Text = WFModel.Digit6.ToString();
            TextBox12.Text = WFModel.Digit6.ToString();
            Label3.Text = WFModel.Digit6.ToString();
            TextBox13.Text = WFModel.Digit7.ToString();

            WFModel = WFBll.GetModel("科研项目", "横向科技项目");
            TextBox3.Text = WFModel.Digit1.ToString();
            TextBox7.Text = WFModel.Digit3.ToString();
            TextBox11.Text = WFModel.Digit5.ToString();
            TextBox14.Text = WFModel.Digit7.ToString();
        } 
        #endregion

        #region 绑定社科项目数据
        private void BindSheKeData()
        {
            WFModel = WFBll.GetModel("科研项目", "纵向社科项目");
            TextBox16.Text = WFModel.Digit1.ToString();
            TextBox15.Text = WFModel.Digit2.ToString();
            TextBox18.Text = WFModel.Digit2.ToString();
            Label4.Text = WFModel.Digit2.ToString();
            TextBox20.Text = WFModel.Digit3.ToString();
            TextBox19.Text = WFModel.Digit4.ToString();
            TextBox22.Text = WFModel.Digit4.ToString();
            Label5.Text = WFModel.Digit4.ToString();
            TextBox24.Text = WFModel.Digit5.ToString();
            TextBox23.Text = WFModel.Digit6.ToString();
            TextBox26.Text = WFModel.Digit6.ToString();
            Label6.Text = WFModel.Digit6.ToString();
            TextBox27.Text = WFModel.Digit7.ToString();

            WFModel = WFBll.GetModel("科研项目", "横向社科项目");
            TextBox17.Text = WFModel.Digit1.ToString();
            TextBox21.Text = WFModel.Digit3.ToString();
            TextBox25.Text = WFModel.Digit5.ToString();
            TextBox28.Text = WFModel.Digit7.ToString();
        } 
        #endregion

        #region 学术著作：修改时自动绑定数据
        protected void txtDigit2_TextChanged(object sender, EventArgs e)
        {
            lblDigit2.Text = txtDigit2.Text;
        } 
        #endregion

        #region 科研项目(科技项目):修改时自动绑定数据
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Label1.Text = TextBox1.Text;
            TextBox4.Text = TextBox1.Text;
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            Label2.Text = TextBox5.Text;
            TextBox8.Text = TextBox5.Text;
        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {
            Label3.Text = TextBox9.Text;
            TextBox12.Text = TextBox9.Text;
        } 
        #endregion

        #region 科研项目(社科项目):修改时自动绑定数据
        protected void TextBox15_TextChanged(object sender, EventArgs e)
        {
            Label4.Text = TextBox15.Text;
            TextBox18.Text = TextBox15.Text;
        }

        protected void TextBox19_TextChanged(object sender, EventArgs e)
        {
            Label5.Text = TextBox19.Text;
            TextBox22.Text = TextBox19.Text;
        }

        protected void TextBox23_TextChanged(object sender, EventArgs e)
        {
            Label6.Text = TextBox23.Text;
            TextBox26.Text = TextBox23.Text;
        } 
        #endregion

        #region 学术著作字数分设置更新
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            decimal decDigit1 = Convert.ToDecimal(txtDigit1.Text);
            decimal decDigit2 = Convert.ToDecimal(txtDigit2.Text);
            decimal decDigit3 = Convert.ToDecimal(txtDigit3.Text);

            WFModel.Sort = "学术著作";
            WFModel.Digit1 = decDigit1;
            WFModel.Digit2 = decDigit2;
            WFModel.Digit3 = decDigit3;

            WFBll.UpdateZhuZuo(WFModel);
            BindZhuZuoData();
        } 
        #endregion

        #region 科研项目经费分设置更新
        //科技项目
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            WFModel.Sort = "科研项目";
            WFModel.Type = "纵向科技项目";
            WFModel.Digit1 = Convert.ToDecimal(TextBox2.Text);
            WFModel.Digit2 = Convert.ToDecimal(TextBox1.Text);
            WFModel.Digit3 = Convert.ToDecimal(TextBox6.Text);
            WFModel.Digit4 = Convert.ToDecimal(TextBox5.Text);
            WFModel.Digit5 = Convert.ToDecimal(TextBox10.Text);
            WFModel.Digit6 = Convert.ToDecimal(TextBox9.Text);
            WFModel.Digit7 = Convert.ToDecimal(TextBox13.Text);
            WFBll.UpdateKeYan(WFModel);

            WFModel.Sort = "科研项目";
            WFModel.Type = "横向科技项目";
            WFModel.Digit1 = Convert.ToDecimal(TextBox3.Text);
            WFModel.Digit2 = Convert.ToDecimal(TextBox1.Text);
            WFModel.Digit3 = Convert.ToDecimal(TextBox7.Text);
            WFModel.Digit4 = Convert.ToDecimal(TextBox5.Text);
            WFModel.Digit5 = Convert.ToDecimal(TextBox11.Text);
            WFModel.Digit6 = Convert.ToDecimal(TextBox9.Text);
            WFModel.Digit7 = Convert.ToDecimal(TextBox14.Text);
            WFBll.UpdateKeYan(WFModel);
        }
        //社科项目
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            WFModel.Sort = "科研项目";
            WFModel.Type = "纵向社科项目";
            WFModel.Digit1 = Convert.ToDecimal(TextBox16.Text);
            WFModel.Digit2 = Convert.ToDecimal(TextBox15.Text);
            WFModel.Digit3 = Convert.ToDecimal(TextBox20.Text);
            WFModel.Digit4 = Convert.ToDecimal(TextBox19.Text);
            WFModel.Digit5 = Convert.ToDecimal(TextBox24.Text);
            WFModel.Digit6 = Convert.ToDecimal(TextBox23.Text);
            WFModel.Digit7 = Convert.ToDecimal(TextBox27.Text);
            WFBll.UpdateKeYan(WFModel);

            WFModel.Sort = "科研项目";
            WFModel.Type = "横向社科项目";
            WFModel.Digit1 = Convert.ToDecimal(TextBox17.Text);
            WFModel.Digit2 = Convert.ToDecimal(TextBox15.Text);
            WFModel.Digit3 = Convert.ToDecimal(TextBox21.Text);
            WFModel.Digit4 = Convert.ToDecimal(TextBox19.Text);
            WFModel.Digit5 = Convert.ToDecimal(TextBox25.Text);
            WFModel.Digit6 = Convert.ToDecimal(TextBox23.Text);
            WFModel.Digit7 = Convert.ToDecimal(TextBox28.Text);
            WFBll.UpdateKeYan(WFModel);
        } 
        #endregion
    }
}
