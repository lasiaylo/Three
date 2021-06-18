using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Util.Finite_State_Machine;

namespace FSM.Movement {
	public class IdleState : State {
		private Vector2 _input;

		public void SetMovement(InputAction.CallbackContext context) {
			_input = context.ReadValue<Vector2>();
		}

		protected override Type CheckTransitions() {
			return _input.IsZero() ? null : typeof(RunState);
		}
	}
}