using System;
using UnityEngine;
using Util.Utils;

public abstract class RayCaster<T> : MonoBehaviour where T : Component {
	public float distance = 1;
	protected Color? color = null;
	protected Enum CastTag = null;
	private Ray _ray;

	public abstract Vector3 Direction { get; set; }

	public abstract void OnCast(T hit);

	public void Start() {
		_ray = new Ray(transform.position, Direction);
	}

	public void Cast() {
		OnCast(RayCastUtil.CastNonAlloc<T>(_ray, CastTag, distance, color));
	}
}