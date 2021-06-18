using UnityEngine;
using Util.Scriptable_Objects.Prototypes.Variable._Types;

namespace Util.Scriptable_Objects.Prototypes.Variable.Default {
	[CreateAssetMenu(fileName = "Vector", menuName = "Variables/Default/Normalized Vector3")]
	public class DefaultNormalVector3 : DefaultVariable<Vector3> {
		public override Vector3 Val {
			get => _Val;
			set => _Val = value.normalized;
		}
	}
}