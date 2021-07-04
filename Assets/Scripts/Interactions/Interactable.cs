using UnityEngine;

namespace Interactions {
	[RequireComponent(typeof(Rigidbody))]
	public abstract class Interactable : MonoBehaviour {
		public abstract void Interact();
		public void LookAt() { }
		
		public void OnTriggerEnter(Collider other) {
			SetInteractionTarget(other, this);
		}

		public void OnTriggerExit(Collider other) {
			SetInteractionTarget(other, null);
		}

		private void SetInteractionTarget(Component other, Interactable target) {
			if (other.CompareTag("Player")) {
				InteractionManager.Instance.Target = target;
			}
		}
	}
}