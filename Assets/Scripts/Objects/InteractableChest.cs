using UnityEngine;
using System.Collections;

public class InteractableChest : InteractableBase {

	public Sprite openChestSprite;
	private bool m_isOpen = false;
	private SpriteRenderer m_renderer;

	void Awake(){
		m_renderer = GetComponentInChildren<SpriteRenderer> ();
	}

	public override void onInteract(Character character){

		if (m_isOpen == true) {
			return;
		}

		m_renderer.sprite = openChestSprite;
		m_isOpen = true;
	}
}
