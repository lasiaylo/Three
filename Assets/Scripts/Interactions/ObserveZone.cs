using Traits;
using UnityEngine;
using UnityEngine.Events;
using Util.Extensions;

namespace Interactions {
	[RequireComponent(typeof(Collider))]
	public class ObserveZone : MonoBehaviour {
		public UnityEvent<bool> observeEvent;
		private Camera _camera;
		private bool _isObserved;
		private Vector3 prevPos;
		private Direction _prevDirection;

		private bool IsObserved {
			get => _isObserved;
			set {
				if (value == _isObserved) return;
				_isObserved = value;
				observeEvent.Invoke(IsObserved);
			}
		}

		public void Awake() {
			_camera = Camera.main;
			IsObserved = false;
			observeEvent.Invoke(IsObserved);
		}

		public void OnTriggerEnter(Collider other) {
			if (!other.CompareTag("Player")) return;
			IsObserved = IsObservedBy(other);
		}

		public void OnTriggerStay(Collider other) {
			OnTriggerEnter(other);
		}

		public void OnTriggerExit(Collider other) {
			IsObserved = false;
		}

		private bool IsObservedBy(Component viewer) {
			DirectionTrait direction = viewer.GetOnlyComponent<DirectionTrait>();
			Vector3 viewerPos = viewer.transform.position;
			if (viewerPos == prevPos && direction.val == _prevDirection) return IsObserved;
			Vector3 myPos = transform.position;
			prevPos = viewerPos;
			_prevDirection = direction.val;
			
			return direction.val switch {
				Direction.RIGHT => _camera.WorldToScreenPoint(viewerPos).x <
				                   _camera.WorldToScreenPoint(myPos).x,
				Direction.LEFT => _camera.WorldToScreenPoint(viewerPos).x >
				                  _camera.WorldToScreenPoint(myPos).x,
				_ => false,
			};
		}
	}
}