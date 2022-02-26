using System;
using Scriptable_Objects.Prototypes.Util.Variable.Default;
using UnityEngine;
using Util.Extensions;
using Util.Scriptable_Objects.Prototypes.Variable.Default;

namespace Movement.Translate {
	
	//TODO: Define curve for veer
	public class SkateVeer : MovementMod {
		// Vector pointing in direction wheels are moving
		[SerializeField] private DefaultNormalVector2 input;
		[SerializeField] private DefaultQuaternion playerOrientation;
		[SerializeField] private DefaultNormalVector3 wheelDirection;
		[SerializeField] private float veerStrength;
		private Vector3 _wheelDirection;

		// TODO: Account for turning in air. 

		public override Vector3 Modify(Vector3 val) {
			_wheelDirection = GetWheelDirection();
			wheelDirection.Val = _wheelDirection;
			Vector3 wheelTurnVal = GetWheelNormalForce(val);
			return wheelTurnVal;
		}

		private Vector3 GetWheelDirection() {
			float inputDir = input.Val.GetNormalClockwise().normalized.y * veerStrength;
			return (
				playerOrientation.Val * (Vector3.right + inputDir.ToVector3Z())
			).normalized;
		}

		// Interpreting static friction of wheels as a normal force
		private Vector3 GetWheelNormalForce(Vector3 val) {
			Vector2 valXZ = val.GetXZ();
			float angle = 90 - Vector2.Angle(valXZ, _wheelDirection.GetXZ());
			return (_wheelDirection * valXZ.magnitude * (float)Math.Sin(angle * Mathf.Deg2Rad));
		}
	}
}