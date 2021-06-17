using System;
using FSM.Movement;

namespace Util.Finite_State_Machine {
	public class GroundState : State, IHasMovementTraits {
		public MovementTraits MovementTraits { get; }

		protected override Type CheckTransitions() {
			throw new NotImplementedException();
		}
	}
}