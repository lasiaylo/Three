using UnityEngine;

namespace Interactions {
	public class TestInteract : InteractBehaviour {
		public override void Interact() {
			Debug.Log("Interact");
		}

		public override void Focus() {
			Debug.Log("Focused");
		}

		public override void Unfocus() {
			Debug.Log("Unfocus");
		}
	}
}