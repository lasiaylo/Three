using UnityEngine;

namespace Movement.Translate {
	[RequireComponent(typeof(MovementModifier))]
	public abstract class MovementMod : Mod<Vector3> { }
}