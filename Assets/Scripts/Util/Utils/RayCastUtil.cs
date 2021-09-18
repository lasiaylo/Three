using System;
using UnityEngine;
using Util.Extensions;

namespace Util.Utils {
	public static class RayCastUtil {
		private static RaycastHit[] _hits = new RaycastHit[1];
		
		# region Cast Collider

		public static bool CastCollider(
			Ray ray,
			out Collider collider,
			float distance = Mathf.Infinity,
			Color? debugColor = null
		) {
			if (debugColor.HasValue) Debug.DrawRay(ray.origin, ray.direction * distance, debugColor.Value);

			Physics.Raycast(ray, out RaycastHit hit, distance);
			collider = hit.collider;
			return collider;
		}

		public static bool CastColliderNonAlloc(
			Ray ray,
			out Collider collider,
			float distance = Mathf.Infinity,
			Color? debugColor = null
		) {
			if (debugColor.HasValue) Debug.DrawRay(ray.origin, ray.direction * distance, debugColor.Value);
			collider = null;
			Physics.RaycastNonAlloc(ray, _hits, distance);
			if (_hits.Length > 0) {
				collider = _hits[0].collider;
				return collider;
			}

			return false;
		}
		
		#endregion

		#region Cast Non Alloc Directions

		public static T CastNonAlloc<T>(
			Ray ray,
			Enum tag = null,
			float distance = Mathf.Infinity,
			Color? debugColor = null
		) where T : Component {
			if (CastColliderNonAlloc(ray, out Collider collider, distance, debugColor))
				if (collider.TryGetOnlyComponent(out Tags tags) && HasTag(tags, tag))
					return collider.GetOnlyComponent<T>();
			Debug.Log("WHY IS IT GETTING HERE");
			return default;
		}

		public static T CastDownNonAlloc<T>(
			Vector3 pos, 
			Enum tag = null,
			float distance = Mathf.Infinity, 
			Color? debugColor = null
		) where T: Component {
			return CastNonAlloc<T>(pos,Vector3.down, tag, distance, debugColor);
		}
		
		public static T CastForwardNonAlloc<T>(
			Vector3 pos, 
			Enum tag = null,
			float distance = Mathf.Infinity, 
			Color? debugColor = null
		) where T: Component {
			return CastNonAlloc<T>(pos,Vector3.forward, tag, distance, debugColor);
		}
		
		private static T CastNonAlloc<T>(
			Vector3 pos, 
			Vector3 dir,
			Enum tag = null,
			float distance = Mathf.Infinity, 
			Color? debugColor = null
		) where T: Component {
			Ray ray = new Ray(pos, dir);
			return CastNonAlloc<T>(ray, tag, distance, debugColor);
		}

		#endregion

		#region Cast Collider (CONSIDER USING NON ALLOC INSTEAD)
		public static T Cast<T>(
			Ray ray,
			Enum tag = null,
			float distance = Mathf.Infinity,
			Color? debugColor = null
		) where T : Component {
			if (CastCollider(ray, out Collider collider, distance, debugColor))
				if (collider.TryGetOnlyComponent(out Tags tags) && HasTag(tags, tag))
					return collider.GetOnlyComponent<T>();

			return default;
		}

		public static T Cast<T>(
			Camera camera, Enum tag = null,
			float distance = Mathf.Infinity,
			Color? debugColor = null
		)
			where T : Component {
			var screenPos = new Vector2((camera.pixelWidth - 1) / 2, (camera.pixelHeight - 1) / 2);
			Ray ray = camera.ScreenPointToRay(screenPos);
			return Cast<T>(ray, tag, distance, debugColor);
		}
		
		#endregion

		private static bool HasTag(Tags tags, Enum tagValue) {
			if (tagValue == null) return true;
			return tags && tags.HasTag(tagValue);
		}
	}
}