using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// ʵ����sr_Publish ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

