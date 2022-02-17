using Traits;
using UnityEngine;

namespace Scriptable_Objects.Prototypes.Traits {
	[CreateAssetMenu(fileName = "MovementTraits", menuName = "Traits/Movement")]
	public class ReadOnlyMovementTraits : ReadOnlyVariable<MovementTraits> { }
}