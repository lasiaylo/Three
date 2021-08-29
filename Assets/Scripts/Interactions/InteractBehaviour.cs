using UnityEngine;

namespace Interactions {
	public abstract class InteractBehaviour : MonoBehaviour {
		public abstract void Interact(Component interactor);
		public abstract void Focus();
		public abstract void Unfocus();
	}
}