using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement.Translate {
	public class LinearAccelerateX : LinearAccelerate {
		public override Vector3 Modify(Vector3 val) {
			return val.MoveTowardsX(Target.x, Speed(val) * Time.deltaTime);
		}
		
		public void OnMove(InputAction.CallbackContext context) {
			float input = context.ReadValue<float>();
			Debug.Log(input);
			InputDirection = new Vector3(input, 0, 0);
		}
	}
}