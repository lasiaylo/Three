using Scriptable_Objects.Prototypes.Util.Variable.Default;
using UnityEngine;
using Util.Patterns;

namespace Interactions {
	public enum ColliderType {
		INTERACT,
		LOOK_AT,
	}

	public class InteractionManager : Singleton<InteractionManager> {
		[SerializeField] private DefaultDirection direction;
		[SerializeField] private Interactable target;
		
		public Interactable Target {
			private get => target;
			set {
				target = value;
			}
		}

		public void Interact() {
			Target.Interact();
		}
	}
}