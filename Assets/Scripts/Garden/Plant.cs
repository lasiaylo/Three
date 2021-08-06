using Garden.Factors;
using Interactions;

namespace Garden {
	public class Plant : InteractBehaviour {
		public PlantType plantType;
		public Health health;
		public SoilTile soil;

		public void Awake() {
			DayManager.Instance.onDayEnd.AddListener(day => CheckHealth());
		}

		public void CheckHealth() {
			health.UpdateHealth();
			// Change plant's status based off of health 
		}

		public override void Interact() { }

		public override void Focus() { }

		public override void Unfocus() { }
	}
}