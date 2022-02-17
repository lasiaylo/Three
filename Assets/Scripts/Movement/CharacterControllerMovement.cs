using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.Prototypes.Variable;
using UnityEngine;
using Util.Scriptable_Objects.Prototypes.Variable._Types;

public class CharacterControllerMovement : MonoBehaviour {
	[SerializeField] private CharacterController controller;
	[SerializeField] private DefaultVector3 direction;

	// Update is called once per frame
	public void Update() {
		controller.Move(direction.Val * Time.deltaTime);
	}

	public void Reset() {
		controller = GetComponent<CharacterController>();
	}
}