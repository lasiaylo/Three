using BansheeGz.BGSpline.Curve;
using Cinemachine;
using Movement.Translate;
using UnityEngine;

// Sourced from https://gist.github.com/Tattomoosa/9fef0b0811adb562e4ac9a35fcf2e4b0
// See https://forums.tigsource.com/index.php?topic=64819.0 for full discussion
public class PathFollow : MovementMod {
	private BGCurve curve;
	private CinemachinePathBase path;
	private BGCurveBaseMath _math;
	private const float DAMP = 1.8f;

	public BGCurve Curve {
		set {
			if (value == curve) return;
			curve = value;
			if (curve is null) {
				_math = null;
				enabled = false;
				return;
			}

			enabled = true;
			_math = new BGCurveBaseMath(curve, new BGCurveBaseMath.Config(BGCurveBaseMath.Fields.PositionAndTangent));
		}
	}

	public void Awake() {
		if (curve is null) {
			enabled = false;
			return;
		}

		_math = new BGCurveBaseMath(curve, new BGCurveBaseMath.Config(BGCurveBaseMath.Fields.PositionAndTangent));
	}

	public Vector3 Mod(Vector3 val) {
		
	}



	public override Vector3 Modify(Vector3 val) {
		// val.x refers to left/right input.
		// TODO - Use ground position instead of transform position;
		Vector3 position = transform.position;
		Vector3 pathDir = CalculateForwardFromClosestPoint(position, out Vector3 curvePoint) * val.x;
		Vector3 courseCorrectDir = curvePoint - position;
		courseCorrectDir.y = 0;
		Vector3 resultDir = Vector3.Lerp(
			pathDir,
			courseCorrectDir.normalized * Mathf.Abs(val.x),
			Mathf.Clamp01(courseCorrectDir.magnitude / DAMP)
		);
		return new Vector3(resultDir.x, val.y, resultDir.z);
	}
	
	private Vector3 CalculateForwardFromClostestPoint(Vector3 currentPos) {
		float closestPoint = path.FindClosestPoint(currentPos, 0, -1, 10);
		// need to keep track of start segment
		// figure out a good search radius
		// find good steps pers egment
		Vector3 targetPos = path.EvaluatePosition(closestPoint);
		
	}

	private Vector3 CalculateForwardFromClosestPoint(Vector3 currentPos, out Vector3 curvePoint) {

		
		Vector3 forward = CalculateTangentFromClosestPoint(currentPos, out curvePoint);
		forward.y = 0;
		return forward.normalized;
	}

	private Vector3 CalculateTangentFromClosestPoint(Vector3 currentPos, out Vector3 curvePoint) {
		curvePoint = _math.CalcPositionByClosestPoint(currentPos, out float curvePointDistance);
		return _math.CalcTangentByDistance(curvePointDistance);
	}
}