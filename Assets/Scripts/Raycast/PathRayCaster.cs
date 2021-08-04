using BansheeGz.BGSpline.Curve;
using UnityEngine;
using Util;

namespace Raycast {
	public class PathRayCaster : RayCaster<BGCurve> {
		public PathFollow pathFollow;

		public override Vector3 Direction {
			get => Vector3.down;
			set { }
		}
		
		public override void OnCast(BGCurve hit) {
			Debug.Log(hit);
			pathFollow.Curve = hit;
		}

		public void Reset() {
			pathFollow = GetComponentInParent<PathFollow>();
			CastTag = General.HAS_PATH;
			color = Color.green;
		}

	}
}