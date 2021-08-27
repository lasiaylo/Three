using System;
using Traits;
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
			_controller = GetComponentInParent<CharacterController>();
		}

		public override Vector3 Modify(Vector3 val) {
			float fallSpeed = -GroundFallSpeed;
			float delta = GroundGravity;
			if (!_controller.isGrounded) {
				fallSpeed = -traits.maxFallSpeed;
				delta = GetGravitySpeed(val) * GetArcMultiplier(val);
			}

			return val.MoveTowardsY(fallSpeed, delta * Time.deltaTime);
		}

		private float GetArcMultiplier(Vector3 val) {
			return ShouldArc(val) ? traits.arcMult : 1;
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

		private float GetGravitySpeed(Vector3 val) {
			return val.y > 0 ? traits.upGravity : traits.downGravity;
		}
	}

	[Serializable]
	public struct GravityTraits {
		public float arcThreshold;
		public float arcMult;
		public float upGravity;
		public float downGravity;
		public float maxFallSpeed;
	}
}