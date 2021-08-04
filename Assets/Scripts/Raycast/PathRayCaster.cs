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
			if (hit is null) return;
			pathFollow.Curve = hit;
		}

		public void Reset() {
			pathFollow = transform.parent.GetComponentInChildren<PathFollow>();
			CastTag = General.HAS_PATH;
			color = Color.green;
		}

	}
}