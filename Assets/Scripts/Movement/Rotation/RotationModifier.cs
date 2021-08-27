using System;
using UnityEngine;

namespace Movement.Rotation {
	public class RotationModifier : Modifier<Quaternion> {
		protected override Type ComponentType => typeof(RotationMod);

		public void Awake() {
			val = transform.rotation;
		}

		public override void Update() {
			base.Update();
			transform.rotation = val;
		}
	}
}