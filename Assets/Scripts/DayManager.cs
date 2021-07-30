using UnityEngine;
using UnityEngine.Events;
using Util.Patterns;

public enum TimeOfDay {
	AM,
	PM,
}

public class DayManager : Singleton<DayManager> {
	public UnityEvent<string> onDayStart;
	public UnityEvent<string> onDayEnd;
	[SerializeField] private int day;
	[SerializeField] private TimeOfDay timeOfDay = TimeOfDay.AM;
	private string _dayString;

	private int Day {
		get => day;
		set {
			day = value;
			_dayString = value + timeOfDay.ToString();
		}
	}

	public DayManager(string dayString) {
		_dayString = dayString;
	}

	public void StartDay() {
		onDayStart.Invoke(_dayString);
	}


	public void EndDay() {
		onDayEnd.Invoke(_dayString);
		Day += 1;
	}
}