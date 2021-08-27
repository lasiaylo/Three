using ScriptableObjects.Prototypes.Variable;
using Traits;
using UnityEngine;

namespace Movement.Translate {
	public class SimpleJump : MovementMod {
		[SerializeField] private DefaultPhase jumpInput = default;
		private JumpTrait _traits = default;

		public void Awake() {
			_traits = transform.parent.GetComponentInChildren<JumpTrait>();
		}

		public override Vector3 Modify(Vector3 direction) {
			if (!_traits.val.canJump || jumpInput.Val == Phase.End) return direction;
			jumpInput.Val = Phase.End;
			return new Vector3(direction.x, _traits.val.speed, direction.z);
		}
	}
}