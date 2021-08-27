using UnityEngine;

namespace Movement.Translate {
	public class LinearAccelerateXz : LinearAccelerate {
		public override Vector3 Modify(Vector3 val) {
			return val.MoveTowardsXz(Target, GetSpeed(val) * Time.deltaTime);
		}
	}
}