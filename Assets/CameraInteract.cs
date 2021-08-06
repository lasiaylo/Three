using Cinemachine;
using Interactions;

public class CameraInteract : InteractBehaviour {
	public int priority = 10;
	public CinemachineVirtualCamera _virtualCamera;
	private int originalPriority;

	public override void Interact() {
		originalPriority = _virtualCamera.Priority;
		_virtualCamera.Priority = priority;
	}

	public override void Focus() { }

	public override void Unfocus() { }

	public void Reset() {
		_virtualCamera = transform.parent.GetComponentInChildren<CinemachineVirtualCamera>();
	}
}