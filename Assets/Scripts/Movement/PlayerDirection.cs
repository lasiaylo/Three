using Scriptable_Objects.Prototypes.Util.Variable.Default;
using Traits;
using UnityEngine;

namespace Movement {
	public class PlayerDirection : MonoBehaviour {
		[SerializeField] private DefaultNormalVector2 input;
		private DirectionTrait _directionTrait;

		public void Awake() {
			_directionTrait = GetComponentInChildren<DirectionTrait>();
		}

		// To optimize, trigger on event. 
		public void Update() {
			if (input.Val.x < 0) {
				_directionTrait.val = Direction.LEFT;
			} else if (input.Val.x > 0) {
				_directionTrait.val = Direction.RIGHT;
			}
		}
	}
}