using TMPro;
using UnityEngine;
using Util.Utils;

public class Speech : MonoBehaviour, ISerializationCallbackReceiver {
	public Name characterName;
	private TextMeshProUGUI _textMesh;

	public void OnLineUpdate(string line) {
		AdjustBubble(line);
		_textMesh.text = line;
	}

	public void OnEnd() {
		_textMesh.text = "";
		CloseBubble();
	}

	private void AdjustBubble(string line) {
		Debug.Log("adjust bubb");
	}

	private void CloseBubble() {
		Debug.Log("close bubbs");
	}

	public void OnBeforeSerialize() {
		_textMesh = GetComponentInChildren<TextMeshProUGUI>();
	}

	public void OnAfterDeserialize() { }
}