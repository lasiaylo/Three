using System;
using System.Linq;

namespace Util.Finite_State_Machine {
	public sealed class FiniteStateMachine : State {
		public void Awake() {
			currentSubState = substateList.FirstOrDefault();
		}

		protected override Type CheckTransitions() {
			return null;
		}∂
	}
}