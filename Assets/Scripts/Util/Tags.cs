using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Util.Extensions;

namespace Util {
	public class Tags : MonoBehaviour, ISerializationCallbackReceiver {
		[SerializeField] private List<Tag> tags = default;
		private Dictionary<Type, Dictionary<string, bool>> _tagToSubtagDict;

		public void OnAfterDeserialize() {
			_tagToSubtagDict ??= new Dictionary<Type, Dictionary<string, bool>>();
			_tagToSubtagDict.Clear();
			foreach (Tag t in tags) {
				Type type = TagType.GetType(t.parentTag);
				if (type == null) continue;
				if (!_tagToSubtagDict.ContainsKey(type)) _tagToSubtagDict.Add(type, new Dictionary<string, bool>());
				_tagToSubtagDict[type][t.name] = t.enabled;
			}
		}

		public void OnBeforeSerialize() { }

		public IEnumerable<string> GetAllStringTags() {
			List<string> tagStrings = new List<string>();
			foreach (Tag t in tags) {
				if (t.enabled) {
					tagStrings.Add(t.name);
				}
			}

			return tagStrings;
		}

		public IEnumerable<T> GetTags<T>() where T : Enum {
			Type tagType = typeof(T);
			if (_tagToSubtagDict.TryGetValue(tagType, out Dictionary<string, bool> subTags)) {
				List<T> tagList = new List<T>();
				foreach (string subTag in subTags.Keys) {
					if (subTags[subTag]) {
						tagList.Add((T) Enum.Parse(tagType, subTag));
					}
				}

				return tagList;
			}

			Debug.LogErrorFormat("Tags of type {0} not found", tagType);
			return Enumerable.Empty<T>();
		}

		public bool HasTag(Enum tagValue) {
			Type tagType = tagValue.GetType();
			if (_tagToSubtagDict.TryGetValue(tagType, out Dictionary<string, bool> values))
				if (values.TryGetValue(tagValue.GetName(), out bool enable))
					return enable;
			return false;
		}
	}

	[Serializable]
	public struct Tag {
		public string parentTag;
		public string name;
		public bool enabled;
	}

	// Add to this whenever you create a new tag type.
	public static class TagType {
		public static readonly Dictionary<string, Type> Types = new Dictionary<string, Type>() {
			{Key<General>(), Val<General>()},
			{Key<FloorMaterial>(), Val<FloorMaterial>()},
		};

		[CanBeNull]
		public static Type GetType(string typeName) {
			if (Types.TryGetValue(typeName, out Type type)) return type;
			Debug.LogErrorFormat("Tag type {0} not defined", typeName);
			return null;
		}

		private static string Key<T>() {
			return typeof(T).Name;
		}

		private static Type Val<T>() {
			return typeof(T);
		}
	}

	public enum General {
		INTERACTABLE,
		HAS_PATH,
	}

	public enum FloorMaterial {
		WOOD,
		CARPET,
	}
}