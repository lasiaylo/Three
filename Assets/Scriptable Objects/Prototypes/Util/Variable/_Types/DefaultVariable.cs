using ScriptableObjects.Prototypes;
using UnityEngine;

// Scriptable Object that resets to default value each play.
// TODO: better documentation 
namespace Util.Scriptable_Objects.Prototypes.Variable._Types {
	public abstract class DefaultVariable<T> : DefaultScriptableObject {
		[SerializeField] protected T _Val;
		[SerializeField] protected T DefaultValue;

		public virtual T Val {
			get => _Val;
			set => _Val = value;
		}

		public override void Reset() {
			Val = DefaultValue;
		}
	}
}