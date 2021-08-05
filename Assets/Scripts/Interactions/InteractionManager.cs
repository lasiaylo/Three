using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Util.Patterns;

namespace Interactions {
	public class InteractionManager : Singleton<InteractionManager> {
		[SerializeField] private HashSet<InteractBehaviour> targets = new HashSet<InteractBehaviour>();

		public HashSet<InteractBehaviour> Targets {
			private get => targets;
			set {
				if (value is null) value = new HashSet<InteractBehaviour>();
				if (value.SetEquals(targets)) return;
				UnfocusAll(targets);
				targets = value;
				FocusAll(targets);
			}
		}

		public void Interact(InputAction.CallbackContext context) {
			if (context.started) {
				InteractAll(targets);
			}
		}
		
		private static void InteractAll(IEnumerable<InteractBehaviour> behaviours) {
			foreach (InteractBehaviour behaviour in behaviours) {
				behaviour.Interact();
			}
		}

		private static void UnfocusAll(IEnumerable<InteractBehaviour> behaviours) {
			foreach (InteractBehaviour behaviour in behaviours) {
				behaviour.Unfocus();
			}
		}
		
		private static void FocusAll(IEnumerable<InteractBehaviour> behaviours) {
			foreach (InteractBehaviour behaviour in behaviours) {
				behaviour.Focus();
			}
		}
	}
}