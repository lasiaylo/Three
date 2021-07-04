using System;

namespace FSM.Movement {
	public class GroundState : MovementState {

		protected override Type CheckTransitions() {
			return Controller.isGrounded ? null : typeof(AirState);
		}
	}
}