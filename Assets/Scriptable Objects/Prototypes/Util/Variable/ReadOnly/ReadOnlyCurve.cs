using UnityEngine;

namespace Util.Scriptable_Objects.Prototypes.Variable.ReadOnly {
	[CreateAssetMenu(fileName = "ReadOnlyCurve", menuName = "Variables/ReadOnly/Curve")]
	public class ReadOnlyCurve : ReadOnlyVariable<AnimationCurve> { }
}