using UnityEngine;

namespace Movement.Rotation {
	[RequireComponent(typeof(RotationModifier))]
	public abstract class RotationMod : Mod<Quaternion> { }
}