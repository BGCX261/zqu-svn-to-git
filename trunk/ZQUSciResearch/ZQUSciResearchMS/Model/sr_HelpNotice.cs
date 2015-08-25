using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_HelpNotice 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_HelpNotice
	{
		public sr_HelpNotice()
		{}
		#region Model
		private int _pk_hnid;
		private string _title;
		private string _fk_userid;
		private DateTime? _addtime;
		private string _notcontent;
		private int _type;
		private string _extra1;
		private string _extra2;
		private string _extra3;
		/// <summary>
		/// 
		/// </summary>
		public int PK_HNID
		{
			set{ _pk_hnid=value;}
			get{return _pk_hnid;}
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
		public string FK_UserID
		{
			set{ _fk_userid=value;}
			get{return _fk_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NotContent
		{
			set{ _notcontent=value;}
			get{return _notcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Type
		{
			set{ _type=value;}
			get{return _type;}
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

