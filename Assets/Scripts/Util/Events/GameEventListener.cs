using UnityEngine;
using UnityEngine.Events;

namespace Util.Events {
    public abstract class GameEventListener<T> : MonoBehaviour {
        [SerializeField] private GameEvent<T> gameEvent = default;
        [SerializeField] protected UnityEvent<T> response = default;

        public void OnEnable() {
            gameEvent.RegisterListener(this);
        }

        public void OnDisable() {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T val) {
            response.Invoke(val);
        }
    }
}