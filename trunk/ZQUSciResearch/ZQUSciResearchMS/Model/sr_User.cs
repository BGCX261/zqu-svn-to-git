using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_User 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_User
	{
		public sr_User()
		{}
		#region Model
		private string _pk_userid;
		private string _username;
		private string _password;
		private string _sex;
		private string _unit;
		private string _education;
		private string _zhicheng;
		private string _telephone;
		private int? _inoffice;
		private string _email;
		private int? _logins;
		private DateTime? _lastlogin;
		private int? _status;
		private string _extra1;
		private string _extra2;
		private string _extra3;
		/// <summary>
		/// 
		/// </summary>
		public string PK_UserID
		{
			set{ _pk_userid=value;}
			get{return _pk_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Education
		{
			set{ _education=value;}
			get{return _education;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZhiCheng
		{
			set{ _zhicheng=value;}
			get{return _zhicheng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? InOffice
		{
			set{ _inoffice=value;}
			get{return _inoffice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Logins
		{
			set{ _logins=value;}
			get{return _logins;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastLogin
		{
			set{ _lastlogin=value;}
			get{return _lastlogin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
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

