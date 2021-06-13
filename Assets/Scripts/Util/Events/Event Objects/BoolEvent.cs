using UnityEngine;

namespace Util.Events.Event_Objects {
    [CreateAssetMenu(fileName = "BoolEvent", menuName = "Events/Bool", order = 0)]
    public class BoolEvent : GameEvent<bool> { }
}