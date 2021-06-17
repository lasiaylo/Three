using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs {
	[Serializable]
	public class InputCallback : MovementInput.IMovementActions {
		[SerializeField] private readonly MovementInput _input;

		public InputCallback([CanBeNull] MoveDel move = null, [CanBeNull] JumpDel jump = null) {
			_input.Movement.SetCallbacks(this);
			Debug.Log("thigns fall apart");
			Move = move;
			Jump = jump;
		}

		public delegate void MoveDel(InputAction.CallbackContext context);

		public delegate void JumpDel(InputAction.CallbackContext context);

		public MoveDel Move;
		public JumpDel Jump;

		public void OnMove(InputAction.CallbackContext context) {
			Move.Invoke(context);
		}

		public void OnJump(InputAction.CallbackContext context) {
			Jump.Invoke(context);
		}
	}
}