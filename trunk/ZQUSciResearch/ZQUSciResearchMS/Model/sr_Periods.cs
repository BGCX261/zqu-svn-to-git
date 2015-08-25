using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_Periods 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_Periods
	{
		public sr_Periods()
		{}
		#region Model
		private int _pk_pid;
		private string _periname;
		private DateTime _starttime;
		private DateTime _endtime;
		private string _extra1;
		private string _extra2;
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
		public string PeriName
		{
			set{ _periname=value;}
			get{return _periname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
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

