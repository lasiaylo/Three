using UnityEngine;

namespace Util.Patterns {
	/// <summary>
	///     Class <c>Point</c> Implements Singleton pattern, a single instantiation of a class that is globally available.
	///     See more info here: https://en.wikipedia.org/wiki/Singleton_pattern
	/// </summary>
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
		private static GameObject _obj;
		private static T _instance;

		public static T Instance {
			get {
				if (_instance != null) return _instance;

				_obj = _obj ? _obj : GameObject.Find("Managers") ?? new GameObject("Managers");
				_obj.AddComponent<T>();
				_instance = _obj.GetComponent<T>();

				return _instance;
			}
		}
	}
}