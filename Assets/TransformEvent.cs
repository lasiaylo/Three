using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransformEvent : MonoBehaviour {
	public UnityEvent transformEvent;

	public void Update() {
		if (transform.parent.hasChanged) {
			transformEvent.Invoke();
			transform.parent.hasChanged = false;
		} 
	}
}