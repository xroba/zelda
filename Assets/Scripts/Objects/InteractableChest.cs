using UnityEngine;
using System.Collections;

public class InteractableChest : InteractableBase {

	public Sprite openChestSprite;
	private bool m_isOpen = false;

	public override void onInteract(){

		if (m_isOpen == true) {
			return;
		}

		Debug.Log ("I m chest");
		GetComponentInChildren<SpriteRenderer> ().sprite = openChestSprite;
		m_isOpen = true;
	}
}
