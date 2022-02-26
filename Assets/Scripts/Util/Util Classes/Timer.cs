using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Util.Util_Classes {
	[Serializable]
	public class Timer {
		public delegate void OnEnd();

		public delegate void OnTick(float timeRemaining);

		[SerializeField] private float duration;
		[ReadOnly] private float _remaining;
		public Task Task;
		private OnEnd _onEnd;
		private OnTick _onTick;

		public float Remaining {
			get => _remaining;
		}

		public Timer(float duration, [CanBeNull] OnTick onTick, [CanBeNull] OnEnd onEnd) {
			this.duration = _remaining = duration;
			_onTick = onTick;
			_onEnd = onEnd;
		}

		public void Start() {
			Task = Task.Get(Tick());
			Task.Unpause();
		}

		private IEnumerator Tick() {
			while (!IsEnd()) {
				_remaining = Mathf.Clamp(_remaining - Time.deltaTime, 0.0f, duration);
				_onTick?.Invoke(_remaining);
				yield return null;
			}

			End();
		}

		public void Reset() {
			_remaining = duration;
		}

		public void End() {
			_remaining = 0f;
			_onEnd?.Invoke();
		}

		public bool IsRunning() {
			return Task is { Running: true };
		}

		public bool IsEnd() {
			return _remaining <= 0f || Task is null;
		}
	}
}