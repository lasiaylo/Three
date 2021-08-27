using ScriptableObjects.Prototypes.Variable;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Movement.Rotation {
	public class LookAtDirection : Mod<Quaternion> {
		[SerializeField] private DefaultVector3 direction = default;
		[SerializeField] private float turnSpeed = default;
		public Vector3 vec;

		public override Quaternion Modify(Quaternion val) {
			Vector3 lookDir = new Vector3(direction.Val.x, 0, direction.Val.z);
			return lookDir.IsZero()
				? val
				: Quaternion.RotateTowards(
					val,
					GetLookDirection(lookDir),
					turnSpeed
				);
		}

		private Quaternion GetLookDirection(Vector3 lookDir) {
			Quaternion rotation = Quaternion.LookRotation(direction.Val);
			rotation *= Quaternion.Euler(0, -90, 0); // TODO: Figure out a faster way if possible
			return rotation;
		}
	}
}