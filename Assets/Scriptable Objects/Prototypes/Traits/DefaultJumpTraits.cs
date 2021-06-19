using System;
using UnityEngine;
using Util.Scriptable_Objects.Prototypes.Variable._Types;

namespace Scriptable_Objects.Prototypes.Traits {
	[CreateAssetMenu(fileName = "DefaultJumpTraits", menuName = "Traits/Jump")]
	public class DefaultJumpTraits : DefaultVariable<JumpTraits> { }
	
	[Serializable]
	public struct JumpTraits {
		public float speed;
		public bool canJump;
	}
}