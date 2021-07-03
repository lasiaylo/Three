using System;
using System.Data;
using JetBrains.Annotations;
using UnityEngine;

namespace Util.Util_Classes {
	/// <summary>
	///     Holds a value for a set amount of time
	/// </summary>
	[Serializable]
	public class Buffer<T> {
		// Will probably have to expand to a queue of actions
		[SerializeField] private Timer timer;
		private T Val;

		public Buffer() {
			timer = new Timer(0, Clear);
		}

		public T SetOrConsume(T val) {
			if (!IsCleared()) return Consume();
			Set(val);
			return default;
		}


		public void Set(T val) {
			timer.Reset();
			Val = val;
			timer.Start();
		}

		public void Clear() {
			Val = default;
		}
		
		public T Consume() {
			T val = Val;
			Clear();
			return val;
		}

		public bool IsCleared() {
			return Val is null;
		}
	}
}