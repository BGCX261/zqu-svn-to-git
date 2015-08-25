using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Preview
{
    public partial class UpdateJiBie : System.Web.UI.Page
    {
        private ZQUSR.BLL.sr_LwZzJc LZJBll = new ZQUSR.BLL.sr_LwZzJc();
        private ZQUSR.Model.sr_LwZzJc LZJModel = new ZQUSR.Model.sr_LwZzJc();
        private ZQUSR.BLL.sr_Achievement AchievementBll = new ZQUSR.BLL.sr_Achievement();
        private ZQUSR.Model.sr_Achievement AchievementModel = new ZQUSR.Model.sr_Achievement();
        private ZQUSR.BLL.sr_Project ProBll = new ZQUSR.BLL.sr_Project();
        private ZQUSR.Model.sr_Project ProModel = new ZQUSR.Model.sr_Project();
        private ZQUSR.BLL.sr_LevelScores LevelScoresBll = new ZQUSR.BLL.sr_LevelScores();
        private ZQUSR.Model.sr_Calculate2 Cal2Model = new ZQUSR.Model.sr_Calculate2();
        private ZQUSR.BLL.sr_Calculate2 Cal2Bll = new ZQUSR.BLL.sr_Calculate2();
        private ZQUSR.BLL.sr_Calculate3 Cal3Bll = new ZQUSR.BLL.sr_Calculate3();
        private ZQUSR.BLL.sr_WordsFunds WordsFundsBll = new ZQUSR.BLL.sr_WordsFunds();
        private ZQUSR.Model.sr_WordsFunds WordsFundsModel = new ZQUSR.Model.sr_WordsFunds();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string srid = Request.QueryString["srid"].ToString();
                lblSRID.Text = srid;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            decimal decLevelFactor = Convert.ToDecimal(txtLevelFactor.Text);     //级别分系数
            string strJiBie = ddlJiBie.SelectedValue;   //级别

            int intScore = LevelScoresBll.GetScoreByJiBie(strJiBie);    //根据级别得到对应的级别分数
            decimal decJiBieScore = intScore * decLevelFactor;   //级别分

            string strID = lblSRID.Text.Trim();
            string strResult = strID.Substring(0, 2);

            if (strResult == "LW")  //学术论文
            {
                decimal decPerScore = 0;
                LZJModel = LZJBll.GetModel(strID);
                int intRank = Convert.ToInt32(LZJModel.Rank);
                int intPopulation = Convert.ToInt32(LZJModel.Population);

                //根据完成人数和完成成果排名返回对应的得分比例
                Cal2Model = Cal2Bll.GetScoreScale(intPopulation, intRank);
                if (Cal2Model != null)
                {
                    string strScale = Cal2Model.ScoreScale;
                    string[] str = strScale.Split('/');
                    int int1 = int.Parse(str[0]);
                    int int2 = int.Parse(str[1]);
                    decPerScore = decJiBieScore * int1 / int2;
                }

                //更新级别分系数、级别、个人得分
                LZJModel.PK_LZID = strID;
                LZJModel.LevelFactor = decLevelFactor;
                LZJModel.JiBie = strJiBie;
                LZJModel.PerScore = decPerScore;

            }
            else if (strResult == "ZZ") //学术著作
            {
                decimal decPerScore = 0;
                LZJModel = LZJBll.GetModel(strID);
                int intRank = Convert.ToInt32(LZJModel.Rank);
                int intPopulation = Convert.ToInt32(LZJModel.Population);

                //计算字数分
                decimal decWord = Convert.ToDecimal(LZJModel.Word);
                WordsFundsModel = WordsFundsBll.GetModel("学术著作");
                decimal decWordScore = 0;   //字数分
                if (decWord <= WordsFundsModel.Digit2)
                {
                    decWordScore = decWord * Convert.ToDecimal(WordsFundsModel.Digit1);
                }
                else if (decWord > WordsFundsModel.Digit2)
                {
                    decWordScore = Convert.ToDecimal(WordsFundsModel.Digit2) * Convert.ToDecimal(WordsFundsModel.Digit1) + Convert.ToDecimal(decWord - WordsFundsModel.Digit2) * Convert.ToDecimal(WordsFundsModel.Digit3);
                }

                //根据完成人数和完成成果排名返回对应的得分比例
                Cal2Model = Cal2Bll.GetScoreScale(intPopulation, intRank);
                if (Cal2Model != null)
                {
                    string strScale = Cal2Model.ScoreScale;
                    string[] str = strScale.Split('/');
                    int int1 = int.Parse(str[0]);
                    int int2 = int.Parse(str[1]);
                    decPerScore = (decJiBieScore+decWordScore) * int1 / int2;
                }

                //更新级别分系数、级别、个人得分
                LZJModel.PK_LZID = strID;
                LZJModel.LevelFactor = decLevelFactor;
                LZJModel.JiBie = strJiBie;
                LZJModel.PerScore = decPerScore;
            }
            else if (strResult == "KY") //科研项目
            {
                decimal decPerScore = 0;
                ProModel = ProBll.GetModel(strID);
                int intRank = Convert.ToInt32(ProModel.Anchorperson);
                int intPopulation = Convert.ToInt32(ProModel.Population);

                //计算经费分
                decimal decFundScore = 0;
                string strSmallSort = ProModel.SmallSort;
                string strType = ProModel.Type;
                decimal decFunds1 = Convert.ToDecimal(ProModel.Funds1);
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
                decimal decScale = Cal3Bll.GetProjectScale("是");
                int intAnchorperson = Convert.ToInt32(ProModel.Anchorperson);
                if (intAnchorperson == 0)   //是否项目主持人
                {
                    decPerScore = (decJiBieScore + decFundScore) * decScale;
                }
                else
                {
                    decPerScore = (decJiBieScore + decFundScore) * (1 - decScale) / (intPopulation - 1);
                }

                //更新级别分系数、级别、个人得分
                ProModel.PK_PID = strID;
                ProModel.LevelFactor = decLevelFactor;
                ProModel.JiBie = strJiBie;
                ProModel.PerScore = decPerScore;
            }
            else if (strResult == "SB") //项目申报
            {
                decimal decPerScore = 0;
                ProModel = ProBll.GetModel(strID);
                int intRank = Convert.ToInt32(ProModel.Anchorperson);
                int intPopulation = Convert.ToInt32(ProModel.Population);

                //计算个人得分
                decimal decScale = Cal3Bll.GetProjectScale("是");
                int intAnchorperson = Convert.ToInt32(ProModel.Anchorperson);
                if (intAnchorperson == 0)   //是否项目主持人
                {
                    decPerScore = decJiBieScore * decScale;
                }
                else
                {
                    decPerScore = decJiBieScore * (1 - decScale) / (intPopulation - 1);
                }

                //更新级别分系数、级别、个人得分
                ProModel.PK_PID = strID;
                ProModel.LevelFactor = decLevelFactor;
                ProModel.JiBie = strJiBie;
                ProModel.PerScore = decPerScore;
            }
            else  //其他类别
            {
                decimal decPerScore = 0;
                AchievementModel = AchievementBll.GetModel(strID);
                int intRank = Convert.ToInt32(AchievementModel.Rank);
                int intPopulation = Convert.ToInt32(AchievementModel.Population);

                //根据完成人数和完成成果排名返回对应的得分比例
                Cal2Model = Cal2Bll.GetScoreScale(intPopulation, intRank);
                if (Cal2Model != null)
                {
                    string strScale = Cal2Model.ScoreScale;
                    string[] str = strScale.Split('/');
                    int int1 = int.Parse(str[0]);
                    int int2 = int.Parse(str[1]);
                    decPerScore = decJiBieScore * int1 / int2;
                }

                //更新级别分系数、级别、个人得分
                AchievementModel.PK_AID = strID;
                AchievementModel.LevelFactor = decLevelFactor;
                AchievementModel.JiBie = strJiBie;
                AchievementModel.PerScore = decPerScore;

                AchievementBll.UpdateJiBie(AchievementModel);
            }

            Response.Write("<script language=javascript>opener.location.reload();window.close();</script>");
        }
    }
}
