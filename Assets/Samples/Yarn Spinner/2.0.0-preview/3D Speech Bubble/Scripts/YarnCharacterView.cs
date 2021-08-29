using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;
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

		public void Update() {
			// this all in Update instead of RunLine because characters might walk around or move during the dialogue
			if (dialogueBubbleRect.gameObject.activeInHierarchy) {
				if (speakerCharacter != null) {
					dialogueBubbleRect.anchoredPosition = UIUtils.WorldToAnchoredPosition( worldCamera, canvas, canvasScaler, dialogueBubbleRect,
						speakerCharacter.positionWithOffset, bubbleMargin);
				}
				// else {  
				// 	// if no speaker defined, then display speech above playerCharacter as a default
				// 	dialogueBubbleRect.anchoredPosition = WorldToAnchoredPosition(dialogueBubbleRect,
				// 		playerCharacter.positionWithOffset, bubbleMargin);
				// }
			}
			if ( optionsBubbleRect.gameObject.activeInHierarchy ) {
				optionsBubbleRect.anchoredPosition = UIUtils.WorldToAnchoredPosition( worldCamera, canvas, canvasScaler,  optionsBubbleRect, playerCharacter.positionWithOffset, bubbleMargin );
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