using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Util.Patterns;
using Util.Utils;
using Yarn.Unity;

// Manages changing Yarn projects and updating variables for each accordingly.
public class YarnManager : Singleton<YarnManager> {
	private const string YARN_ADDRESS = "Yarn/";
	private DialogueRunner _runner;
	private AsyncOperationHandle<YarnProject> _prevProjectHandle;
	private string _day;

	public void Start() {
		_runner ??= GetComponent<DialogueRunner>();
	}

	public void SetYarnProjectForDay(string day) {
		_day = day;
		UnloadPrevYarnAsset();
		AD.Load<YarnProject>(Path.YARN_ADDRESS, _day, SetYarnProject);
	}

	public void StartDialogue(string characterName) {
		if (_runner.IsDialogueRunning) return;	
		_runner.StartDialogue(_day + characterName);
	}

	private void UnloadPrevYarnAsset() {
		Addressables.Release(_prevProjectHandle);
		_prevProjectHandle = default;
	}

	private void SetYarnProject([CanBeNull] YarnProject day) {
		if (day is null) {
			Debug.LogError("Loading Yarn Project returned null");
		}
		else {
			// do stuff with variables
			_runner.SetProject(day);
		}
	}
}