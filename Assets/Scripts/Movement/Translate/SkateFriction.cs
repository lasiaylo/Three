using UnityEngine;
using Util.Extensions;

namespace Movement.Translate {
	public class SkateFriction : MovementMod {
		[SerializeField] private float rollFriction = 0.2f;

		// TODO: Incorporate normal force to friction
		public override Vector3 Modify(Vector3 val) {
			Vector2 valXZ = val.GetXZ();
			Vector3 frictionForce = valXZ.GetReverse().ToXZPlane().normalized * valXZ.magnitude * rollFriction * Time.deltaTime;
			return val + frictionForce;
		}
	}
}