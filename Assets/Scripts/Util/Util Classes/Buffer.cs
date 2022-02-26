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
		private T _val;

		public Buffer() {
			timer = new Timer(1, null, Clear);
		}

		public T SetOrConsume(T val) {
			if (!IsCleared()) return Consume();
			Set(val);
			return default;
		}


		public void Set(T val) {
			timer.Reset();
			_val = val;
			timer.Start();
		}

		public void Clear() {
			_val = default;
		}
		
		public T Consume() {
			T val = _val;
			Clear();
			return val;
		}

		public bool IsCleared() {
			return _val is null;
		}
	}
}