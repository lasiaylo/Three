using System;
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
			IsObserved = IsBeingObservedBy(other);
		}

		public void OnTriggerStay(Collider other) {
			OnTriggerEnter(other);
		}

		public void OnTriggerExit(Collider other) {
			IsObserved = false;
		}

		private bool IsBeingObservedBy(Component viewer) {
			DirectionTrait direction = viewer.GetOnlyComponent<DirectionTrait>();
			Vector3 viewerPosition = viewer.transform.position;
			Vector3 myPosition = transform.position;
			return direction.val switch {
				Direction.RIGHT => _camera.WorldToScreenPoint(viewerPosition).x <
				                   _camera.WorldToScreenPoint(myPosition).x,
				Direction.LEFT => _camera.WorldToScreenPoint(viewerPosition).x >
				                  _camera.WorldToScreenPoint(myPosition).x,
				_ => false,
			};
		}
	}
}