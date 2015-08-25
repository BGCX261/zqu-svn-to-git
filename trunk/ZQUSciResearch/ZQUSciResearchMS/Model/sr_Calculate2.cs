using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_Calculate2 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_Calculate2
	{
		public sr_Calculate2()
		{}
		#region Model
		private int _pk_cid;
		private int _population;
		private int _rank;
		private string _scorescale;
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
		public int Population
		{
			set{ _population=value;}
			get{return _population;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Rank
		{
			set{ _rank=value;}
			get{return _rank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ScoreScale
		{
			set{ _scorescale=value;}
			get{return _scorescale;}
		}
		#endregion Model

	}
}

