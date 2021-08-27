using Cinemachine;
using Movement.Translate;
using UnityEngine;

// Sourced from https://gist.github.com/Tattomoosa/9fef0b0811adb562e4ac9a35fcf2e4b0
// See https://forums.tigsource.com/index.php?topic=64819.0 for full discussion

// CONSIDER USING DOLLY CARTS INSTEAD!!!
public class PathFollow : MovementMod {
	private PathMath _math;
	private const float DAMP = 1.8f;

	public CinemachinePathBase Path {
		set {
			_math.Path = value;
			if (value is null) {
				enabled = false;
				return;
			}
			enabled = true;
		}
	}

	public void Awake() {
		_math = new PathMath();
	}
	
	public override Vector3 Modify(Vector3 val) {
		// val.x refers to left/right direction.
		// TODO - Use ground position instead of transform position;
		Vector3 position = transform.position;
		Vector3 pathTangent = _math.GetTangent(position);
		Vector3 courseCorrectDir = _math.GetForwardToPathPoint(position);
		courseCorrectDir.y = 0;
		Vector3 resultDir = Vector3.Lerp(
			pathTangent.normalized * val.x,
			courseCorrectDir.normalized * Mathf.Abs(val.x),
			Mathf.Clamp01(courseCorrectDir.magnitude / DAMP)
		);
		return new Vector3(resultDir.x, val.y, resultDir.z);
	}

}