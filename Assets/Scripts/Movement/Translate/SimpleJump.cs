﻿using UnityEngine;

namespace Util.Movement.Translate {
	public class SimpleJump : Mod<Vector3> {
		private readonly JumpTraits _traits = default;
		private Phase _phase;

		public void Jump() {
			_phase = Phase.Start;
		}

		public override Vector3 Modify(Vector3 direction) {
			if (_phase == Phase.Start) {
				_phase = Phase.End;
				return new Vector3(direction.x, _traits.Speed, direction.z);
			}

			return direction;
		}
	}

	public struct JumpTraits {
		public float Speed;
	}
}