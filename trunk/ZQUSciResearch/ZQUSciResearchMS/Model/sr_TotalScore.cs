using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_TotalScore 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_TotalScore
	{
		public sr_TotalScore()
		{}
		#region Model
		private int _pk_tid;
		private string _fk_userid;
		private string _year;
		private decimal _totalscore;
		private decimal? _totalrewards;
		private string _extra1;
		private string _extra2;
		/// <summary>
		/// 
		/// </summary>
		public int PK_TID
		{
			set{ _pk_tid=value;}
			get{return _pk_tid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FK_UserID
		{
			set{ _fk_userid=value;}
			get{return _fk_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Year
		{
			set{ _year=value;}
			get{return _year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TotalScore
		{
			set{ _totalscore=value;}
			get{return _totalscore;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalRewards
		{
			set{ _totalrewards=value;}
			get{return _totalrewards;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Extra1
		{
			set{ _extra1=value;}
			get{return _extra1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Extra2
		{
			set{ _extra2=value;}
			get{return _extra2;}
		}
		#endregion Model

	}
}

