using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_Calculate3 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_Calculate3
	{
		public sr_Calculate3()
		{}
		#region Model
		private int _pk_cid;
		private string _type;
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
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
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

