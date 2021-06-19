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
	public abstract class Modifier<T> : MonoBehaviour,  ISerializationCallbackReceiver {
		[Expandable] public List<Mod<T>> mods;
		[SerializeField] protected T val;
		protected abstract Type ComponentType { get; }
		
		public virtual void Update() {
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