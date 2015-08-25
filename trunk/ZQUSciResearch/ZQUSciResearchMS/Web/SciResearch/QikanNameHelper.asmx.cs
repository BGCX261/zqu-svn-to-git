using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace Web.SciResearch
{
    /// <summary>
    /// QikanNameHelper 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class QikanNameHelper : System.Web.Services.WebService
    {
        private ZQUSR.BLL.sr_Periodicals PeriBll = new ZQUSR.BLL.sr_Periodicals();

        private static string[] autoCompleteWordList = null;

        [WebMethod]
        public string[] GetQikanNameByKey(string prefixText)
        {
            DataSet ds = new DataSet();     
            ds = PeriBll.GetQikanNameByKey(prefixText);

            if (autoCompleteWordList == null)
            {
                //读取内容文件的数据到临时数组
                string[] temp = new string[ds.Tables[0].Rows.Count];
                int i = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    temp[i] = dr["QikanName"].ToString().Trim();
                    i++;
                }
                //将临时数组的内容赋给返回数组
                autoCompleteWordList = temp;
            }

            String[] returnValue = new string[ds.Tables[0].Rows.Count];
            returnValue = autoCompleteWordList;
            autoCompleteWordList = null;
            //返回数据
            return returnValue;
        }
    }
}
