using UnityEngine;
using Util.Finite_State_Machine;

namespace FSM.Movement {
	public abstract class MovementState : State, IHasMovementTraits {
		[SerializeField] private MovementTraits movementTraits;
		public MovementTraits MovementTraits => movementTraits;

		protected CharacterController Controller;

		public void Awake() {
			Controller = GetComponent<CharacterController>();
		}
	}
}