namespace Util.Extensions {
	public static class BoolExtensions {
		public static int ToInt(this bool val) {
			return val ? 1 : 0;
		}
	}
}