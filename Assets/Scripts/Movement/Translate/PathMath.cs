using System;
using Cinemachine;
using JetBrains.Annotations;
using UnityEngine;

namespace Movement.Translate {
	[Serializable]
	public class PathMath {
		private const float DAMP = 1.8f;
		private const int SEARCH_RADIUS = -1;
		private const int STEPS_PER_SEGMENT = 10;

		[SerializeField] private CinemachinePathBase path;

		// THIS IS KINDA BAD.
		[SerializeField] private float closestPoint;
		private Vector3 _prevPos;

		public CinemachinePathBase Path {
			set {
				if (value == path) return;
				path = value;
				if (path is null) {
					closestPoint = 0;
				}
			}
			get => path;
		}

		public PathMath([CanBeNull] CinemachinePathBase path = null) {
			this.path = path;
		}

		public float GetClosestPathPoint(Vector3 currentPos) {
			if (currentPos == _prevPos) {
				return closestPoint;
			}
			_prevPos = currentPos;


			// TODO:
			// figure out a good search radius
			// find good steps per segment
			closestPoint = path.FindClosestPoint(
				currentPos,
				(int) closestPoint, // TODO: check if this is correct
				SEARCH_RADIUS, STEPS_PER_SEGMENT);
			return closestPoint;
		}

		// CAN PROBABLY OPTIMIZE? Does vector calculations each frame...
		public Vector3 GetTangent(Vector3 currentPos) {
			GetClosestPathPoint(currentPos);
			return path.EvaluateTangent(closestPoint);
		}

		public Vector3 GetForwardToPathPoint(Vector3 currentPos) {
			GetClosestPathPoint(currentPos);
			return path.EvaluatePosition(closestPoint) - currentPos;
		}
	}
}