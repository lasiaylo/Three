using Cinemachine;
using Interactions;
using Movement.Translate;
using UnityEngine;
using Util;
using Util.Utils;

public class MoveInteract : InteractBehaviour {
	[SerializeField] private PathMath math;
	public Vector3 destination = Vector3.zero;

	public void Awake() {
		math = new PathMath();
	}

	public override void Interact(Component interactor) {
		Debug.Log(interactor);
		if (interactor is null) {
			return;
		}

		MoveToLocation move = interactor.GetComponentInChildren<MoveToLocation>();
		move?.SetDestination(destination);
	}

	public override void Focus() { }

	public override void Unfocus() { }

	public void Reset() {
		math.Path = RayCastUtil.CastDownNonAlloc<CinemachinePath>(transform.position, General.HAS_PATH);
	}
}