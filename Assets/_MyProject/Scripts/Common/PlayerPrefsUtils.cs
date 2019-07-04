using UnityEngine;

namespace _MyProject.Script.Common
{
	// http://baba-s.hatenablog.com/entry/2016/01/01/100000
	public static class PlayerPrefsUtils
	{
		/// <summary>
		/// 指定されたオブジェクトの情報を保存します
		/// </summary>
		public static void SetObject<T>(string key, T obj)
		{
			var json = JsonUtility.ToJson(obj);
			PlayerPrefs.SetString(key, json);
		}

		/// <summary>
		/// 指定されたオブジェクトの情報を読み込みます
		/// </summary>
		public static bool GetObject<T>(string key, out T obj)
		{
			obj = default(T);
			string json = PlayerPrefs.GetString(key);
			if (json.Equals("")) return false;
			obj = JsonUtility.FromJson<T>(json);
			return true;
		}
	}

}