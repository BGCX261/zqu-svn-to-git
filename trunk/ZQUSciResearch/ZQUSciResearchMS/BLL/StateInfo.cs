using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZQUSR.BLL
{
    public class StateInfo
    {
        #region 审核状态（教师）
        public static string GetAuditState(string strState)
        {
            string str = "";
            switch (strState)
            {
                case "0":
                    str = "未提交";
                    break;
                case "1":
                    str = "已提交";
                    break;
                case "2":
                    str = "一审不通过";
                    break;
                case "3":
                    str = "一审通过";
                    break;
                case "4":
                    str = "二审不通过";
                    break;
                case "5":
                    str = "二审通过";
                    break;
                case "6":
                    str = "终审不通过";
                    break;
                case "7":
                    str = "终审通过";
                    break;
                default:
                    break;
            }
            return str;
        } 
        #endregion

        #region 审核状态（秘书）
        public static string GetAuditStateByMishu(string strState)
        {
            string str = "";
            switch (strState)
            {
                case "1":
                    str = "未审核";
                    break;
                case "2":
                    str = "审核不通过";
                    break;
                case "3":
                    str = "审核通过";
                    break;
                case "4":
                    str = "二审不通过";
                    break;
                case "5":
                    str = "二审通过";
                    break;
                case "6":
                    str = "终审不通过";
                    break;
                case "7":
                    str = "终审通过";
                    break;
                default:
                    break;
            }
            return str;
        }
        #endregion

        #region 审核状态（科员/处长）
        public static string GetAuditStateByKeyuan(string strState)
        {
            string str = "";
            switch (strState)
            {
                case "3":
                    str = "未审核";
                    break;
                case "4":
                    str = "审核不通过";
                    break;
                case "5":
                    str = "审核通过";
                    break;
                case "6":
                    str = "终审不通过";
                    break;
                case "7":
                    str = "终审通过";
                    break;
                default:
                    break;
            }
            return str;
        }
        #endregion

        #region 完成成果排名
        public static string GetRank(string rank)
        {
            string strRank = "";
            switch (rank)
            {
                case "0":
                    strRank = "独立";
                    break;
                case "1":
                    strRank = "第一作者";
                    break;
                case "2":
                    strRank = "第二作者";
                    break;
                case "3":
                    strRank = "第三作者";
                    break;
                case "4":
                    strRank = "第四作者";
                    break;
                case "5":
                    strRank = "第五作者";
                    break;
                case "6":
                    strRank = "第六作者";
                    break;
                case "7":
                    strRank = "第七作者";
                    break;
                case "8":
                    strRank = "第八作者";
                    break;
                case "9":
                    strRank = "第九作者";
                    break;
                case "10":
                    strRank = "第十作者";
                    break;
                default:
                    break;
            }
            return strRank;
        } 
        #endregion
    }
}
