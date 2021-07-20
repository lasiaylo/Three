using System;
using Interactions;
using UnityEngine;
using Util.Utils;
using Yarn.Unity;

public class DialogueInteract : InteractBehaviour {
	public Name characterName;
	private string characterNameString;
	private string yarnNode;
	private DialogueRunner _runner;

	public void Awake() {
		_runner = FindObjectOfType<DialogueRunner>();
		characterNameString = characterName.ToString();
		DayManager.Instance.onDayChange.AddListener(OnDayChange);
	}

	public void OnDayChange(string day) {
		Debug.Log(day);
		yarnNode = String.Format("{0}{1}", day, characterNameString);
	}

	public override void Interact() {
		if (_runner.IsDialogueRunning) return;
		_runner.StartDialogue(yarnNode);
	}

	public override void Focus() {
		if (_runner.IsDialogueRunning) return;
		// Show icon
	}

	public override void Unfocus() { }
}