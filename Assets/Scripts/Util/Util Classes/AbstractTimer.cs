using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Util.Util_Classes {
	[Serializable]
	public abstract class AbstractTimer {
		public delegate void OnEnd();

		public delegate void OnTick(float timeRemaining);

		[SerializeField] protected float duration;
		[ReadOnly] protected float remaining;
		protected OnEnd OnEndDel;
		protected OnTick OnTickDel;

		public float Remaining {
			get => remaining;
		}

		public abstract bool IsRunning();

		protected AbstractTimer(float duration, [CanBeNull] OnTick onTickDel, [CanBeNull] OnEnd onEndDel) {
			this.duration = remaining = duration;
			OnTickDel = onTickDel;
			OnEndDel = onEndDel;
		}

		private IEnumerator Tick() {
			while (!IsEnd()) {
				remaining = Mathf.Clamp(remaining - Time.deltaTime, 0.0f, duration);
				OnTickDel?.Invoke(remaining);
				yield return null;
			}

			End();
		}

		public void Reset() {
			remaining = duration;
		}

		public void End() {
			remaining = 0f;
			OnEndDel?.Invoke();
		}

		public bool IsEnd() {
			return remaining <= 0f;
		}

		protected void Tick(float deltaTime) {
			remaining = Mathf.Clamp(remaining - deltaTime, 0.0f, duration);
			OnTickDel?.Invoke(remaining);
		}
	}
}