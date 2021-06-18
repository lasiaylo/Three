using System;

namespace FSM.Movement {
	[Serializable]
	public struct JumpTraits {
		public float speed;
		public bool canJump;
	}

	public interface IHasJumpTraits {
		JumpTraits JumpTraits { get; }
	}
}