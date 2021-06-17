using System;
using System.Reflection;

namespace Util {
	public class TypeUtil {
		// Taken from:
		// shttps://forum.unity.com/threads/system-type-gettype-transform-not-work.40081/
		public static Type GetType(string typeName) {
			// Try Type.GetType() first. This will work with types defined
			// by the Mono runtime, etc.
			var type = Type.GetType(typeName);

			// If it worked, then we're done here
			if (type != null)
				return type;

			// Get the name of the assembly (Assumption is that we are using
			// fully-qualified type names)
			string assemblyName = typeName.Substring(0, typeName.IndexOf('.'));

			// Attempt to load the indicated Assembly
			Assembly assembly = Assembly.Load(assemblyName);
			if (assembly == null)
				return null;

			// Ask that assembly to return the proper Type
			return assembly.GetType(typeName);
		}
	}
}