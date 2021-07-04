using System;
using Scriptable_Objects.Prototypes.Util.Variable.Default;
using UnityEngine;
using UnityEngine.Events;

namespace Movement.Translate {
	/// <summary>
	///     Handles Gravity for GameObjects
	/// </summary>
	/// <remarks>
	///     Adapted from Celeste's Gravity Implementation:
	///     https://github.com/NoelFB/Celeste/blob/master/Source/Player/Player.cs#L2927
	/// </remarks>
	public class Gravity : MovementMod {
		public static float GroundFallSpeed = 1;
		public static float GroundGravity = 1;
		public UnityEvent<Direction> arcEvent;
		private bool _arcStart;
		private CharacterController _controller;
		public GravityTraits traits;

		public void Awake() {
			_controller = GetComponent<CharacterController>();
		}

		public override Vector3 Modify(Vector3 val) {
			float fallSpeed = -GroundFallSpeed;
			float delta = GroundGravity;
			if (!_controller.isGrounded) {
				fallSpeed = -traits.maxFallSpeed;
				float arcMult = ShouldArc(val) ? traits.arcMult : 1;
				delta = traits.gravity * arcMult;
			}

			return val.MoveTowardsY(fallSpeed, delta * Time.deltaTime);
		}

		private bool ShouldArc(Vector3 direction) {
			bool shouldArc = !_controller.isGrounded && Math.Abs(direction.y) < traits.arcThreshold;
			if (shouldArc && direction.y > 0 && _arcStart) {
				arcEvent.Invoke(direction.y > 0 ? Direction.UP : Direction.DOWN);
				_arcStart = false;
			}

			_arcStart = _controller.isGrounded || _arcStart;

			return shouldArc;
		}
	}

	[Serializable]
	public struct GravityTraits {
		public float arcThreshold;
		public float arcMult;
		public float gravity;
		public float maxFallSpeed;
	}
}