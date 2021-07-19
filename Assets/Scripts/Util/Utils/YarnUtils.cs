using System;
using System.Collections.Generic;
using System.Linq;

namespace Util.Utils {
	public enum Name {
		PLAYER,
		RILEY,
	}

	public static class YarnUtils {
		// Probably useless now
		public static IEnumerable<Name> GetNames(string line) {
			int index = line.IndexOf(":", StringComparison.Ordinal);
			if (index <= 0) return new List<Name>() {Name.PLAYER};
			IEnumerable<string> nameStrings = line.Split(',').ToList();
			HashSet<Name> names = new HashSet<Name>();
			foreach (string nameString in nameStrings) {
				Enum.TryParse(nameString, out Name name);
				names.Add(name);
			}

			return names;
		}

		public static void StartDialogue(string startNode) {
			
		}
	}
}