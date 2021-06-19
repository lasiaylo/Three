using System;
using UnityEngine;
using Util.Scriptable_Objects.Prototypes.Variable._Types;

namespace Scriptable_Objects.Prototypes.Traits {
	[CreateAssetMenu(fileName = "DefaultMovementTraits", menuName = "Traits/Movement")]
	public class DefaultMovementTraits : DefaultVariable<MovementTraits> { }
	
	[Serializable]
	public struct MovementTraits {
		public float acceleration;
		public float deceleration;
		public float maxSpeed;
	}
}