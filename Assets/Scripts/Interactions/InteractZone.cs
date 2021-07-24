using System;
using UnityEngine;

namespace Interactions {
	[RequireComponent(typeof(Collider))]
	public class InteractZone : MonoBehaviour {
		public InteractZoneManager zoneManager;
		[SerializeField] private bool isTriggered;

		private bool IsTriggered {
			set {
				if (value == isTriggered) return;
				isTriggered = value;
				zoneManager.UpdateTrigger(this, value);
			}
		}

		public void OnDisable() {
			IsTriggered = false;
		}

		public void OnTriggerEnter(Collider other) {
			SetTrigger(other, true);
		}

		public void OnTriggerStay(Collider other) {
			OnTriggerEnter(other);
		}

		public void OnTriggerExit(Collider other) {
			SetTrigger(other, false);
		}

		private void SetTrigger(Component other, bool trigger) {
			if (!other.CompareTag("Player") || !enabled) return;
			IsTriggered = trigger;
		}

		public void Reset() {
			GetComponent<Collider>().isTrigger = true;
			if (zoneManager is null) {
				zoneManager = transform.parent.GetComponentInChildren<InteractZoneManager>();
			}
		}
	}
}