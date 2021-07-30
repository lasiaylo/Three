using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util.Utils;

namespace Yarn.Unity.Example {
	/// <summary>Manager singleton that repositions DialogueUI window in 3D worldspace, based on whoever is speaking. Put this script on the same gameObject as your DialogueUI.</summary>
	public class
		YarnCharacterView : DialogueViewBase // inherit from DialogueViewBase to receive data directly from DialogueRunner
	{
		public static YarnCharacterView
			instance; // very minimal implementation of singleton manager (initialized lazily in Awake)

		public Dictionary<Name, YarnCharacter> allCharacters = new Dictionary<Name, YarnCharacter>();

		Camera
			worldCamera; // this script assumes you are using a full-screen Unity UI canvas along with a full-screen game camera


		[Tooltip("display dialogue choices for this character, and display any no-name dialogue here too")]
		public YarnCharacter playerCharacter;

		public YarnCharacter speakerCharacter;

		public Canvas canvas;
		public CanvasScaler canvasScaler;
		
		

		[Tooltip(
			"for best results, set the rectTransform anchors to middle-center, and make sure the rectTransform's pivot Y is set to 0")]
		public RectTransform dialogueBubbleRect, optionsBubbleRect;

		[Tooltip(
			"margin is 0-1.0 (0.1 means 10% of screen space)... -1 lets dialogue bubbles appear offscreen or get cutoff")]
		public float bubbleMargin = 0.1f;

		// Awake is called before the first frame update AND before Start...
		public void Awake() {
			// ... this is important because we must set the static "instance" here, before any YarnCharacter.Start() can use it
			instance = this;
			worldCamera = Camera.main;
		}

		/// <summary>automatically called by YarnCharacter.Start() so that YarnCharacterView knows they exist</summary>
		public void RegisterYarnCharacter(YarnCharacter newCharacter) {
			if (!instance.allCharacters.ContainsKey(newCharacter.characterName)) {
				allCharacters.Add(newCharacter.characterName, newCharacter);
			}
		}

		/// <summary>automatically called by YarnCharacter.OnDestroy() to clean-up</summary>
		public void ForgetYarnCharacter(YarnCharacter deletedCharacter) {
			if (instance.allCharacters.ContainsKey(deletedCharacter.characterName)) {
				allCharacters.Remove(deletedCharacter.characterName);
			}
		}

		public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished) {
			bool hasCharacterName = dialogueLine.Text.TryGetAttributeWithName("character", out var characterAttribute);

			if (hasCharacterName) {
				string characterName = characterAttribute.Properties["name"].StringValue;
				Enum.TryParse(characterName, out Name nameEnum);
				speakerCharacter = FindCharacter(nameEnum);
			}
			else {
				speakerCharacter =
					FindCharacter(default(Name)); // if null, Update() will use the playerCharacter instead
			}

			// IMPORTANT: we must mark this view as having finished its work, or else the DialogueRunner gets stuck forever
			onDialogueLineFinished();
		}

		/// <summary>simple search through allCharacters list for a matching name, returns null and LogWarning if no match found</summary>
		private YarnCharacter FindCharacter(Name searchName) {
			if (allCharacters.ContainsKey(searchName)) {
				return allCharacters[searchName];
			}

			Debug.LogWarningFormat("YarnCharacterView couldn't find a YarnCharacter named {0}!", searchName);
			return null;
		}

		/// <summary>Calculates where to put dialogue bubble based on worldPosition and any desired screen margins. 
		/// Ensure "constrainToViewportMargin" is between 0.0f-1.0f (% of screen) to constrain to screen, or value of -1 lets bubble go off-screen.</summary>
		private Vector2 WorldToAnchoredPosition(RectTransform bubble, Vector3 worldPos,
			float constrainToViewportMargin = -1f) {
			Vector2 screenPos = Vector2.zero;

			Camera canvasCamera = worldCamera;
			if (canvas.renderMode == RenderMode.ScreenSpaceOverlay) {
				// Canvas "Overlay" mode is special case for ScreenPointToLocalPointInRectangle (see the Unity docs)
				canvasCamera = null;
			}

			RectTransformUtility.ScreenPointToLocalPointInRectangle(
				bubble.parent
					.GetComponent<RectTransform>(), // calculate local point inside parent... NOT inside the dialogue bubble itself
				worldCamera.WorldToScreenPoint(worldPos),
				canvasCamera,
				out screenPos
			);

			// to force the dialogue bubble to be fully on screen, clamp the bubble rectangle within the screen bounds
			if (constrainToViewportMargin >= 0f) {
				// because ScreenPointToLocalPointInRectangle is relative to a Unity UI RectTransform,
				// it may not necessarily match the full screen resolution (i.e. CanvasScaler)

				// it's not really in world space or screen space, it's in a RectTransform "UI space"
				// so we must manually convert our desired screen bounds to this UI space

				bool useCanvasResolution = canvasScaler != null &&
				                           canvasScaler.uiScaleMode != CanvasScaler.ScaleMode.ConstantPixelSize;
				Vector2 screenSize = Vector2.zero;
				screenSize.x = useCanvasResolution ? canvasScaler.referenceResolution.x : Screen.width;
				screenSize.y = useCanvasResolution ? canvasScaler.referenceResolution.y : Screen.height;

				// calculate "half" values because we are measuring margins based on the center, like a radius
				var halfBubbleWidth = bubble.rect.width / 2;
				var halfBubbleHeight = bubble.rect.height / 2;

				// to calculate margin in UI-space pixels, use a % of the smaller screen dimension
				var margin = screenSize.x < screenSize.y
					? screenSize.x * constrainToViewportMargin
					: screenSize.y * constrainToViewportMargin;

				// finally, clamp the screenPos fully within the screen bounds, while accounting for the bubble's rectTransform anchors
				screenPos.x = Mathf.Clamp(
					screenPos.x,
					margin + halfBubbleWidth - bubble.anchorMin.x * screenSize.x,
					-(margin + halfBubbleWidth) - bubble.anchorMax.x * screenSize.x + screenSize.x
				);
				screenPos.y = Mathf.Clamp(
					screenPos.y,
					margin + halfBubbleHeight - bubble.anchorMin.y * screenSize.y,
					-(margin + halfBubbleHeight) - bubble.anchorMax.y * screenSize.y + screenSize.y
				);
			}

			return screenPos;
		}

		public void Update() {
			// this all in Update instead of RunLine because characters might walk around or move during the dialogue
			if (dialogueBubbleRect.gameObject.activeInHierarchy) {
				if (speakerCharacter != null) {
					dialogueBubbleRect.anchoredPosition = WorldToAnchoredPosition(dialogueBubbleRect,
						speakerCharacter.positionWithOffset, bubbleMargin);
				}
				// else {  
				// 	// if no speaker defined, then display speech above playerCharacter as a default
				// 	dialogueBubbleRect.anchoredPosition = WorldToAnchoredPosition(dialogueBubbleRect,
				// 		playerCharacter.positionWithOffset, bubbleMargin);
				// }
			}
			if ( optionsBubbleRect.gameObject.activeInHierarchy ) {
				optionsBubbleRect.anchoredPosition = WorldToAnchoredPosition( optionsBubbleRect, playerCharacter.positionWithOffset, bubbleMargin );
			}
		}


		// these overrides are required when we inherit from DialogueViewBase
		// but if your custom dialogue view doesn't need them, it's ok to leave them empty and unused like this
		public override void DismissLine(Action onDismissalComplete) {
			onDismissalComplete();
		}

		public override void OnLineStatusChanged(LocalizedLine dialogueLine) {
			// for YarnCharacterView, we don't care about this, so do nothing
		}

		public override void RunOptions(DialogueOption[] dialogueOptions, Action<int> onOptionSelected) {
			// for YarnCharacterView, we don't care about this, so do nothing
		}
	}
}