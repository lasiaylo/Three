using UnityEngine;

namespace Garden.Factors {
	public class SoilWaterNeed : Need {
		[Range(-1, 1)] public float targetDampness;
		public Soil soil;

		public void Awake() {
			// soil = plant's soil
		}

		public override float CheckConditions() {
			return 1 - ((targetDampness - soil.damp) / 2);
		}
	}
}