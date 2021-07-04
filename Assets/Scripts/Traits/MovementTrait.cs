using System;

namespace Traits {
	public class MovementTrait: Trait<MovementTraits> { }
	
	[Serializable]
	public struct MovementTraits {
		public float acceleration;
		public float deceleration;
		public float maxSpeed;
	}
}