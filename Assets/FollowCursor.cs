using UnityEngine;
using UnityEngine.InputSystem;
using Util;
using Util.Utils;

public class FollowCursor : MonoBehaviour {
	[SerializeField] private Camera _camera;
	public int YPos = 1;

	// REVISIT THIS. Current implementation only works for mouse.
	public void OnMove(InputAction.CallbackContext context) {
		Vector2 delta = context.ReadValue<Vector2>();
		Transform transform1 = transform;
		Vector3 pos = transform1.position;
		pos += new Vector3(delta.x, 0, delta.y);
		transform1.position = UIUtils.ClampToScreen(pos);
	}

	// Update is called once per frame
	public void Update() {
		Vector3 cursorPos = Input.mousePosition; // Stupid. Works for whole screen, not game window.
		// Is converting screen position to a point on the plane faster than raycasting? Probably? 

		Ray ray = _camera.ScreenPointToRay(cursorPos);
		RayCastUtil.DebugRay(ray);
		// Debug.Log(RayCastUtil.CastPoint(ray, Mathf.Infinity, General.CAN_PLANT_IN));
		transform.position = RayCastUtil.CastPoint(ray, Mathf.Infinity, General.CAN_PLANT_IN);
	}

	public void Reset() {
		_camera = Camera.main;
	}
}