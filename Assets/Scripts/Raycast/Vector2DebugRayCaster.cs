using JetBrains.Annotations;
using Scriptable_Objects.Prototypes.Util.Variable.Default;
using UnityEngine;

// TODO: Copies a lot of code from DebugRayCaster. Refactor
namespace Raycast {
    public class Vector2DebugRayCaster : MonoBehaviour {
        [NotNull] public DefaultNormalVector2 direction;
        public Vector3 offset;
        public float distance = 5;
        public Color debugColor = Color.green;
        private Ray _ray;

        private void OnDrawGizmos() {
            _ray = new Ray(
                transform.position 
                + offset, 
                direction.Val.GetNormalClockwise().ToXZPlane()
            );
            Gizmos.color = debugColor;
            Gizmos.DrawRay(_ray);
        }

        public void Update() {
            _ray = new Ray(
                transform.position 
                + offset, 
                direction.Val.GetNormalClockwise().ToXZPlane()
                );
            Debug.DrawRay(_ray.origin, _ray.direction * distance, debugColor);
        }
    }
}