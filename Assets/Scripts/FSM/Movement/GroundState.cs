using System;
using UnityEngine;

namespace FSM.Movement {
	public class GroundState : MovementState, IHasJumpTraits {
		[SerializeField] private JumpTraits jumpTraits;
		public JumpTraits JumpTraits => jumpTraits;

		protected override Type CheckTransitions() {
			return Controller.isGrounded ? null : typeof(GroundState);
		}
	}
}