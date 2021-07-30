using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interactions {
	public class InteractZoneManager : MonoBehaviour {
		[SerializeField] private InteractBehaviour interactBehaviour;
		private Dictionary<InteractZone, bool> _zoneDict;

		public void Awake() {
			_zoneDict = GetComponentsInChildren<InteractZone>().ToDictionary(zone => zone, _ => false);
		}

		public void UpdateTrigger(InteractZone zone, bool isTriggered) {
			if (_zoneDict[zone] == isTriggered) return;

			_zoneDict[zone] = isTriggered;
			if (_zoneDict.Values.Any(triggered => triggered)) {
				InteractionManager.Instance.Target = interactBehaviour;
				return;
			}

			InteractionManager.Instance.Target = null;
		}

		public void Reset() {
			if (interactBehaviour is null) {
				interactBehaviour = GetComponent<InteractBehaviour>();
			}
		}
	}
}