using UnityEngine;

namespace ScriptableObjects.Prototypes {
	/// <summary>
	///     Scriptable Object that resets value to default
	/// </summary>
	public abstract class DefaultScriptableObject : ScriptableObject, ISerializationCallbackReceiver {
		public abstract void Reset();

		public void OnAfterDeserialize() {
			Reset();
		}

		public void OnBeforeSerialize() { }
	}
}