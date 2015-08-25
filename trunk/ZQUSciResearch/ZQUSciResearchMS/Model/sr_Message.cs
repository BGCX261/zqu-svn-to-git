using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// ʵ����sr_Message ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class sr_Message
	{
		public sr_Message()
		{}
		#region Model
		private int _pk_mid;
		private string _title;
		private string _messcontent;
		private string _fk_recieverid;
		private string _fk_senderid;
		private DateTime _sendtime;
		private int? _isread;
		/// <summary>
		/// 
		/// </summary>
		public int PK_MID
		{
			set{ _pk_mid=value;}
			get{return _pk_mid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MessContent
		{
			set{ _messcontent=value;}
			get{return _messcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FK_RecieverID
		{
			set{ _fk_recieverid=value;}
			get{return _fk_recieverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FK_SenderID
		{
			set{ _fk_senderid=value;}
			get{return _fk_senderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime SendTime
		{
			set{ _sendtime=value;}
			get{return _sendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		#endregion Model

	}
}

