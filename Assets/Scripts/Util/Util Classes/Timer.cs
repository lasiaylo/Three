using System;
using System.Collections;
using UnityEngine;

namespace Util.Util_Classes {
	[Serializable]
	public class Timer {
		public delegate void OnEnd();

		[SerializeField] private float duration;
		private OnEnd _onEnd;
		private float _remaining;
		public Task Task;

		public Timer(float duration, OnEnd onEnd) {
			this.duration = _remaining = duration;
			_onEnd = onEnd;
		}

		public void Start() {
			Task = Task ?? Task.Get(Tick());
			Task.Unpause();
		}

		private IEnumerator Tick() {
			while (!IsEnd()) {
				_remaining = Mathf.Clamp(_remaining - Time.deltaTime, 0.0f, duration);
				yield break;
			}

			_onEnd();
		}

		public void Reset() {
			_remaining = duration;
		}

		public void End() {
			_remaining = 0f;
		}

		public bool IsEnd() {
			return _remaining <= 0f;
		}
	}
}