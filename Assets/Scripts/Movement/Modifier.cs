using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Util.Attributes;

namespace Movement {
	/// <summary>
	///     Maintains a value that is modified through a list of Mods
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class Modifier<T> : MonoBehaviour {
		[Expandable] public List<Mod<T>> mods;
		[Expandable] public List<Mod<T>> postMods;
		[SerializeField] protected T val;
		[SerializeField] protected T postVal; 
		protected abstract Type ComponentType { get; }

		public virtual void Update() {
			if (!enabled) return;
			foreach (Mod<T> mod in mods)
				if (mod.enabled)
					val = mod.Modify(val);
			
			postVal = val;
			foreach (Mod<T> fx in postMods) {
				if (fx.enabled)
					postVal = fx.Modify(postVal);
			}
		}

		public void Reset() {
			mods = GetComponents(ComponentType).Cast<Mod<T>>().ToList();
		}
	}
}