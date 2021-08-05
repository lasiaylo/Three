using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interactions {
	public class InteractZoneManager : MonoBehaviour {
		[SerializeField] private List<InteractBehaviour> interactBehaviours;
		private HashSet<InteractBehaviour> interactBehavioursSet;
		private Dictionary<InteractZone, bool> _zoneDict;

		public void Awake() {
			_zoneDict = GetComponentsInChildren<InteractZone>().ToDictionary(zone => zone, _ => false);
			if (interactBehaviours is null || interactBehaviours.Count == 0) {
				Debug.LogError("No InteractBehaviours found on this game object. Try resetting this component or adding behaviours");
			}
			else {
				interactBehavioursSet = new HashSet<InteractBehaviour>(interactBehaviours);
			}
		}

		public void UpdateTrigger(InteractZone zone, bool isTriggered) {
			if (_zoneDict[zone] == isTriggered) return;

			_zoneDict[zone] = isTriggered;
			if (_zoneDict.Values.Any(triggered => triggered)) {
				InteractionManager.Instance.Targets = interactBehavioursSet;
				return;
			}

			InteractionManager.Instance.Targets = null;
		}

		public void Reset() {
			interactBehaviours = new List<InteractBehaviour>(GetComponents<InteractBehaviour>());
		}
	}
}