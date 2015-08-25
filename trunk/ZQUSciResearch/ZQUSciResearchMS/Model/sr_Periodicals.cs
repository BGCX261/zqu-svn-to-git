using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_Periodicals 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_Periodicals
	{
		public sr_Periodicals()
		{}
		#region Model
		private int _pk_pid;
		private string _issn;
		private string _qikankey;
		private string _qikanname;
		private string _qikanengname;
		private string _xueke;
		private decimal? _qif;
		private string _jibie;
		private decimal? _levelfactor;
		private string _extra1;
		private string _extra2;
		private string _extra3;
		/// <summary>
		/// 
		/// </summary>
		public int PK_PID
		{
			set{ _pk_pid=value;}
			get{return _pk_pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ISSN
		{
			set{ _issn=value;}
			get{return _issn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QikanKey
		{
			set{ _qikankey=value;}
			get{return _qikankey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QikanName
		{
			set{ _qikanname=value;}
			get{return _qikanname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QikanEngName
		{
			set{ _qikanengname=value;}
			get{return _qikanengname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XueKe
		{
			set{ _xueke=value;}
			get{return _xueke;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? QIF
		{
			set{ _qif=value;}
			get{return _qif;}
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
		/// <summary>
		/// 
		/// </summary>
		public string Extra3
		{
			set{ _extra3=value;}
			get{return _extra3;}
		}
		#endregion Model

	}
}

