using System;
namespace ZQUSR.Model
{
	/// <summary>
	/// ʵ����sr_LevelScores ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class sr_LevelScores
	{
		public sr_LevelScores()
		{}
		#region Model
		private int _pk_id;
		private string _jibie;
		private int _score;
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
		public string JiBie
		{
			set{ _jibie=value;}
			get{return _jibie;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		#endregion Model

	}
}

