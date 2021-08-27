using UnityEngine;

namespace Movement.Translate {
	public class LinearAccelerateX : LinearAccelerate {
		public override Vector3 Modify(Vector3 val) {
			return val.MoveTowardsX(Target.x, GetSpeed(val) * Time.deltaTime);
		}

		protected override bool ShouldAccelerate(Vector3 val) {
			return inputDirection.Val.x != 0 && (val.x * inputDirection.Val.x) >= 0;
		}
	}
}