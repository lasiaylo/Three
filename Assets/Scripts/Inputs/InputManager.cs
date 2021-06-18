using System;
using Scriptable_Objects.Prototypes.Util.Variable.Default;
using ScriptableObjects.Prototypes.Variable;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs {
	public class InputManager : MonoBehaviour {
		[SerializeField] private DefaultNormalVector2 input = default;
		[SerializeField] private DefaultPhase jumpPhase = default;
		
		public void OnMove(InputAction.CallbackContext context) {
			input.Val = context.ReadValue<Vector2>();
		}

		public void OnJump(InputAction.CallbackContext context) {
			Debug.Log(context.phase);
			switch (context.phase) {
				case InputActionPhase.Started:
					jumpPhase.Val = Phase.Start;
					break;
				case InputActionPhase.Performed:
					jumpPhase.Val = Phase.Continue;
					break;
				case InputActionPhase.Canceled:
				case InputActionPhase.Disabled:
				case InputActionPhase.Waiting:
					jumpPhase.Val = Phase.End;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}