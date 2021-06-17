using System;
using UnityEngine;

namespace Util.Util_Classes {
	[Serializable]
	public class Looper {
		public float Max;
		public float Min;
		[SerializeField] private float _Val = default;

		public Looper(float min, float max) {
			Min = min;
			Max = max;
			Val = min;
		}

		public float Val {
			get => _Val;
			set {
				Val = value;
				Val = Loop();
			}
		}

		public float Increment(float delta) {
			Val += delta;
			return Loop();
		}

		private float Loop() {
			if (Val > Max) {
				float overflow = Val %= Max;
				// This doesn't work when overflow > Max - Min
				Val = Min + overflow;
				return Val;
			}

			return Val;
		}
	}
}