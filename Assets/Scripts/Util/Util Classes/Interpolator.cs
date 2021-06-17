using System.Collections;
using UnityEngine;

/// Taken from Ken Rockot
/// And modified further by Wildan Mubarok
/// <http:// wellosoft.wordpress.com>
public enum InterpolationType {
	/// Standard linear interpolation
	Linear,

	/// Smooth fade interpolation
	SmoothStep,

	/// Smoother fade interpolation than SmoothStep
	SmootherStep,

	/// Sine interpolation, smoothing at the end
	Sinerp,

	/// Cosine interpolation, smoothing at the start
	Coserp,

	/// Extreme bend towards end, low speed at end
	Square,

	/// Extreme bend toward start, high speed at end
	Quadratic,

	/// Stronger bending than Quadratic
	Cubic,

	/// Spherical interpolation, vertical speed at start
	CircularStart,

	/// Spherical interpolation, vertical speed at end
	CircularEnd,

	/// Pure Random interpolation
	Random,

	/// Random interpolation with linear constraining at 0..1
	RandomConstrained,
}

public static class Interpolator {
	public delegate void Callback(float t);

	public static IEnumerator Terp(
		Callback callback,
		float duration,
		float start = 0,
		float end = 1,
		InterpolationType type = InterpolationType.Linear,
		bool isInverted = false
	) {
		float endTime = Time.time + duration;
		while (endTime > Time.time) {
			float t = Step(1 - (endTime - Time.time) / duration, type, isInverted);
			callback(Mathf.Lerp(start, end, t));
			yield return null;
		}

		yield return end;
	}

	// Calculates next step based off of interpolationType
	public static float Step(float t, InterpolationType type = InterpolationType.Linear, bool isInverted = false) {
		switch (type) {
			case InterpolationType.Linear: break;
			case InterpolationType.SmoothStep:
				t = t * t * (3f - 2f * t);
				break;
			case InterpolationType.SmootherStep:
				t = t * t * t * (t * (6f * t - 15f) + 10f);
				break;
			case InterpolationType.Sinerp:
				t = Mathf.Sin(t * Mathf.PI / 2f);
				break;
			case InterpolationType.Coserp:
				t = 1 - Mathf.Cos(t * Mathf.PI / 2f);
				break;
			case InterpolationType.Square:
				t = Mathf.Sqrt(t);
				break;
			case InterpolationType.Quadratic:
				t = t * t;
				break;
			case InterpolationType.Cubic:
				t = t * t * t;
				break;
			case InterpolationType.CircularStart:
				t = Mathf.Sqrt(2 * t + t * t);
				break;
			case InterpolationType.CircularEnd:
				t = 1 - Mathf.Sqrt(1 - t * t);
				break;
			case InterpolationType.Random:
				t = Random.value;
				break;
			case InterpolationType.RandomConstrained:
				t = Mathf.Max(Random.value, t);
				break;
		}

		if (isInverted)
			t = 1 - t;
		return t;
	}
}