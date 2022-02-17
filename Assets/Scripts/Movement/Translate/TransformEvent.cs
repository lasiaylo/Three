using UnityEngine;
using UnityEngine.Events;

public class TransformEvent : MonoBehaviour {
	public bool triggerOnTranslate;
	public bool triggerOnRotate;
	[Tooltip("Minimum distance that needs to be travelled before triggering. Set to 0 to always trigger on translate")]
	public float minTriggerDistance;
	[Tooltip("Minimum rotation that needs to be done before triggering. Set to 0 to always trigger on rotate")]
	public float minTriggerRotation;
	public UnityEvent transformEvent;
	private Vector3 prevPos;
	private Quaternion prevRot;

	public void Awake() {
		Transform t = transform;
		prevPos = t.position;
		prevRot = t.rotation;
	}
	
	public void Update() {
		if (transform.hasChanged) {
			if (triggerOnTranslate && triggerOnRotate) { // Assumes we never change scale. 
				InvokeTransformEvent();
				return;
			}
			if (ShouldTriggerOnTranslate(transform.position)) {
				InvokeTransformEvent();
				return;
			}

			if (ShouldTriggerOnRotate(transform.rotation)) {
				InvokeTransformEvent();
				return;
			}
		} 
	}

	private bool ShouldTriggerOnTranslate(Vector3 currentPos) {
		if (!triggerOnTranslate) {
			return false;
		}
		
		if (currentPos != prevPos) {
			if (minTriggerDistance == 0) {
				return true;
			}

			if (Vector3.Distance(currentPos, prevPos) >= minTriggerDistance) {
				prevPos = currentPos;
				return true;
			}
		}

		return false;
	}
	
	private bool ShouldTriggerOnRotate(Quaternion currentRot) {
		if (!triggerOnRotate) {
			return false;
		}
		if (currentRot != prevRot) {
			if (minTriggerRotation == 0) {
				return true;
			}

			if (Quaternion.Angle(currentRot, prevRot) >= minTriggerRotation) {
				prevRot = currentRot;
				return true;
			}
		}

		return false;
	}

	private void InvokeTransformEvent() {
		transformEvent.Invoke();
		transform.hasChanged = false;
	} 
}