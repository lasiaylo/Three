using FSM.Movement;
using ScriptableObjects.Prototypes.Variable;
using UnityEngine;
using Util.Finite_State_Machine;

namespace Movement.Translate {
	public class SimpleJump : MovementMod {
		[SerializeField] private JumpTraits traits = default;
		[SerializeField] private DefaultPhase jumpPhase = default; 

		public override Vector3 Modify(Vector3 direction) {
			if (!traits.canJump || jumpPhase.Val == Phase.End) return direction;
			jumpPhase.Val = Phase.End;
			return new Vector3(direction.x, traits.speed, direction.z);
		}

		public void SetCanJump(State state) {
			if (state is IHasJumpTraits hasJump) traits = hasJump.JumpTraits;
		}
	}
	

}