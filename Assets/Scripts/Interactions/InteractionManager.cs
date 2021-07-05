using JetBrains.Annotations;
using UnityEngine;
using Util.Patterns;

namespace Interactions {
	public class InteractionManager : Singleton<InteractionManager> {
		[SerializeField] [CanBeNull] private InteractBehaviour target;

		public InteractBehaviour Target {
			private get => target;
			set {
				if (value != target) {
					if (target != null) target.Unfocus();
					if (value != null) value.Focus();
					target = value;
				}
			}
		}

		public void Interact() {
			Target?.Interact();
		}
	}
}