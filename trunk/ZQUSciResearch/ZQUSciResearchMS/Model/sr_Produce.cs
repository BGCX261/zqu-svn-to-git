using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// ʵ����sr_Produce ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class sr_Produce
	{
		public sr_Produce()
		{}
		#region Model
		private int _pk_pid;
		private string _xueke;
		private string _source;
		private string _jibie;
		private decimal _levelfactor;
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
		public string XueKe
		{
			set{ _xueke=value;}
			get{return _xueke;}
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
		public string JiBie
		{
			set{ _jibie=value;}
			get{return _jibie;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal LevelFactor
		{
			set{ _levelfactor=value;}
			get{return _levelfactor;}
		}
		#endregion Model

	}
}

