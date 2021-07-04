using Traits;
using UnityEngine;
using Util.Finite_State_Machine;

namespace FSM.Movement {
	public abstract class MovementState : State {
		[SerializeField] private MovementTraits movementTraits = default;
		[SerializeField] private JumpTraits jumpTraits = default;
		private MovementTrait _movementTrait = default;
		private JumpTrait _jumpTrait = default;

		protected CharacterController Controller;

		public void Awake() {
			Controller = GetComponentInParent<CharacterController>();
			Transform parent = transform.parent;
			_movementTrait = parent.GetComponentInChildren<MovementTrait>();
			_jumpTrait = parent.GetComponentInChildren<JumpTrait>();
		}

		protected override void EnterImpl() {
			_movementTrait.val = movementTraits;
			_jumpTrait.val = jumpTraits;
		}
	}
}