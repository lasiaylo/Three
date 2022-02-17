using Movement;
using UnityEngine;
using Util.Extensions;

public class MoveToLocation : Mod<Vector3> {
	public Vector3 target;
	public float speed;
	private bool shouldMove = true;

	public override Vector3 Modify(Vector3 val) {
		Vector3 currentPos = transform.parent.position;
		if (!shouldMove || currentPos == target || speed == 0) {
			shouldMove = false;
			return val;
		}
		return currentPos.VelocityTowards(target, speed);
	}

	public void SetDestination(Vector3 destination) {
		target = destination;
		shouldMove = true;
	}
}