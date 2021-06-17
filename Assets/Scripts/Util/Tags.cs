using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Util.Extensions;

namespace Util {
	public class Tags : MonoBehaviour, ISerializationCallbackReceiver {
		[SerializeField] private List<Tag> tags = default;
		private Dictionary<Type, Dictionary<string, bool>> _tagDict;

		public void OnAfterDeserialize() {
			_tagDict = new Dictionary<Type, Dictionary<string, bool>>();
			foreach (Tag t in tags) {
				Type type = TagType.GetType(t.tagType);
				if (type == null) continue;
				if (!_tagDict.ContainsKey(type)) _tagDict.Add(type, new Dictionary<string, bool>());
				_tagDict[type][t.value] = t.enabled;
			}
		}

		public void OnBeforeSerialize() { }

		public IEnumerable<string> GetAllStringTags() {
			return tags
				.Where(t => t.enabled)
				.Select(t => t.value);
		}

		public IEnumerable<T> GetTags<T>() where T : Enum {
			Type tagType = typeof(T);
			if (_tagDict.TryGetValue(tagType, out var values))
				return values
					.Where(val => val.Value)
					.Select(val => (T) Enum.Parse(tagType, val.Key));
			Debug.LogErrorFormat("Tags of type {0} not found", tagType);
			return Enumerable.Empty<T>();
		}

		public bool HasTag(Enum tagValue) {
			Type tagType = tagValue.GetType();
			if (_tagDict.TryGetValue(tagType, out var values))
				if (values.TryGetValue(tagValue.GetName(), out bool enable))
					return enable;
			return false;
		}
	}

	[Serializable]
	public struct Tag {
		public string tagType;
		public string value;
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
	}

	public enum FloorMaterial {
		WOOD,
		CARPET,
	}
}