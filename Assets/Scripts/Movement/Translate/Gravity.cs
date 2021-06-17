using System;
using UnityEngine;
using UnityEngine.Events;

namespace Util.Movement.Translate {
	/// <summary>
	///     Handles Gravity for GameObjects
	/// </summary>
	/// <remarks>
	///     Adapted from Celeste's Gravity Implementation:
	///     https://github.com/NoelFB/Celeste/blob/master/Source/Player/Player.cs#L2927
	/// </remarks>
	[Serializable]
	public class Gravity : Mod<Vector3> {
		public static float GroundFallSpeed = 1;
		public static float GroundGravity = 1;
		public UnityEvent<Direction> arcEvent;
		private bool _arcStart;
		private CharacterController _controller;
		public GravityTraits Traits;

		public void Awake() {
			_controller = GetComponent<CharacterController>();
		}

		public override Vector3 Modify(Vector3 val) {
			float fallSpeed = -GroundFallSpeed;
			float delta = GroundGravity;
			if (!_controller.isGrounded) {
				fallSpeed = -Traits.MaxFallSpeed;
				float arcMult = ShouldArc(val) ? Traits.ArcMult : 1;
				delta = Traits.Gravity * arcMult;
			}

			return val.MoveTowardsY(fallSpeed, delta * Time.deltaTime);
		}

		private bool ShouldArc(Vector3 direction) {
			bool shouldArc = !_controller.isGrounded && Math.Abs(direction.y) < Traits.ArcThreshold;
			if (shouldArc && direction.y > 0 && _arcStart) {
				arcEvent.Invoke(direction.y > 0 ? Direction.UP : Direction.DOWN);
				_arcStart = false;
			}

			_arcStart = _controller.isGrounded || _arcStart;

			return shouldArc;
		}
	}

	public struct GravityTraits {
		public float ArcThreshold;
		public float ArcMult;
		public float Gravity;
		public float MaxFallSpeed;
	}

	public enum Direction {
		UP,
		DOWN,
	}
}