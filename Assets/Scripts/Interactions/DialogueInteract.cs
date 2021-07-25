using Interactions;
using UnityEngine;
using Util.Utils;

public class DialogueInteract : InteractBehaviour {
	public Name characterName;
	private string _characterNameString;

	public void Awake() {
		_characterNameString = "1-" + characterName.ToString();
	}

	public override void Interact() {
		YarnManager.Instance.StartDialogue(_characterNameString);
	}

	public override void Focus() { }

	public override void Unfocus() { }
}