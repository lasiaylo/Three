using Interactions;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using Util;
using Util.Patterns;
using Util.Utils;

// Copied from YarnCharacterView. Gotta refactor
public class IconManager : Singleton<IconManager> {
	public Canvas canvas;
	public CanvasScaler canvasScaler;
	public Image image;
	public RectTransform dialogueBubbleRect;
	public float bubbleMargin = 0.1f;
	private IconFocusInteract _iconAnchor;
	private Camera worldCamera;
	private AsyncOperationHandle<Sprite> _handle;

	public void Start() {
		worldCamera = Camera.main;
		image.enabled = false;
	}

	// Update is called once per frame
	public void Update() {
		if (!(_iconAnchor is  null) && dialogueBubbleRect.gameObject.activeInHierarchy) {
			dialogueBubbleRect.anchoredPosition = UIUtils.WorldToAnchoredPosition(
				worldCamera,
				canvas,
				canvasScaler,
				dialogueBubbleRect,
				_iconAnchor.positionWithOffset,
				bubbleMargin
			);
		}
	}

	public void Show(IconFocusInteract iconAnchor) {
		_iconAnchor = iconAnchor;
		_handle = AD.Load<Sprite>(Path.ICON_ADDRESS, IconType.PLANT.ToString(), ShowIcon);
	}

	public void ShowIcon(Sprite sprite) {
		image.sprite = sprite;
		image.enabled = true;
	}

	public void HideIcon() {
		// Shrink animation
		image.sprite = null;
		image.enabled = false; 
		Addressables.Release(_handle); // Maybe keep around until scene ends?
		_handle = default;
	}
}