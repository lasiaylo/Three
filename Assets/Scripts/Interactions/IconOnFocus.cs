using UnityEngine;
using Util.Utils;

namespace Interactions {
	public abstract class IconInteract : InteractBehaviour {
		public GameObject Icon;
		public RectTransform iconBubbleRect; 
		
		public override void Focus() {
			AD.Instantiate(Path.ICON_ADDRESS, IconType.PLANT.ToString(), transform, SetIcon);
		}
		
		public override void Unfocus() { }

		public void SetIcon(GameObject obj) {
			Icon = obj;
		}
	}
}