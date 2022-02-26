using System;
using UnityEngine;

namespace Util.Extensions {
	public static class Vector3Extensions {
		private static readonly float _tolerance = 0.001f;

		#region Is Zero

		public static bool IsZero(this Vector3 val) {
			return Math.Abs(val.magnitude) < _tolerance;
		}

		#endregion

		#region Move Towards One Axis

		public static Vector3 MoveTowardsX(this Vector3 val, float target, float maxDistanceDelta) {
			return Vector3.MoveTowards(val, new Vector3(target, val.y, val.z), maxDistanceDelta);
		}

		public static Vector3 MoveTowardsY(this Vector3 val, float target, float maxDistanceDelta) {
			return Vector3.MoveTowards(val, new Vector3(val.x, target, val.z), maxDistanceDelta);
		}

		public static Vector3 MoveTowardsZ(this Vector3 val, float target, float maxDistanceDelta) {
			return Vector3.MoveTowards(val, new Vector3(val.x, val.y, target), maxDistanceDelta);
		}

		#endregion

		#region Move Towards Plane

		public static Vector3 MoveTowardsXY(this Vector3 val, Vector3 target, float maxDistanceDelta) {
			return Vector3.MoveTowards(val, new Vector3(target.x, target.y, val.z), maxDistanceDelta);
		}

		public static Vector3 MoveTowardsXZ(this Vector3 val, Vector3 target, float maxDistanceDelta) {
			return Vector3.MoveTowards(val, new Vector3(target.x, val.y, target.z), maxDistanceDelta);
		}

		public static Vector3 MoveTowardsYZ(this Vector3 val, Vector3 target, float maxDistanceDelta) {
			return Vector3.MoveTowards(val, new Vector3(val.x, target.y, target.y), maxDistanceDelta);
		}

		#endregion

		# region Velocity towards

		public static Vector3 VelocityTowards(this Vector3 val, Vector3 target, float speed) {
			Vector3 forward = target - val;
			return Vector3.ClampMagnitude(forward.normalized * speed, forward.magnitude);
		}

		#endregion

		#region Get Plane

		public static Vector2 GetXY(this Vector3 val) {
			return new Vector2(val.x, val.y);
		}

		public static Vector2 GetXZ(this Vector3 val) {
			return new Vector2(val.x, val.z);
		}

		public static Vector2 GetYZ(this Vector3 val) {
			return new Vector2(val.y, val.z);
		}

		#endregion
		
		#region Solo axis

		public static Vector3 GetSoloX(this Vector3 val) {
			return new Vector3(val.x, 0, 0);
		}

		public static Vector3 GetSoloY(this Vector3 val) {
			return new Vector3(0, val.y, 0);
		}
		
		public static Vector3 GetSoloZ(this Vector3 val) {
			return new Vector3(0, 0, val.z);
		}
	
		#endregion

		#region Screen Position

		public static bool IsCameraLeftOf(this Vector3 val, Vector3 target, Camera cam) {
			return cam.WorldToScreenPoint(val).x < cam.WorldToScreenPoint(target).x;
		}

		public static bool IsCameraRightOf(this Vector3 val, Vector3 target, Camera cam) {
			return target.IsCameraLeftOf(val, cam);
		}

		#endregion
	}
}