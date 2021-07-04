using System;

namespace Traits {
	public class JumpTrait : Trait<JumpTraits> { }

	[Serializable]
	public struct JumpTraits {
		public float speed;
		public bool canJump;
	}
}