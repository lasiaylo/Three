using System;
using Movement.Translate;
using UnityEngine;

namespace Movement.Rotation {
	public class RotationTicker : Modifier<Quaternion> {
		protected override Type ComponentType => typeof(MovementMod);

		public void Awake() {
			val = transform.rotation;
		}

		public override void Tick() {
			base.Tick();
			transform.rotation = val;
		}
	}
}