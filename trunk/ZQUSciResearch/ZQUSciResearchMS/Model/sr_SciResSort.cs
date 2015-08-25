using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_SciResSort 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_SciResSort
	{
		public sr_SciResSort()
		{}
		#region Model
		private int _pk_sid;
		private string _bigsort;
		private string _smallsort;
		/// <summary>
		/// 
		/// </summary>
		public int PK_SID
		{
			set{ _pk_sid=value;}
			get{return _pk_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BigSort
		{
			set{ _bigsort=value;}
			get{return _bigsort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SmallSort
		{
			set{ _smallsort=value;}
			get{return _smallsort;}
		}
		#endregion Model

	}
}

