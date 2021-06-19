using System;

namespace FSM.Movement {
	public class AirState : MovementState {
		protected override Type CheckTransitions() {
			return controller.isGrounded ? typeof(GroundState) : null;
		}
	}
}	