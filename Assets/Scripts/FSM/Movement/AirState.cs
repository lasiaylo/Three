using System;
using Util.Finite_State_Machine;

namespace FSM.Movement {
	public class AirState : State, IHasMovementTraits {
		public MovementTraits MovementTraits { get; } = new MovementTraits {
			acceleration = 1,
			deceleration = 2,
		};

		protected override Type CheckTransitions() {
			return null;
		}
	}
}