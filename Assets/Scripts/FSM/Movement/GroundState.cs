using System;

namespace FSM.Movement {
	public class GroundState : MovementState {

		protected override Type CheckTransitions() {
			return controller.isGrounded ? null : typeof(AirState);
		}
	}
}