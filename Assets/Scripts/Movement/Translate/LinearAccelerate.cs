using System;
using FSM.Movement;
using UnityEngine;

namespace Movement.Translate {
	/// <summary>
	///     Linearly accelerates owner towards a target direction.
	/// </summary>
	/// <remarks>
	///     Adapted from Celeste's Running Implementation
	///     https://github.com/NoelFB/Celeste/blob/master/Source/Player/Player.cs#L2879
	/// </remarks>
	public class LinearAccelerate : MovementMod {
		public MovementTraits traits;
		public Vector3 InputDirection { private get; set; }

		protected Vector3 Target {
			get {
				float maxSpeed = traits.maxSpeed;
				return Vector3.Scale(InputDirection, new Vector3(maxSpeed, maxSpeed, maxSpeed));
			}
		}

		public override Vector3 Modify(Vector3 val) {
			return Vector3.MoveTowards(val, Target, Speed(val) * Time.deltaTime);
		}

		protected float Speed(Vector3 val) {
			return InputDirection.IsZero() && Vector3.Angle(val.GetXz(), InputDirection.GetXz()) <= 90
				? traits.deceleration
				: traits.acceleration;
		}
	}
}