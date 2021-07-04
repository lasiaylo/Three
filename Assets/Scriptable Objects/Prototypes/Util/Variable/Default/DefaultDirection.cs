using UnityEngine;
using Util.Scriptable_Objects.Prototypes.Variable._Types;

namespace Scriptable_Objects.Prototypes.Util.Variable.Default {
	public enum Direction {
		UP,
		DOWN,
		LEFT,
		RIGHT,
	}

	[CreateAssetMenu(fileName = "DefaultDirection", menuName = "Variables/Default/Direction")]
	public class DefaultDirection : DefaultVariable<Direction> { }
}