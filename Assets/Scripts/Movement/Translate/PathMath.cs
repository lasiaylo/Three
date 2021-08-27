using Cinemachine;
using JetBrains.Annotations;
using UnityEngine;

namespace Movement.Translate {
	public class PathMath {
		private const float DAMP = 1.8f;
		private const int SEARCH_RADIUS = -1;
		private const int STEPS_PER_SEGMENT = 10;

		private CinemachinePathBase _path;

		// THIS IS KINDA BAD.
		private float _closestPoint;
		private Vector3 _prevPos;

		public CinemachinePathBase Path {
			set {
				if (value == _path) return;
				_path = value;
				if (_path is null) {
					_closestPoint = 0;
				}
			}
		}

		public PathMath([CanBeNull] CinemachinePathBase path = null) {
			_path = path;
		}

		public float GetClosestPathPoint(Vector3 currentPos) {
			if (currentPos == _prevPos) {
				return _closestPoint;
			}
			_prevPos = currentPos;


			// TODO:
			// figure out a good search radius
			// find good steps per segment
			_closestPoint = _path.FindClosestPoint(
				currentPos,
				(int) _closestPoint, // TODO: check if this is correct
				SEARCH_RADIUS, STEPS_PER_SEGMENT);
			return _closestPoint;
		}

		// CAN PROBABLY OPTIMIZE? Does vector calculations each frame...
		public Vector3 GetTangent(Vector3 currentPos) {
			GetClosestPathPoint(currentPos);
			return _path.EvaluateTangent(_closestPoint);
		}

		public Vector3 GetForwardToPathPoint(Vector3 currentPos) {
			GetClosestPathPoint(currentPos);
			return _path.EvaluatePosition(_closestPoint) - currentPos;
		}
	}
}