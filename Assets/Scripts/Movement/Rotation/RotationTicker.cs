using UnityEngine;
using Util.Movement;

namespace Translate.Rotation {
	public class RotationTicker : Modifier<Quaternion> {
		public void Awake() {
			val = transform.rotation;
		}

		public override void Tick() {
			base.Tick();
			transform.rotation = val;
		}
	}
}