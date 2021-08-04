using Scriptable_Objects.Prototypes.Traits;
using Scriptable_Objects.Prototypes.Util.Variable.Default;
using Traits;
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
		[SerializeField] protected DefaultNormalVector2 inputDirection = default;
		private MovementTrait _trait;

		public void Awake() {
			_trait = transform.parent.GetComponentInChildren<MovementTrait>();
		}

		protected Vector3 Target {
			get {
				float maxSpeed = _trait.val.maxSpeed;
				return Vector3.Scale(inputDirection.Val, new Vector3(maxSpeed, maxSpeed, maxSpeed));
			}
		}

		public override Vector3 Modify(Vector3 val) {
			return Vector3.MoveTowards(val, Target, Speed(val) * Time.deltaTime);
		}

		protected float Speed(Vector3 val) {
			return inputDirection.Val.IsZero() && Vector3.Angle(val.GetXz(), inputDirection.Val) <= 90
				? _trait.val.deceleration
				: _trait.val.acceleration;
		}
	}
}