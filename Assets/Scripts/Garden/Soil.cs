using Garden.Factors;
using Interactions;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Util.Util_Classes;
using Util.Utils;

namespace Garden {
	public class Soil : InteractBehaviour {

		// Will need to change this as we allow planting on a plane
		public ClampedFloat damp;
		public Plant plant;
		private AsyncOperationHandle<GameObject> _plantHandle; // Use to deroot later 

		public override void Interact(Component interactor) {
			if (plant is null) {
				AD.Instantiate(Path.PLANT_ADDRESS, PlantType.TOMATO.ToString(),transform, Sow);
			}
			else {
				Water(1);
			}
		}

		public void OnDayEnd() {
			// Dry soil by certain amount
			// Have chance of weeds to grow
		}

		private void Sow(GameObject obj) {
			plant = obj.GetComponent<Plant>();
			plant.soil = this;
		}

		private void Water(float amount) {
			damp.Val += amount;
		}

		public override void Focus() { }

		public override void Unfocus() { }
	}
}