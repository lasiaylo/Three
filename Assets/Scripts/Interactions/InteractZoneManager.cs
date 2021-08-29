using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interactions {
	public class InteractZoneManager : MonoBehaviour {
		public float interactDirection;
		public float fov = 90;
		[SerializeField] private Camera mainCamera;
		[SerializeField] private List<InteractBehaviour> interactBehaviours;
		private HashSet<InteractBehaviour> _interactBehavioursSet;
		private HashSet<InteractZone> _zoneSet;

		public void Awake() {
			_zoneSet = new HashSet<InteractZone>(GetComponentsInChildren<InteractZone>());
			if (interactBehaviours is null || interactBehaviours.Count == 0) {
				Debug.LogError("No InteractBehaviours found on this game object. Try resetting this component or adding behaviours");
			}
			else {
				_interactBehavioursSet = new HashSet<InteractBehaviour>(interactBehaviours);
			}
			
			mainCamera = Camera.main;
			TransformEvent transformEvent = mainCamera != null ? mainCamera.GetComponentInChildren<TransformEvent>() : null;
			if (transformEvent != null) {
				transformEvent.transformEvent.AddListener(OnCameraRotate);
			}
			OnCameraRotate();
		}

		public void OnZoneTriggered(Component interactor) {
				InteractionManager.Instance.Targets = _interactBehavioursSet;
				InteractionManager.Instance.Interactor = interactor;
		}

		public void OnZoneUntriggered() {
			if (_zoneSet.Any(zone => zone.isTriggered)) {
				InteractionManager.Instance.Targets = _interactBehavioursSet;
				return;
			}

			InteractionManager.Instance.Targets = null;
			
		}

		// ReSharper disable once MemberCanBePrivate.Global - Used in events
		public void OnCameraRotate() {
			bool cameraIsInFront = GetCameraIsInFront();
			
			foreach (InteractZone zone in _zoneSet) {
				zone.enabled = cameraIsInFront;
			}
		}

		private bool GetCameraIsInFront() {
			Vector3 vecToCamera = mainCamera.transform.position - transform.parent.position;
			vecToCamera.y = 0;
			return Vector3.Angle(GetInteractDirection() * Vector3.forward , vecToCamera) <= fov / 2;
		}

		private Quaternion GetInteractDirection() {
			return Quaternion.AngleAxis(interactDirection, Vector3.up);
		}

		public void Reset() {
			interactBehaviours = new List<InteractBehaviour>(GetComponents<InteractBehaviour>());
		}		
		
		public void OnDrawGizmosSelected() {
			Gizmos.color = Color.cyan;
			Vector3 position = transform.parent.position;
			Gizmos.matrix = Matrix4x4.TRS( position, GetInteractDirection(), Vector3.one );
			Gizmos.DrawFrustum(Vector3.zero, fov, 10, 0, 1);
			Gizmos.matrix = Matrix4x4.TRS( position, Quaternion.identity,Vector3.one );
			Gizmos.DrawRay(Vector3.zero, mainCamera.transform.position);
		}
	}
}