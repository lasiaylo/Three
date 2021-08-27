using ScriptableObjects.Prototypes.Variable;
using UnityEngine;

namespace Movement.Rotation {
	public class LookAtDirection : Mod<Quaternion> {
		[SerializeField] private DefaultVector3 direction = default;
		[SerializeField] private float turnSpeed = default;

		public override Quaternion Modify(Quaternion val) {
			return direction.Val.IsZero()
				? val
				: Quaternion.RotateTowards(
					val,
					Quaternion.LookRotation(direction.Val),
					turnSpeed * Time.deltaTime
				);
		}
	}
}