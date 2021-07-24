using System;
using System.Collections.Generic;
using Garden.Factors;
using UnityEngine;

namespace Garden {
	public class Health : MonoBehaviour {
		public List<Need> factors;
		[Range(0, 1)] private float _value;

		public float Value {
			get => _value;
			private set {
				if (value > factors.Count) {
					string message = String.Format("New health {0} than number of factors {1}.", value, factors.Count);
					Debug.LogError("message");
					return;
				}

				_value = value;
			}
		}

		public void Awake() {
			if (factors.Count == 0) {
				Need[] components = GetComponents<Need>();
				foreach (Need factor in components) {
					factors.Add(factor);
				}
			}
		}

		public void UpdateHealth() {
			float newHealth = 0;
			foreach (Need factor in factors) {
				factor.CheckConditions();
				newHealth += factor.Value;
			}

			Value = newHealth;
		}
	}
}