using System;
using FSM.Movement;
using Scriptable_Objects.Prototypes.Util.Variable.Default;
using ScriptableObjects.Prototypes.Variable;
using UnityEngine;
using Util.Finite_State_Machine;

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
		[SerializeField] protected DefaultNormalVector2 inputDirection = default;

		protected Vector3 Target {
			get {
				float maxSpeed = traits.maxSpeed;
				return Vector3.Scale(inputDirection.Val, new Vector3(maxSpeed, maxSpeed, maxSpeed));
			}
		}

		public override Vector3 Modify(Vector3 val) {
			return Vector3.MoveTowards(val, Target, Speed(val) * Time.deltaTime);
		}

		protected float Speed(Vector3 val) {
			return inputDirection.Val.IsZero() && Vector3.Angle(val.GetXz(), inputDirection.Val) <= 90
				? traits.deceleration
				: traits.acceleration;
		}

		public void SetMovementTraits(State state) {
			if (state is IHasMovementTraits hasMovement) traits = hasMovement.MovementTraits;
		}
	}
}