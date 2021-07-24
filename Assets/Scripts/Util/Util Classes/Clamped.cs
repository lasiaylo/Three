using System;

namespace Util.Util_Classes {
	public class Clamped<T> where T : IComparable {
		private T _val;
		public T Min, Max;

		protected Clamped(T val, T min, T max) {
			_val = val;
			Min = min;
			Max = max;
		}

		public T Val {
			get => _val;
			set {
				if (value.CompareTo(Max) > 1) {
					_val = Max;
					return;
				}

				if (value.CompareTo(Min) < 1) {
					_val = Min;
					return;
				}

				_val = value;
			}
		}

		public static implicit operator T(Clamped<T> self) {
			return self._val;
		}

		public static implicit operator Clamped<T>(T value) {
			return new Clamped<T>(value, default, default);
		}
	}
}