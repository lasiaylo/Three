using System;
using System.Collections.Generic;
using UnityEngine;
using Util.Patterns;

namespace Util.Managers {
	public class ComponentCacheManager : Singleton<ComponentCacheManager> {
		private readonly Dictionary<Tuple<string, Type>, Component> _cache =
			new Dictionary<Tuple<string, Type>, Component>();

		public T GetOnlyComponent<T>(Component component) where T : Component {
			Type type = typeof(T);
			Tuple<string, Type> objectTypePair = new Tuple<string, Type>(component.name, type);
			if (_cache.ContainsKey(objectTypePair)) {
				return (T) _cache[objectTypePair];
			}

			_cache.Add(objectTypePair, component.GetComponentInChildren<T>());
			return (T) _cache[objectTypePair];
		}
	}
}