using Movement.Translate;
using Scriptable_Objects.Prototypes.Util.Variable.Default;
using ScriptableObjects.Prototypes.Variable;
using UnityEngine;
using Util.Util_Classes;

public class SkatePush : MovementMod {
	[SerializeField] private DefaultBool pushInput = default;
	[SerializeField] private DefaultQuaternion playerOrientation = default;
	[SerializeField] private float maxPushForce = 1;
	[SerializeField] private float maxSpeed = 2;
	[SerializeField] private float pushTime = 1;
	[SerializeField] private AnimationCurve pushRamp = default;
	[SerializeField] private ManualTimer timer;
	[ReadOnly] [SerializeField] private float pushVelocity = 0;

	public void Awake() {
		timer = new ManualTimer(
			pushTime,
			Push,
			null
		);
	}

	public override Vector3 Modify(Vector3 val) {
		if (val.magnitude > maxSpeed) {
			return val;
		}

		if (pushInput.Val) {
			// TODO: Set another timer for push
			if (!timer.IsRunning()) {
				timer.Start();
				timer.Reset();
			}
		}

		timer.Step(Time.deltaTime);

		return val + GetPushVector();
	}

	private Vector3 GetPushVector() {
		return (playerOrientation.Val * Vector3.right) * pushVelocity;
	}

	private void Push(float timeRemaining) {
		float time = (pushTime - timeRemaining) / pushTime;
		if (timeRemaining.IsZero()) {
			pushVelocity = 0;
		} else {
			pushVelocity = pushRamp.Evaluate(time) * maxPushForce * Time.deltaTime / pushTime * 2;
		}
	}
}