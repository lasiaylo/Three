using System;
using UnityEngine;

namespace Util.Util_Classes {
	/// <summary>
	///     Holds a value for a set amount of time
	/// </summary>
	[Serializable]
	public class Buffer<T> {
		// Will probably have to expand to a queue of actions
		[SerializeField] private Timer timer;

		public Buffer() {
			timer = new Timer(0, Clear);
		}

		public T Value { get; private set; }

		public void Set(T val) {
			timer.Reset();
			Value = val;
			timer.Start();
		}

		public void Clear() {
			Value = default;
		}

		public void OnMove() {
			
		}
	}
}