using UnityEngine;

namespace Movement.Translate {
	public class LinearAccelerateX : LinearAccelerate {
		public override Vector3 Modify(Vector3 val) {
			return val.MoveTowardsX(Target.x, Speed(val) * Time.deltaTime);
		}
	}
}