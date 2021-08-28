using System;
using Scriptable_Objects.Prototypes.Util.Variable.Default;
using UnityEngine;
using Util.Extensions;
using Util.Finite_State_Machine;

namespace FSM.Movement {
	public class RunState : State {
		[SerializeField] private DefaultNormalVector2 input = default;
		private CharacterController _controller;

		public void Awake() {
			_controller = GetComponent<CharacterController>();
		}

		protected override Type CheckTransitions() {
			return input.Val.IsZero() && _controller.velocity.IsZero() ? typeof(IdleState) : null;
		}
	}
}