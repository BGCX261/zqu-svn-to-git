using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_Publish 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_Publish
	{
		public sr_Publish()
		{}
		#region Model
		private int _pl_pid;
		private string _publisher;
		private string _unitname;
		/// <summary>
		/// 
		/// </summary>
		public int PL_PID
		{
			set{ _pl_pid=value;}
			get{return _pl_pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Publisher
		{
			set{ _publisher=value;}
			get{return _publisher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UnitName
		{
			set{ _unitname=value;}
			get{return _unitname;}
		}
		#endregion Model

	}
}

