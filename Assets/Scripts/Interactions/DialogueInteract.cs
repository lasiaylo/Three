using Interactions;
using Util.Utils;

public class DialogueInteract : InteractBehaviour {
	public Name characterName;
	private string _characterNameString;

	public void Awake() {
		_characterNameString = characterName.ToString();
	}

	public override void Interact() {
		YarnManager.Instance.StartDialogue(_characterNameString);
	}

	public override void Focus() { }

	public override void Unfocus() { }
}