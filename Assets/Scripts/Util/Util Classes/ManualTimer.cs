using System;
using JetBrains.Annotations;

namespace Util.Util_Classes {
	[Serializable]
	public class ManualTimer : AbstractTimer {
		private bool _canStep;

		public ManualTimer(float duration, [CanBeNull] OnTick onTickDel, [CanBeNull] OnEnd onEndDel) : base(duration,
			onTickDel, onEndDel) { }

		public void Start() {
			_canStep = true;
		}

		public void Step(float deltaTime) {
			if (!_canStep) {
				return;
			}

			if (IsEnd()) {
				End();
				return;
			}

			Tick(deltaTime);
		}

		public new void End() {
			base.End();
			_canStep = false;
		}

		public override bool IsRunning() {
			return remaining != 0f && _canStep;
		}
	}
}