using UnityEngine;

namespace Util.Events.Event_Objects {
	[CreateAssetMenu(fileName = "GameObjectEvent", menuName = "Events/GameObject", order = 0)]
	public class GameObjectEvent : GameEvent<GameObject> { }
}