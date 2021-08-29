using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Util.Patterns;

namespace Interactions {
	public class InteractionManager : Singleton<InteractionManager> {
		[SerializeField] private HashSet<InteractBehaviour> targets = new HashSet<InteractBehaviour>();
		[SerializeField] private Component interactor; 

		public HashSet<InteractBehaviour> Targets {
			private get => targets;
			set {
				if (value is null) value = new HashSet<InteractBehaviour>();
				if (value.SetEquals(targets)) return;
				UnfocusAll();
				targets = value;
				FocusAll();
			}
		}

		public Component Interactor {
			 private get => interactor;
			 set => interactor = value;
		}
		
		public void Interact(InputAction.CallbackContext context) {
			if (context.started) {
				InteractAll();
			}
		}
		
		private  void InteractAll() {
			foreach (InteractBehaviour behaviour in targets) {
				behaviour.Interact(Interactor);
			}
		}

		private  void UnfocusAll() {
			foreach (InteractBehaviour behaviour in targets) {
				behaviour.Unfocus();
			}
		}
		
		private  void FocusAll() {
			foreach (InteractBehaviour behaviour in targets) {
				behaviour.Focus();
			}
		}
	}
}