using UnityEngine;

namespace Util.Events.Event_Objects {
    [CreateAssetMenu(fileName = "StringEvent", menuName = "Events/String", order = 0)]
    public class StringEvent : GameEvent<string> { }
}