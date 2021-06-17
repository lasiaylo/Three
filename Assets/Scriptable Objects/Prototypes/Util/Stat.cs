using ScriptableObjects.Prototypes;
using UnityEngine;
using Util.Util_Classes;

public enum FillStatus {
	Empty,
	Partway,
	Full,
}

// THIS IS GETTING REALLY BLOATED :(
// SHOULD REALLY REFACTOR
[CreateAssetMenu(fileName = "Stat", menuName = "Stat", order = 0)]
public class Stat : DefaultScriptableObject {
	public float _Stat;
	public Approacher Target;
	public bool ResetOnDeserialize = true;

	public override void Reset() {
		SetValue(_Stat);
	}

	public void SetStat(float val) {
		_Stat = val;
	}

	public float GetStat() {
		return _Stat;
	}

	public void SetValue(float val) {
		Target.SetInstantly(val);
	}

	public void SetValueOverTime(float target, float? tick = null, float? ticksPerSecond = null) {
		Target.Approach(target);
	}

	public float GetValue() {
		return Target.Val;
	}

	public void Add(float delta) {
		SetValue(GetValue() + delta);
	}

	public void AddOverTime(float delta, float? tick = null, float? ticksPerSecond = null) {
		SetValueOverTime(Target.GetTargetVal() + delta, tick, ticksPerSecond);
		//trigger add event
	}

	public void Minus(float delta) {
		SetValue(GetValue() - delta);
	}

	public void MinusOverTime(float delta, float? tick = null, float? ticksPerSecond = null) {
		SetValueOverTime(Target.GetTargetVal() - delta, tick, ticksPerSecond);
		// trigger minus event
	}

	public void ResetOverTime(float? tick = null, float? ticksPerSecond = null) {
		SetValueOverTime(_Stat, tick, ticksPerSecond);
	}

	public float GetFillRatio() {
		return GetValue() / GetStat();
	}

	// Can probably refactor to separate Fill class
	// And set up events
	public FillStatus GetStatus() {
		switch (GetFillRatio()) {
			case 0:
				return FillStatus.Empty;
			case 1:
				return FillStatus.Full;
			default:
				return FillStatus.Partway;
		}
	}

	public bool IsFull() {
		return GetStatus() == FillStatus.Full;
	}

	public bool IsEmpty() {
		return GetStatus() == FillStatus.Empty;
	}
}