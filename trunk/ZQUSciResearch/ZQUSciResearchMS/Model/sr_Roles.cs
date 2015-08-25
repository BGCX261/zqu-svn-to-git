using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// 实体类sr_Roles 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sr_Roles
	{
		public sr_Roles()
		{}
		#region Model
		private string _pk_roleid;
		private string _rolename;
		private string _roleintro;
		/// <summary>
		/// 
		/// </summary>
		public string PK_RoleID
		{
			set{ _pk_roleid=value;}
			get{return _pk_roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleIntro
		{
			set{ _roleintro=value;}
			get{return _roleintro;}
		}
		#endregion Model

	}
}

