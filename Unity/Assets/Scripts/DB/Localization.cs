/********************************
该脚本是自动生成的请勿手动修改
*********************************/
using System.Collections.Generic;
using Config.ConfigCore;
namespace NonameStudio.Config
{
	
	public partial class LocalizationProperty : ConfigAssetManager<LocalizationProperty>
	{
		private static string Path = "DB/Localization.json";
		private string mId;
		private string mChinese;
		private string mChinese_tw;
		private string mEnglish;
		private string mSpanish;
		private string mGerman;
		private string mFrench;
		private string mIndonesian;
		private string mPortugese;
		private string mThai;
		private string mItalian;
		/// <summary>
		/// Id
		/// </summary>
		public string Id
		{
			get{ return mId; }
			set{ mId = value; }
		}
		/// <summary>
		/// 中文
		/// </summary>
		public string Chinese
		{
			get{ return mChinese; }
			set{ mChinese = value; }
		}
		/// <summary>
		/// 繁体
		/// </summary>
		public string Chinese_tw
		{
			get{ return mChinese_tw; }
			set{ mChinese_tw = value; }
		}
		/// <summary>
		/// 英文
		/// </summary>
		public string English
		{
			get{ return mEnglish; }
			set{ mEnglish = value; }
		}
		/// <summary>
		/// 西班牙语
		/// </summary>
		public string Spanish
		{
			get{ return mSpanish; }
			set{ mSpanish = value; }
		}
		/// <summary>
		/// 德语
		/// </summary>
		public string German
		{
			get{ return mGerman; }
			set{ mGerman = value; }
		}
		/// <summary>
		/// 法语
		/// </summary>
		public string French
		{
			get{ return mFrench; }
			set{ mFrench = value; }
		}
		/// <summary>
		/// 印度尼西亚
		/// </summary>
		public string Indonesian
		{
			get{ return mIndonesian; }
			set{ mIndonesian = value; }
		}
		/// <summary>
		/// 葡萄牙语
		/// </summary>
		public string Portugese
		{
			get{ return mPortugese; }
			set{ mPortugese = value; }
		}
		/// <summary>
		/// 泰语
		/// </summary>
		public string Thai
		{
			get{ return mThai; }
			set{ mThai = value; }
		}
		/// <summary>
		/// 意大利语
		/// </summary>
		public string Italian
		{
			get{ return mItalian; }
			set{ mItalian = value; }
		}
		public static LocalizationProperty Read(string id, bool throwException = true)
		{
			return ConfigAssetManager<LocalizationProperty>.Read(id, throwException);
		}
		public static Dictionary<string,LocalizationProperty> ReadDict()
		{
			return ConfigAssetManager<LocalizationProperty>.ReadstringDict();
		}
		public static List<LocalizationProperty> ReadList()
		{
			return ConfigAssetManager<LocalizationProperty>.ReadList();
		}
	}
}
