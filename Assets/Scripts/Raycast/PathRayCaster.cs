using System;
using Cinemachine;
using Movement.Translate;
using UnityEngine;
using Util;

namespace Raycast {
	public class PathRayCaster : RayCaster<CinemachinePathBase> {
		public PathFollow pathFollow;
		public Vector3 offSet;

		protected override Vector3 Direction {
			get => Vector3.down;
			set { }
		}

		protected override Enum CastTag { get => General.HAS_PATH; }

		protected override Vector3 Offset {
			get => offSet; //REALLY BAD. Make it so that it starts from the bottom of the character. 
		}

		public override void OnCast(CinemachinePathBase hit) {
			if (hit is null) return;
			pathFollow.Path = hit;
		}

		public void Reset() {
			pathFollow = transform.parent.GetComponentInChildren<PathFollow>();
		}
	}
}