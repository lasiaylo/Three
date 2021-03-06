using System.Collections.Generic;

namespace TexDrawLib {
	//Main Class Stack Manager
	public static class ListPool<T> {
		// Object pool to avoid allocations.
		private static readonly ObjectPool<List<T>> Pool = new ObjectPool<List<T>>();

		public static List<T> Get() {
			return Pool.Get();
		}

		public static void Release(List<T> toRelease) {
			if (toRelease.Count > 0 && toRelease[0] is IFlushable)
				for (var i = 0; i < toRelease.Count; i++) {
					var obj = (IFlushable) toRelease[i];
					obj.Flush();
				}

			toRelease.Clear();
			Pool.Release(toRelease);
		}

		//Advanced purposes only
		public static void ReleaseNoFlush(List<T> toRelease) {
			toRelease.Clear();
			Pool.Release(toRelease);
		}
	}

	internal static class ObjPool<T> where T : class, IFlushable, new() {
		// Object pool to avoid allocations.
		private static readonly ObjectPool<T> Pool = new ObjectPool<T>();

		public static T Get() {
			T obj = Pool.Get();
			obj.SetFlushed(false);
			return obj;
		}

		public static void Release(T toRelease) {
			if (toRelease.GetFlushed())
				return;
			toRelease.SetFlushed(true);
			Pool.Release(toRelease);
		}
	}

	//Interface to get a class to be flushable (flush means to be released to the main class stack
	//when it's unused, later if code need a new instance, the main stack will give this class back
	//instead of creating a new instance (which later introducing Memory Garbages)).
	internal interface IFlushable {
		bool GetFlushed();

		void SetFlushed(bool flushed);

		void Flush();
	}
}