using System;

namespace FSM.Movement {
	public class AirState : MovementState {
		protected override Type CheckTransitions() {
			return Controller.isGrounded ? typeof(GroundState) : null;
		}
	}
}	