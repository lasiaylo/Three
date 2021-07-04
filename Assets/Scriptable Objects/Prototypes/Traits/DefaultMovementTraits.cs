using System;
using Traits;
using UnityEngine;
using Util.Scriptable_Objects.Prototypes.Variable._Types;

namespace Scriptable_Objects.Prototypes.Traits {
	[CreateAssetMenu(fileName = "DefaultMovementTraits", menuName = "Traits/Movement")]
	public class DefaultMovementTraits : DefaultVariable<MovementTraits> { }
}