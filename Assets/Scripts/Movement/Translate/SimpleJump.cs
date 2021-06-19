using Scriptable_Objects.Prototypes.Traits;
using ScriptableObjects.Prototypes.Variable;
using UnityEngine;

namespace Movement.Translate {
	public class SimpleJump : MovementMod {
		[SerializeField] private DefaultJumpTraits traits = default;
		[SerializeField] private DefaultPhase jumpPhase = default; 

		public override Vector3 Modify(Vector3 direction) {
			if (!traits.Val.canJump || jumpPhase.Val == Phase.End) return direction;
			jumpPhase.Val = Phase.End;
			return new Vector3(direction.x, traits.Val.speed, direction.z);
		}

	}
	

}