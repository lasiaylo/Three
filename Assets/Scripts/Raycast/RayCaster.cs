using System;
using UnityEngine;
using Util.Utils;

public abstract class RayCaster<T> : MonoBehaviour where T : Component {
	public float distance = 1;
	public bool ShowDebug = false;
	private Ray _ray;

	protected abstract Vector3 Direction { get; set; }
	
	protected abstract Enum CastTag { get; }
	
	protected virtual Color? DebugColor {
		get => Color.green;
	}

	protected virtual Vector3 Offset {
		get => Vector3.zero;
	}

	public abstract void OnCast(T hit);

	public void Cast() {
		_ray = new Ray(transform.position + Offset, Direction);
		OnCast(RayCastUtil.CastNonAlloc<T>(_ray, CastTag, distance, ShowDebug ? DebugColor : null));
	}
}