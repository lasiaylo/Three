using System;

namespace Util.Util_Classes
{
    [Serializable]
    public class Timer {
        public float duration;
        public float remaining;
        public float speed;

        public Timer(float duration) {
            this.duration = remaining = duration;
        }

        public void Tick(float deltaTime) {
            if (IsEnd()) return;
            remaining -= deltaTime * speed;
            CheckForTimerEnd();
        }

        public void Reset() {
            remaining = duration;
        }

        public void End() {
            remaining = 0f;
        }

        public bool IsEnd() {
            return remaining <= 0f;
        }

        private void CheckForTimerEnd() {
            if (remaining > 0f) return;
            remaining = 0f;
        }
    }
}