using Scriptable_Objects.Prototypes.Util.Variable.Default;
using UnityEngine;

public class TransformRotator : MonoBehaviour {
	public DefaultQuaternion direction;

	public void Update() {
		transform.rotation = direction.Val;
	}
}