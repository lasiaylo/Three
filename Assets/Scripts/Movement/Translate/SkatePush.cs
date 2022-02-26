using Movement.Translate;
using Scriptable_Objects.Prototypes.Util.Variable.Default;
using ScriptableObjects.Prototypes.Variable;
using UnityEngine;
using Util.Util_Classes;

public class SkatePush : MovementMod {
	[SerializeField] private DefaultBool push = default;
	[SerializeField] private DefaultQuaternion playerOrientation = default;
	[SerializeField] private float maxPushForce = 1;
	[SerializeField] private float pushTime = 1;
	[SerializeField] private AnimationCurve pushRamp = default;
	[SerializeField] private Timer timer;
	[ReadOnly][SerializeField] private float pushVelocity = 0;

	public void Awake() {
		timer = new Timer(
			pushTime,
			Push,
			null
		);
	}

	public override Vector3 Modify(Vector3 val) {
		if (push.Val) {
			// TODO: Set another timer for push
			if (!timer.IsRunning()) {
				timer.Reset();
				timer.Start();
			}
		}
		return val + (playerOrientation.Val * Vector3.right) * pushVelocity;
	}

	private void Push(float timeRemaining) {
		float time = (pushTime - timeRemaining) / pushTime;
		if (timeRemaining.IsZero()) {
			pushVelocity = 0;
		} else {
			pushVelocity = pushRamp.Evaluate(time) * maxPushForce;
		}
	}
}