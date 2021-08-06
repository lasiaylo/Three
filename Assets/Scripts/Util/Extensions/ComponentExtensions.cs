using System;
using UnityEngine;
using Util.Managers;

namespace Util.Extensions {
	public static class ComponentExtensions {
		public static T GetOnlyComponent<T>(this Component component) where T : Component {
			return ComponentCacheManager.Instance.GetOnlyComponent<T>(component);
		}

		public static bool TryGetOnlyComponent<T>(this Component component, out T val) where T : Component {
			val = ComponentCacheManager.Instance.GetOnlyComponent<T>(component);
			return val;
		}

		public static bool HasTag(this Component component, Enum tagValue) {
			component.TryGetComponent(out Tags tags);
			if (tagValue == null) return true;
			return tags && tags.HasTag(tagValue);
		}
	}
}