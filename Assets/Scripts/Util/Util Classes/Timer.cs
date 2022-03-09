using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Util.Util_Classes {
	[Serializable]
	public class Timer : AbstractTimer {
		public Task Task;

		public Timer(float duration, [CanBeNull] OnTick onTickDel, [CanBeNull] OnEnd onEndDel) : base(duration,
			onTickDel, onEndDel) { }

		public void Start() {
			Task = Task.Get(Tick());
			Task.Unpause();
		}

		private IEnumerator Tick() {
			while (!IsEnd()) {
				Tick(Time.deltaTime);
				yield return null;
			}

			End();
		}

		public override bool IsRunning() {
			return Task is { Running: true };
		}

		public new bool IsEnd() {
			return remaining <= 0f || Task is null;
		}
	}
}