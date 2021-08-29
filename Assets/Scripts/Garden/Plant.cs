using Garden.Factors;
using Interactions;
using UnityEngine;

namespace Garden {
	public class Plant : InteractBehaviour {
		public PlantType plantType;
		public Health health;
		public Soil soil;

		public void Awake() {
			DayManager.Instance.onDayEnd.AddListener(day => CheckHealth());
		}

		public void CheckHealth() {
			health.UpdateHealth();
			// Change plant's status based off of health 
		}

		public override void Interact(Component interactor) { }

		public override void Focus() { }

		public override void Unfocus() { }
	}
}