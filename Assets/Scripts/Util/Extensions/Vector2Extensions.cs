using System;
using UnityEngine;

public static class Vector2Extensions {
	private static readonly float _tolerance = 0.001f;

	#region Is Zero

	public static bool IsZero(this Vector2 val) {
		return Math.Abs(val.magnitude) < _tolerance;
	}

	#endregion

	#region Move Towards One Axis

	public static Vector2 MoveTowardsX(this Vector2 val, float target, float maxDistanceDelta) {
		return Vector2.MoveTowards(val, new Vector2(target, val.y), maxDistanceDelta);
	}

	public static Vector2 MoveTowardsY(this Vector2 val, float target, float maxDistanceDelta) {
		return Vector2.MoveTowards(val, new Vector2(val.x, target), maxDistanceDelta);
	}

	#endregion

	#region To Vector3

	public static Vector3 ToXYPlane(this Vector2 val) {
		return new Vector3(val.x, val.y, 0);
	}

	public static Vector3 ToXZPlane(this Vector2 val) {
		return new Vector3(val.x, 0, val.y);
	}

	public static Vector3 ToYZPlane(this Vector2 val) {
		return new Vector3(0, val.x, val.y);
	}

	#endregion

	#region Clamp

	public static Vector2 Clamp(this Vector2 val, Vector2 min, Vector3 max) {
		return new Vector2(
			Mathf.Clamp(val.x, min.x, max.x),
			Mathf.Clamp(val.y, min.y, max.y)
		);
	}

	#endregion
}