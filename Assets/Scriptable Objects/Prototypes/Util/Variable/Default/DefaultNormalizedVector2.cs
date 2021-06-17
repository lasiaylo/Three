using UnityEngine;
using Util.Scriptable_Objects.Prototypes.Variable._Types;

namespace Util.Scriptable_Objects.Prototypes.Variable.Default {
	public class DefaultNormalizedVector2 : DefaultVariable<Vector2> {
		public override Vector2 Val {
			get => _Val;
			set => _Val = value.normalized;
		}
	}
}