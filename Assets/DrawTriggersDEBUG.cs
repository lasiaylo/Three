using System;
using UnityEngine;

public class DrawTriggersDEBUG : MonoBehaviour {
	public Color color = Color.red;
	private BoxCollider[] colliders;

	public void OnDrawGizmos() {
		if (!enabled) return;
		colliders = GetComponentsInChildren<BoxCollider>();
		Gizmos.color = color;
		if (colliders.Length > 0) {
			foreach (BoxCollider collider in colliders) {
				Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
			}
		}
	}

	public void OnEnable() {
	}
}