using Interactions;
using UnityEngine;
using Util.Utils;

public class IconFocusInteract : InteractBehaviour {
	public IconType iconType;

	// COPYING CODE FROM YARNCHARACTER.cs
	// PLEASE PLEASE PLEASE REFACTOR
	// ESPECIALLY SINCE IT DOESN'T WORK FOR MORE THAN ONE ICON
	[Tooltip(
		"When positioning the message bubble in worldspace, YarnCharacterManager adds this additional offset to this gameObject's position. Taller characters should use taller offsets, etc.")]
	public Vector3 messageBubbleOffset = new Vector3(0f, 3f, 0f);

	public bool offsetUsesRotation = false;


	public Vector3 positionWithOffset {
		get {
			if (!offsetUsesRotation) {
				return transform.position + messageBubbleOffset;
			}

			return transform.position +
			       transform.TransformPoint(messageBubbleOffset);
		}
	}

	public override void Interact() {
		IconManager.Instance.HideIcon();
	}

	public override void Focus() {
		IconManager.Instance.Show(this);
	}

	public override void Unfocus() {
		IconManager.Instance.HideIcon();
	}
}