using UnityEngine;

namespace Util.Events.Event_Objects {
	[CreateAssetMenu(fileName = "IntEvent", menuName = "Events/Int", order = 0)]
	public class IntEvent : GameEvent<int> { }
}