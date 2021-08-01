using System;
using UnityEngine;
using Util.Extensions;

namespace Util.Utils {
	public static class RayCastUtil {
		private static RaycastHit[] _hits = new RaycastHit[1];

		public static bool CastCollider(Ray ray, out Collider collider, float distance = Mathf.Infinity,
			Color? debugColor = null) {
			if (debugColor.HasValue) Debug.DrawRay(ray.origin, ray.direction * distance, debugColor.Value);

			Physics.Raycast(ray, out RaycastHit hit, distance);
			collider = hit.collider;
			return collider;
		}

		public static bool CastColliderNonAlloc(Ray ray, out Collider collider, float distance = Mathf.Infinity,
			Color? debugColor = null) {
			if (debugColor.HasValue) Debug.DrawRay(ray.origin, ray.direction * distance, debugColor.Value);
			collider = null;
			Physics.RaycastNonAlloc(ray, _hits, distance);
			if (_hits.Length > 0) {
				collider = _hits[0].collider;
				return collider;
			}

			return false;
		}

		public static T CastNonAlloc<T>(Ray ray, float distance = Mathf.Infinity, Enum tag = null,
			Color? debugColor = null) where T : Component {
			if (CastColliderNonAlloc(ray, out Collider collider, distance, debugColor))
				if (collider.TryGetOnlyComponent(out Tags tags) && HasTag(tags, tag))
					return collider.GetOnlyComponent<T>();
			return default;
		}

		public static T Cast<T>(Ray ray, float distance = Mathf.Infinity, Enum tag = null, Color? debugColor = null)
			where T : Component {
			if (CastCollider(ray, out Collider collider, distance, debugColor))
				if (collider.TryGetOnlyComponent(out Tags tags) && HasTag(tags, tag))
					return collider.GetOnlyComponent<T>();

			return default;
		}

		public static T Cast<T>(Camera camera, float distance = Mathf.Infinity, Enum tag = null,
			Color? debugColor = null)
			where T : Component {
			var screenPos = new Vector2((camera.pixelWidth - 1) / 2, (camera.pixelHeight - 1) / 2);
			Ray ray = camera.ScreenPointToRay(screenPos);
			return Cast<T>(ray, distance, tag, debugColor);
		}

		private static bool HasTag(Tags tags, Enum tagValue) {
			if (tagValue == null) return true;
			return tags && tags.HasTag(tagValue);
		}
	}
}