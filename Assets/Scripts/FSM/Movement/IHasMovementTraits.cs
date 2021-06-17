using System;

namespace FSM.Movement {
	[Serializable]
	public struct MovementTraits {
		public float acceleration;
		public float deceleration;
		public float maxSpeed;
	}

	public interface IHasMovementTraits {
		MovementTraits MovementTraits { get; }
	}
}