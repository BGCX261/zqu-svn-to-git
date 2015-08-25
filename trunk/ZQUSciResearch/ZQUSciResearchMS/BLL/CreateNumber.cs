using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZQUSR.BLL
{
    public static class CreateNumber
    {
        #region 生成14位长的编号，如：20101116093024(年月日时分秒)
        /// <summary>
        /// 学术论文等类别编号的生成
        /// </summary>
        /// <returns></returns>
        public static string GetNumber()
        {
            int intYear = DateTime.Now.Year; //获取当前年
            int intMonth = DateTime.Now.Month;  //获取当前月
            int intDate = DateTime.Now.Day;    //获取当前天
            int intHour = DateTime.Now.Hour;    //获取当前小时
            int intMinute = DateTime.Now.Minute;    //获取当前分
            int intSecond = DateTime.Now.Second;    //获取当前秒
            string strTime = null;
            strTime = intYear.ToString();

            if (intMonth < 10)  //当月份小于10
            {
                strTime += "0" + intMonth.ToString();
            }
            else
            {
                strTime += intMonth.ToString();
            }

            if (intDate < 10)   //当天数小于10
            {
                strTime += "0" + intDate.ToString();
            }
            else
            {
                strTime += intDate.ToString();
            }

            if (intHour < 10)   //当小时小于10
            {
                strTime += "0" + intHour.ToString();
            }
            else
            {
                strTime += intHour.ToString();
            }

            if (intMinute < 10) //当分钟小于10
            {
                strTime += "0" + intMinute.ToString();
            }
            else
            {
                strTime += intMinute.ToString();
            }

            if (intSecond < 10) //当秒小于10
            {
                strTime += "0" + intSecond.ToString();
            }
            else
            {
                strTime += intSecond.ToString();
            }

            return strTime;
        }
        #endregion
    }
}
