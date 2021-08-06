using UnityEngine;
using UnityEngine.InputSystem;
using Util;
using Util.Utils;

public class FollowCursor : MonoBehaviour {
	[SerializeField] private Camera _camera;

	// REVISIT THIS. Current implementation only works for mouse.

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