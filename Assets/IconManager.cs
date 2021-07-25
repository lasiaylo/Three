using Interactions;
using UnityEngine;
using UnityEngine.UI;
using Util;
using Util.Patterns;

// Copied from YarnCharacterView. Gotta refactor
public class IconManager : Singleton<IconManager> {
	public Canvas canvas;
	public CanvasScaler canvasScaler;
	public RectTransform dialogueBubbleRect;
	public float bubbleMargin = 0.1f;
	private IconInteractBehaviour _iconAnchor;
	private Camera worldCamera;

	public void Start() {
		worldCamera = Camera.main;
	}

	// Update is called once per frame
	public void Update() {
		// if (dialogueBubbleRect.gameObject.activeInHierarchy) {
		// 	dialogueBubbleRect.anchoredPosition = UIUtils.WorldToAnchoredPosition(
		// 		worldCamera,
		// 		canvas,
		// 		canvasScaler,
		// 		dialogueBubbleRect,
		// 		_iconAnchor.positionWithOffset,
		// 		bubbleMargin
		// 	);
		// }
	}

	public void ShowIcon(IconInteractBehaviour iconAnchor) {
		_iconAnchor = iconAnchor;
	}
}