using Interactions;
using Yarn.Unity;

public class DialogueInteract : InteractBehaviour {
	public string yarnNode;
	private DialogueRunner _runner;

	public void Awake() {
		_runner = FindObjectOfType<DialogueRunner>();
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