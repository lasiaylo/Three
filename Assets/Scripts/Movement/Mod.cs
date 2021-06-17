using UnityEngine;

namespace Movement {
	public abstract class Mod<T> : MonoBehaviour {
		/// <summary>
		///     Left in so enable checkbox appears in Inspector
		/// </summary>
		public void OnEnable() { }

		public abstract T Modify(T val);
	}
}