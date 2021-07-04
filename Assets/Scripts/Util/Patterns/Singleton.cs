using UnityEngine;

namespace Util.Patterns {
	/// <summary>
	///     Class <c>Point</c> Implements Singleton pattern, a single instantiation of a class that is globally available.
	///     See more info here: https://en.wikipedia.org/wiki/Singleton_pattern
	/// </summary>
	public abstract class Singleton<T> : MonoBehaviour {
		public static T Instance { get; private set; }

		private void Awake() {
			if (Instance == null)
				Instance = GetComponent<T>();
			else
				Debug.LogError("Multiple Instances of singleton", this);
		}
	}
}