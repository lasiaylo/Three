using System.Collections.Generic;
using UnityEngine;
using Util.Attributes;
using Util.Tickers;

namespace Util.Movement {
	/// <summary>
	///     Maintains a value that is modified through a list of Mods
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Modifier<T> : Ticker {
		[Expandable] public List<Mod<T>> mods = new();
		[SerializeField] protected T val;

		public override void Tick() {
			foreach (var mod in mods)
				if (mod.enabled)
					val = mod.Modify(val);
		}
	}
}