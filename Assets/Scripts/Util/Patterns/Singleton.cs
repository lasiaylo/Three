using UnityEngine;

namespace Util.Patterns {
	/// <summary>
	///     Class <c>Point</c> Implements Singleton pattern, a single instantiation of a class that is globally available.
	///     See more info here: https://en.wikipedia.org/wiki/Singleton_pattern
	/// </summary>
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
		public static T Instance {
			get;
			private set;
		}

		public void Awake() {
			Instance = GetComponent<T>();
		}
	}
}