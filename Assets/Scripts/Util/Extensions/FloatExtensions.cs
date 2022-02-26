using UnityEngine;

public static class FloatExtensions {
	public static bool IsZero(this float val) {
		return Mathf.Approximately(val, 0);
	}
	
	# region Vector3

	public static Vector3 ToVector3X(this float val) {
		return new Vector3(val, 0, 0);
	}
	
	public static Vector3 ToVector3Y(this float val) {
		return new Vector3(0, val, 0);
	}
	
	public static Vector3 ToVector3Z(this float val) {
		return new Vector3(0, 0, val);
	}
	 #endregion
}