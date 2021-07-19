using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Util.Utils;
using Yarn;

public class SpeechBubbleManager : MonoBehaviour {
	private Dictionary<Name, Speech> _speechDict;

	public void Awake() {
		_speechDict = FindObjectsOfType<Speech>().ToDictionary(speech => speech.characterName);
	}

	public void OnLineUpdate(string line) {
		IEnumerable<Name> names = YarnUtils.GetNames(line);
		foreach (Name n in _speechDict.Keys) {
			if (names.Contains(n)) {
				_speechDict[n].OnLineUpdate(line);
			}
			else {
				// May need to have an option to keep dialogue open
				_speechDict[n].OnEnd();
			}
		}
	}
}