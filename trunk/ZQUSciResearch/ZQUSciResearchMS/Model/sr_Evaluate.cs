using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_Evaluate 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_Evaluate
	{
		public sr_Evaluate()
		{}
		#region Model
		private int _pk_eid;
		private string _sort;
		private string _type;
		private string _source;
		private string _grade;
		private string _awardgrade;
		private decimal _funds1;
		private decimal _funds2;
		private string _jibie;
        private decimal? _levelfactor;
		private string _extra1;
		private string _extra2;
		/// <summary>
		/// 
		/// </summary>
		public int PK_EID
		{
			set{ _pk_eid=value;}
			get{return _pk_eid;}
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
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Source
		{
			set{ _source=value;}
			get{return _source;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Grade
		{
			set{ _grade=value;}
			get{return _grade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AwardGrade
		{
			set{ _awardgrade=value;}
			get{return _awardgrade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Funds1
		{
			set{ _funds1=value;}
			get{return _funds1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Funds2
		{
			set{ _funds2=value;}
			get{return _funds2;}
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
        public decimal? LevelFactor
		{
			set{ _levelfactor=value;}
			get{return _levelfactor;}
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

