using Traits;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement {
	public class PlayerDirection : MonoBehaviour {
		private DirectionTrait _directionTrait;

		public void Awake() {
			_directionTrait = GetComponentInChildren<DirectionTrait>();
		}

		public void OnMove(InputAction.CallbackContext context) {
			Vector2 input = context.ReadValue<Vector2>();
			if (input.x < 0) {
				_directionTrait.val = Direction.LEFT;
			} else if (input.x > 0) {
				_directionTrait.val = Direction.RIGHT;
			}
		}
	}
}