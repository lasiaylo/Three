using UnityEngine;

public class DrawTriggersDEBUG : MonoBehaviour {
	public Color color = Color.red;
	private BoxCollider[] colliders;

	void OnDrawGizmos() {
		colliders = GetComponentsInChildren<BoxCollider>();
		Gizmos.color = color;
		if (colliders.Length > 0) {
			foreach (BoxCollider collider in colliders) {
				Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
			}
		}
	}
}