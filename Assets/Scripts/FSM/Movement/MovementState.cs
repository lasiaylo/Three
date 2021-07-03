using Scriptable_Objects.Prototypes.Traits;
using UnityEngine;
using Util.Finite_State_Machine;

namespace FSM.Movement {
	public abstract class MovementState : State {
		[SerializeField] private DefaultMovementTraits moveTraitRef = default;
		[SerializeField] private DefaultJumpTraits jumpTraitRef = default;
		[SerializeField] private MovementTraits movementTraits = default;
		[SerializeField] private JumpTraits jumpTraits = default;

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