using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_Calculate1 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_Calculate1
	{
		public sr_Calculate1()
		{}
		#region Model
		private int _pk_cid;
		private string _sort;
		private string _jibie;
		private string _schoolsign;
		private decimal _scale;
		/// <summary>
		/// 
		/// </summary>
		public int PK_CID
		{
			set{ _pk_cid=value;}
			get{return _pk_cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JiBie
		{
			set{ _jibie=value;}
			get{return _jibie;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SchoolSign
		{
			set{ _schoolsign=value;}
			get{return _schoolsign;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Scale
		{
			set{ _scale=value;}
			get{return _scale;}
		}
		#endregion Model

	}
}

