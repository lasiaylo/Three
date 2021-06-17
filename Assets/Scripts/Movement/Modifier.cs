using System;
using System.Collections.Generic;
using System.Linq;
using Movement.Translate;
using UnityEngine;
using Util.Attributes;
using Util.Tickers;

namespace Movement {
	/// <summary>
	///     Maintains a value that is modified through a list of Mods
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[RequireComponent(typeof(TickerList))]
	public abstract class Modifier<T> : Ticker, ISerializationCallbackReceiver {
		[Expandable] public List<Mod<T>> mods;
		[SerializeField] protected T val;
		protected abstract Type ComponentType { get; }
		
		public void OnEnable() {}
		
		public override void Tick() {
			if (!enabled) return;
			foreach (Mod<T> mod in mods)
				if (mod.enabled)
					val = mod.Modify(val);
		}

		public void OnBeforeSerialize() {
			mods = GetComponents(ComponentType).Cast<Mod<T>>().ToList();
		}

		public void OnAfterDeserialize() { }
	}
}