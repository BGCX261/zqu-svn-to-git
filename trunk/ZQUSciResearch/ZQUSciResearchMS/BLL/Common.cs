using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ZQUSR.BLL
{
    public class Common
    {
        /// <summary>
        /// 替换数据库中数字状态，比如:0:未提交/1:已提交/2:初审中...  by caiyuying 2011-01-23
        /// </summary>
        /// <param name="ds"></param>
        public void replaceState(DataSet ds)
        {
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string state = ds.Tables[0].Rows[i]["AuditState"].ToString();
                    switch (state)
                    {
                        case "0":
                            ds.Tables[0].Rows[i]["AuditState"] = "未提交";
                            break;
                        case "1":
                            ds.Tables[0].Rows[i]["AuditState"] = "已提交";
                            break;
                        case "2":
                            ds.Tables[0].Rows[i]["AuditState"] = "初审中";
                            break;
                        case "3":
                            ds.Tables[0].Rows[i]["AuditState"] = "初审通过";
                            break;
                        case "4":
                            ds.Tables[0].Rows[i]["AuditState"] = "初审不通过";
                            break;
                        case "5":
                            ds.Tables[0].Rows[i]["AuditState"] = "二审中";
                            break;
                        case "6":
                            ds.Tables[0].Rows[i]["AuditState"] = "二审通过";
                            break;
                        case "7":
                            ds.Tables[0].Rows[i]["AuditState"] = "二审不通过";
                            break;
                        default:
                            ds.Tables[0].Rows[i]["AuditState"] = "未知";
                            break;
                    }
                }
            }
        }

    }
}
