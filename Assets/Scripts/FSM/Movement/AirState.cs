using System;
using Util.Finite_State_Machine;

namespace FSM.Movement {
	public class AirState : State, IHasMovementTraits {
		public MovementTraits MovementTraits { get; } = new() {
			Acceleration = 1,
			Deceleration = 2,
		};

		protected override Type CheckTransitions() {
			return null;
		}
	}
}