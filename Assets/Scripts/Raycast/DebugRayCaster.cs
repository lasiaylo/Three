using System;
using JetBrains.Annotations;
using UnityEngine;
using Util.Scriptable_Objects.Prototypes.Variable.Default;

// TODO: Copies a lot of code from RayCaster<T>. Refactor
namespace Raycast {
    public class DebugRayCaster : MonoBehaviour {
        [NotNull] public DefaultNormalVector3 direction;
        public Vector3 offset;
        public float distance = 5;
        public Color debugColor = Color.green;
        private Ray _ray;

        private void OnDrawGizmos() {
            _ray = new Ray(
                transform.position 
                + offset, 
                direction.Val
            );
            Gizmos.color = debugColor;
            Gizmos.DrawRay(_ray);
        }

        public void Update() {
            _ray = new Ray(
                transform.position 
                + offset, 
                direction.Val
                );
            Debug.DrawRay(_ray.origin, _ray.direction * distance, debugColor);
        }
    }
}