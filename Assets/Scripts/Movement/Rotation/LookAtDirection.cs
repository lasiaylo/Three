using System;
using ScriptableObjects.Prototypes.Variable;
using UnityEngine;

namespace Movement.Rotation {
	public class LookAtDirection : Mod<Quaternion> {
		public bool x;
		public bool y;
		public bool z;
		[SerializeField] private DefaultVector3 direction = default;
		[SerializeField] private float turnSpeed = default;

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
			rotation.x *= Convert.ToInt32(x);
			rotation.y *= Convert.ToInt32(y);
			rotation.z *= Convert.ToInt32(z);
			return rotation;
		}
	}
}