using Traits;
using UnityEngine;

namespace Scriptable_Objects.Prototypes.Traits {
	[CreateAssetMenu(fileName = "JumpTraits", menuName = "Traits/Jump")]
	public class ReadOnlyJumpTraits : ReadOnlyVariable<JumpTraits> { }
}