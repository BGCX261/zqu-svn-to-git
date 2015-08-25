using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_Lunwen 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_Lunwen
	{
		public sr_Lunwen()
		{}
		#region Model
		private int _pk_lid;
		private string _type;
		private string _situation;
		private decimal? _factor1;
        private decimal? _factor2;
		private string _jibie;
        private decimal? _levelfactor;
		private string _extra1;
		private string _extra2;
		/// <summary>
		/// 
		/// </summary>
		public int PK_LID
		{
			set{ _pk_lid=value;}
			get{return _pk_lid;}
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
		public string Situation
		{
			set{ _situation=value;}
			get{return _situation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Factor1
		{
			set{ _factor1=value;}
			get{return _factor1;}
		}
		/// <summary>
		/// 
		/// </summary>
        public decimal? Factor2
		{
			set{ _factor2=value;}
			get{return _factor2;}
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

