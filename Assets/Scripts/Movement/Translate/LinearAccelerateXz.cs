using UnityEngine;
using Util.Extensions;

namespace Movement.Translate {
	public class LinearAccelerateXz : LinearAccelerate {
		public override Vector3 Modify(Vector3 val) {
			Debug.Log(Target);
			return val.MoveTowardsXz(Target, GetSpeed(val) * Time.deltaTime);
		}
	}
}