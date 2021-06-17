using UnityEngine;

public static class FloatExtensions {
	public static bool IsZero(this float val) {
		return Mathf.Approximately(val, 0);
	}
}