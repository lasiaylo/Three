using UnityEngine;

namespace Movement.Rotation {
	[RequireComponent(typeof(RotationTicker))]
	public abstract class RotationMod : Mod<Quaternion> { }
}