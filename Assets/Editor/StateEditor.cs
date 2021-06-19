using System.Reflection;
using UnityEditor;
using Util.Finite_State_Machine;

namespace Editor {
	[CustomEditor(typeof(State), true)]
	public class StateEditor : UnityEditor.Editor {
		public bool showEvents;
		public bool showStateInfo;


		public override void OnInspectorGUI() {
			string[] propertiesInBaseClass = new string[]
				{"onEnter", "onTick", "onExit", "parentState", "currentSubstate", "substateList"};
			showEvents = EditorGUILayout.Foldout(showEvents, "Events");
			showStateInfo = EditorGUILayout.Foldout(showStateInfo, "State Info");
			
			if (showEvents) {
				EditorGUILayout.PropertyField(serializedObject.FindProperty("onEnter"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("onTick"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("onExit"));
			}

			if (showStateInfo) {
				EditorGUILayout.PropertyField(serializedObject.FindProperty("parentState"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("currentSubstate"));
				EditorGUILayout.PropertyField(serializedObject.FindProperty("substateList"));
			}
			
			DrawPropertiesExcluding(serializedObject, propertiesInBaseClass);
			serializedObject.ApplyModifiedProperties();
		}
	}
}