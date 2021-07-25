using Util.Utils;

namespace Interactions {
	public class DialogueInteract : IconInteractBehaviour {
		public Name characterName;
		private string _characterNameString;

		public void Awake() {
			_characterNameString = "1-" + characterName.ToString();
		}

		public override void Interact() {
			YarnManager.Instance.StartDialogue(_characterNameString);
		}
	}
}