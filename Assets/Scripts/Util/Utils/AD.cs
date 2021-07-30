using System;
using System.Collections.Generic;
using Garden.Factors;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Yarn.Unity;

namespace Util.Utils {
	public enum Path {
		YARN_ADDRESS,
		PLANT_ADDRESS,
		ICON_ADDRESS,
	}

	public enum IconType {
		PLANT,
	}

	public static class AD {
		private static readonly Dictionary<Path, string> Paths = new Dictionary<Path, string>() {
			{Path.YARN_ADDRESS, "Yarn/"},
			{Path.PLANT_ADDRESS, "Plant/"},
			{Path.ICON_ADDRESS, "Icon/"},
		};

		public static void Instantiate(Path path, string file, Transform parent,
			Action<GameObject> del) {
			AsyncOperationHandle<GameObject> handle =
				Addressables.InstantiateAsync(Paths[path] + file, parent);
			handle.Completed += h => del(h.Result);
		}

		public static AsyncOperationHandle<T> Load<T>(Path path, string file, Action<T> del) {
			AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(Paths[path] + file);
			handle.Completed += h => del(h.Result);
			return handle;
		}
	}
}