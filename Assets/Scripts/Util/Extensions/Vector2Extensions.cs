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
	
	#region Solo axis

	public static Vector2 GetSoloX(this Vector2 val) {
		return new Vector2(val.x, 0);
	}

	public static Vector2 GetSoloY(this Vector2 val) {
		return new Vector2(0, val.y);
	}
	
	#endregion

	#region Rotations

	public static Vector2 GetReverse(this Vector2 val) {
		return -val;
	}

	public static Vector2 GetNormalClockwise(this Vector2 val)
	{
		return new Vector2(val.y, -val.x);
	}

	public static Vector2 GetNormalCounterClockwise(this Vector2 val)
	{
		return new Vector2(-val.y, val.x);
	}
	
	public static Vector2 Rotate(this Vector2 v, float degrees) {
		float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
		float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
		float tx = v.x;
		float ty = v.y;
		v.x = (cos * tx) - (sin * ty);
		v.y = (sin * tx) + (cos * ty);
		return v;
	}
	

	#endregion

	#region Comparisons

	public static bool IsAgainst(this Vector2 val, Vector2 compare) {
		return Vector2.Dot(val, compare) < 0;
	}

	#endregion
}