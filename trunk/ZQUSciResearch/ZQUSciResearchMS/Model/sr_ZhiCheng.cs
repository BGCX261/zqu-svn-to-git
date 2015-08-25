using System;
namespace ZQUSR.Model
{
    /// <summary>
    /// sr_ZhiCheng:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class sr_ZhiCheng
    {
        public sr_ZhiCheng()
        { }
        #region Model
        private int _pk_zcid;
        private string _grade;
        private string _zhichengname;
        /// <summary>
        /// 
        /// </summary>
        public int PK_ZCID
        {
            set { _pk_zcid = value; }
            get { return _pk_zcid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZhiChengName
        {
            set { _zhichengname = value; }
            get { return _zhichengname; }
        }
        #endregion Model

    }
}


