using System;
using UnityEngine;

namespace Util.Util_Classes {
	// Use this over Clamped<Float> as it's slightly more memory performant (avoids boxing)
	[Serializable]
	public class ClampedFloat {
		[SerializeField] private float val;
		public float min, max;

		public float Val {
			get => val;
			set => val = Mathf.Clamp(value, min, max);
		}

		public ClampedFloat(float val, float min = float.MinValue, float max = float.MaxValue) {
			this.val = val;
			this.min = min;
			this.max = max;
		}

		public static implicit operator float(ClampedFloat self) {
			return self.val;
		}

		public static implicit operator bool(ClampedFloat self) {
			return self.val > 0;
		}

		public static implicit operator ClampedFloat(float value) {
			return new ClampedFloat(value);
		}
	}
}