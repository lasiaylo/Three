using UnityEngine;

namespace Util.Movement.Rotation {
	public class TurnTowards : Mod<Quaternion> {
		[SerializeField] private float turnSpeed;
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