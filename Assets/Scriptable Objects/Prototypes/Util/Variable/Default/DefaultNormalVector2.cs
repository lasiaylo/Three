using UnityEngine;
using Util.Scriptable_Objects.Prototypes.Variable._Types;

namespace Scriptable_Objects.Prototypes.Util.Variable.Default {
	[CreateAssetMenu(fileName = "Vector", menuName = "Variables/Default/Normalized Vector2")]
	public class DefaultNormalVector2 : DefaultVariable<Vector2> {
		public override Vector2 Val {
			get => _Val;
			set => _Val = value.normalized;
		}
	}
}