using UnityEngine;

namespace Movement.Rotation {
	public class AimAtDirection : Mod<Quaternion> {
		[SerializeField] private float turnSpeed = default;
		public Vector3 Direction { private get; set; }

		public override Quaternion Modify(Quaternion val) {
			return Direction.IsZero()
				? val
				: Quaternion.RotateTowards(
					val,
					Quaternion.LookRotation(Direction),
					turnSpeed * Time.deltaTime
				);
		}
	}
}