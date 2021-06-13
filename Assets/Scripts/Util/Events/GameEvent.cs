using System.Collections.Generic;
using UnityEngine;

namespace Util.Events {
    public abstract class GameEvent<T> : ScriptableObject {
        public List<GameEventListener<T>> listeners = new List<GameEventListener<T>>();

        public void Raise(T val) {
            for (int i = listeners.Count - 1; i >= 0; i--) {
                listeners[i].OnEventRaised(val);
            }
        }

        public void RegisterListener(GameEventListener<T> listener) {
            listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener<T> listener) {
            listeners.Remove(listener);
        }
    }
}