using BansheeGz.BGSpline.Curve;
using Cinemachine;
using Movement.Translate;
using UnityEngine;

// Sourced from https://gist.github.com/Tattomoosa/9fef0b0811adb562e4ac9a35fcf2e4b0
// See https://forums.tigsource.com/index.php?topic=64819.0 for full discussion


// CONSIDER USING DOLLY CARTS INSTEAD!!!
public class PathFollow : MovementMod {
	private CinemachinePathBase _path;
	private const float DAMP = 1.8f;

	public CinemachinePathBase Path {
		set {
			if (value == _path) return;
			_path = value;
			if (_path is null) {
				enabled = false;
				return;
			}

			enabled = true;
		}
	}

	public void Awake() {
		if (_path is null) {
			enabled = false;
		}
	}
	

	public override Vector3 Modify(Vector3 val) {
		// val.x refers to left/right direction.
		// TODO - Use ground position instead of transform position;
		Vector3 position = transform.position;
		float pathPoint = GetClosestPathPoint(position);
		Vector3 pathTangent = _path.EvaluateTangent(pathPoint);
		Vector3 courseCorrectDir = GetForwardToPathPoint(position, pathPoint);
		courseCorrectDir.y = 0;
		Vector3 resultDir = Vector3.Lerp(
			pathTangent.normalized * val.x,
			courseCorrectDir.normalized * Mathf.Abs(val.x),
			Mathf.Clamp01(courseCorrectDir.magnitude / DAMP)
		);
		return new Vector3(resultDir.x, val.y, resultDir.z);
	}

	private float GetClosestPathPoint(Vector3 currentPos) {
		// TODOS:
		// need to keep track of start segment
		// figure out a good search radius
		// find good steps pers egment
		return _path.FindClosestPoint(currentPos, 0, -1, 10);
	}

	private Vector3 GetForwardToPathPoint(Vector3 currentPos, float pathPoint) {
		return _path.EvaluatePosition(pathPoint) - currentPos;
	}
}