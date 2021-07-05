using System;
using System.Collections.Generic;
using UnityEngine;
using Util.Patterns;

namespace Util.Managers {
	public class ComponentCacheManager : Singleton<ComponentCacheManager> {
		private readonly Dictionary<Component, Dictionary<Type, dynamic>> _cache =
			new Dictionary<Component, Dictionary<Type, dynamic>>();

		public T GetOnlyComponent<T>(Component component) {
			Type type = typeof(T);
			if (_cache.ContainsKey(component)) {
				if (_cache[component].ContainsKey(type)) return (T) _cache[component][type];

				_cache[component].Add(type, component.GetComponentInChildren<T>());
				return _cache[component][type];
			}

			Dictionary<Type, dynamic> componentCache = new Dictionary<Type, dynamic>
				{{type, component.GetComponentInChildren<T>()}};
			_cache.Add(component, componentCache);
			return _cache[component][type];
		}
	}
}