using UnityEngine;
using Util.Patterns;

public class InputManager : Singleton<InputManager> {
	[SerializeField] private UnityEngine.InputSystem.PlayerInput _input;

	public void Reset() {
		_input = GetComponent<UnityEngine.InputSystem.PlayerInput>();
	}

	public void SwitchToMovement() {
		_input.SwitchCurrentActionMap("Movement");
	}

	public void SwitchToMenu() {
		_input.SwitchCurrentActionMap("Menu");
	}
}