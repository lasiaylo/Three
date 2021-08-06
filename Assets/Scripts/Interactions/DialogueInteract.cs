using Util.Utils;

namespace Interactions {
	public class DialogueInteract : InteractBehaviour {
		public Name characterName;
		private string _characterNameString;

		public void Awake() {
			_characterNameString = "1-" + characterName;
		}

		public override void Interact() {
			YarnManager.Instance.StartDialogue(_characterNameString);
		}

		public override void Focus() { }

		public override void Unfocus() { }
	}
}