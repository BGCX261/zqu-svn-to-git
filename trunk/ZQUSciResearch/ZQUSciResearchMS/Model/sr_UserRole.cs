using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_UserRole 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_UserRole
	{
		public sr_UserRole()
		{}
		#region Model
		private int _pk_id;
		private string _fk_roleid;
		private string _fk_userid;
		/// <summary>
		/// 
		/// </summary>
		public int PK_ID
		{
			set{ _pk_id=value;}
			get{return _pk_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FK_RoleID
		{
			set{ _fk_roleid=value;}
			get{return _fk_roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FK_UserID
		{
			set{ _fk_userid=value;}
			get{return _fk_userid;}
		}
		#endregion Model

	}
}

