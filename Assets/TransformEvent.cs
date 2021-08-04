using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransformEvent : MonoBehaviour {
	public UnityEvent transformEvent;

	public void Update() {
		if (transform.hasChanged) {
			transformEvent.Invoke();
			transform.hasChanged = false;
		} 
	}
}