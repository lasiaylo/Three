using Cinemachine;
using UnityEngine;
using Util;

namespace Raycast {
	public class PathRayCaster : RayCaster<CinemachinePathBase> {
		public PathFollow pathFollow;

		public override Vector3 Direction {
			get => Vector3.down;
			set { }
		}
		
		public override void OnCast(CinemachinePathBase hit) {
			if (hit is null) return;
			pathFollow.Path = hit;
		}

		public void Reset() {
			pathFollow = transform.parent.GetComponentInChildren<PathFollow>();
			CastTag = General.HAS_PATH;
			color = Color.green;
		}

	}
}