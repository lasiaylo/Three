using Scriptable_Objects.Prototypes.Util.Variable.Default;
using Traits;
using UnityEngine;
using Util.Extensions;

namespace Movement.Translate {
	/// <summary>
	///     Linearly accelerates owner towards a target direction.
	/// </summary>
	/// <remarks>
	///     Adapted from Celeste's Running Implementation
	///     https://github.com/NoelFB/Celeste/blob/master/Source/Player/Player.cs#L2879
	/// </remarks>
	public class LinearAccelerate : MovementMod {
		[SerializeField] protected DefaultNormalVector2 inputDirection = default;
		private MovementTrait _trait;

		public void Awake() {
			_trait = transform.parent.GetComponentInChildren<MovementTrait>();
		}

		protected Vector3 Target {
			get {
				float maxSpeed = _trait.val.maxSpeed;
				return Vector3.Scale(
					new Vector3(inputDirection.Val.x, 0, inputDirection.Val.y),
					new Vector3(maxSpeed, maxSpeed, maxSpeed)
				);
			}
		}

		public override Vector3 Modify(Vector3 val) {
			return Vector3.MoveTowards(val, Target, GetSpeed(val) * Time.deltaTime);
		}

		protected virtual bool ShouldAccelerate(Vector3 val) {
			return !inputDirection.Val.IsZero() && Vector3.Angle(val.GetXZ(), inputDirection.Val) <= 90;
		}

		protected float GetSpeed(Vector3 val) {
			return ShouldAccelerate(val)
				? _trait.val.acceleration
				: _trait.val.deceleration;
		}
	}
}