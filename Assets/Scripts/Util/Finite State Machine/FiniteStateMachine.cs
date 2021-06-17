using System;

namespace Util.Finite_State_Machine {
	public sealed class FiniteStateMachine : State {
		protected override Type CheckTransitions() {
			return null;
		}
	}
}