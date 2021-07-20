using System;
using UnityEngine;
using UnityEngine.Events;
using Util.Patterns;

public enum TimeOfDay {
	AM, 
	PM,  
}

public class DayManager : Singleton<DayManager>, ISerializationCallbackReceiver {
	public UnityEvent<string> onDayChange;
	[SerializeField] private int day;
	[SerializeField] private TimeOfDay timeOfDay;

	public void StartDay() {
		LoadYarnProject(); // Change yarn project to next day.
		onDayChange.Invoke(GetDay());
	}

	public void EndDay() { }

	public string GetDay() {
		return String.Format("{0}{1}", day, timeOfDay.ToString());
	} 

	private void LoadYarnProject() {
		// Change Yarn Project to next day.
		// Figure out how to update variables when necessaary
	}
	
	private void LoadYarnScripts() { }

	public void OnBeforeSerialize() { }

	public void OnAfterDeserialize() { }
}