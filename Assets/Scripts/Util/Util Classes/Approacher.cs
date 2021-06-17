using System;
using System.Collections;
using UnityEngine;

// A float variable that constantly moves towards target value
namespace Util.Util_Classes {
	[Serializable]
	public class Approacher {
		public delegate void OnSuccess(float t);

		public delegate void OnTick(float t);

		public float Val;
		[SerializeField] private float TargetVal;
		public float Tick;
		public float TicksPerSecond;

		private float _max;
		private float _min;
		private float _tick;
		public Task Task;

		// TODO: Add delegate or something to run function when ticking;
		public Approacher(float val, float tick, float ticksPerSecond) {
			Val = val;
			Tick = tick;
			TicksPerSecond = ticksPerSecond;
		}

		public void SetInstantly(float val) {
			Val = val;
			TargetVal = val;
		}

		public void Approach(float val, OnTick onTick = null, OnSuccess onSuccess = null) {
			Task = Task ?? Task.Get(MoveTowards(onTick, onSuccess));
			Task.Unpause();
			TargetVal = val;
			_min = TargetVal < Val ? TargetVal : Val;
			_max = TargetVal < Val ? Val : TargetVal;
			_tick = TargetVal < Val ? -Tick : Tick;
		}

		public void Pause() {
			Task.Pause();
		}

		public float GetTargetVal() {
			return TargetVal;
		}

		// TODO: Figure out custom ramp functions i.e. Linear, Exp, Square
		private IEnumerator MoveTowards(OnTick onTick, OnSuccess onSuccess) {
			while (true) {
				Val = Mathf.Clamp(Val + _tick, _min, _max);
				onTick?.Invoke(Val);
				yield return new WaitForSeconds(1 / TicksPerSecond);
			}
			// onSuccess?.Invoke(Val);
		}
	}
}