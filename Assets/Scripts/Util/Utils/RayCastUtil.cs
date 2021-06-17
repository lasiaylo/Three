using System;
using UnityEngine;
using Util.Extensions;

namespace Util.Utils {
	public static class RayCastUtil {
		public static bool RayCastCollider(Ray ray, float distance, Color? debugColor, out Collider collider) {
			if (debugColor.HasValue) Debug.DrawRay(ray.origin, ray.direction * distance, debugColor.Value);

			Physics.Raycast(ray, out RaycastHit hit, distance);
			collider = hit.collider;
			return collider;
		}

		public static T RayCast<T>(Ray ray, float distance, Enum tag = null, Color? debugColor = null)
			where T : Component {
			if (RayCastCollider(ray, distance, debugColor, out Collider collider))
				if (collider.TryGetOnlyComponent(out Tags tags) && HasTag(tags, tag))
					return collider.GetOnlyComponent<T>();

			return default;
		}

		public static T RayCast<T>(Camera camera, float distance, Enum tag = null, Color? debugColor = null)
			where T : Component {
			var screenPos = new Vector2((camera.pixelWidth - 1) / 2, (camera.pixelHeight - 1) / 2);
			Ray ray = camera.ScreenPointToRay(screenPos);
			return RayCast<T>(ray, distance, tag, debugColor);
		}

		private static bool HasTag(Tags tags, Enum tagValue) {
			if (tagValue == null) return true;
			return tags && tags.HasTag(tagValue);
		}
	}
}