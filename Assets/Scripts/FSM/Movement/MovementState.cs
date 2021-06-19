using Scriptable_Objects.Prototypes.Traits;
using UnityEngine;
using Util.Finite_State_Machine;

namespace FSM.Movement {
	public abstract class MovementState : State {
		[SerializeField] private DefaultMovementTraits moveTraitRef;
		[SerializeField] private DefaultJumpTraits jumpTraitRef;
		[SerializeField] private MovementTraits movementTraits;
		[SerializeField] private JumpTraits jumpTraits;

		protected CharacterController controller;

		public void Awake() {
			controller = GetComponentInParent<CharacterController>();
		}

		protected override void EnterImpl() {
			moveTraitRef.Val = movementTraits;
			jumpTraitRef.Val = jumpTraits;
		}
	}
}