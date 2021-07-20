using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Util;

//Made using this guide:
////https://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/

namespace Editor {
	[CustomEditor(typeof(Tags))]
	[CanEditMultipleObjects]
	public class TagsEditor : UnityEditor.Editor {
		private ReorderableList list;

		private void OnEnable() {
			list = new ReorderableList(serializedObject, serializedObject.FindProperty("tags"), false, true, true,
				true);
			list.drawElementCallback =
				(rect, index, isActive, isFocused) => {
					SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
					rect.y += 2;
					//TODO: Reformat  
					//TODO: Figure out how to have enum popup menu. Probably can't be done.
					EditorGUI.LabelField(
						new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight),
						element.FindPropertyRelative("tagType").stringValue);
					EditorGUI.LabelField(
						new Rect(rect.x + 92, rect.y, rect.width - 120, EditorGUIUtility.singleLineHeight),
						element.FindPropertyRelative("value").stringValue);
					EditorGUI.PropertyField(
						new Rect(rect.x + 200, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight),
						element.FindPropertyRelative("enabled"), GUIContent.none);
				};
			list.onAddDropdownCallback = (rect, reorderableList) => {
				var menu = new GenericMenu();

				foreach (var tagType in TagType.Types)
				foreach (string tagVal in Enum.GetNames(tagType.Value))
					menu.AddItem(
						new GUIContent(tagType.Key + "/" + tagVal),
						false,
						ClickHandler,
						new Tag {
							parentTag = tagType.Key, name = tagVal, enabled = true,
						});

				menu.ShowAsContext();
			};

			list.drawHeaderCallback = rect => { EditorGUI.LabelField(rect, "Tags"); };

			// TODO: AutoSort list
		}

		// Update is called once per frame
		public override void OnInspectorGUI() {
			serializedObject.Update();
			list.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}

		private void ClickHandler(object obj) {
			var tag = (Tag) obj;
			int index = list.serializedProperty.arraySize;
			list.serializedProperty.arraySize++;
			list.index = index;
			SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
			element.FindPropertyRelative("tagType").stringValue = tag.parentTag;
			element.FindPropertyRelative("value").stringValue = tag.name;
			element.FindPropertyRelative("enabled").boolValue = true;
			serializedObject.ApplyModifiedProperties();
		}
	}
}