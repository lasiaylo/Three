using UnityEngine;


[RequireComponent(typeof(Transform))]
public class ScreenTrack : MonoBehaviour {
	private Camera _camera;
	public Vector3 displacement;

	public void Update() {
		TrackRootScreenPos();
	}

	private void TrackRootScreenPos() {
		transform.position = _camera.WorldToScreenPoint(transform.root.position) + displacement;
	}

	public void Reset() {
		_camera = Camera.main;
		TrackRootScreenPos();
	}
}