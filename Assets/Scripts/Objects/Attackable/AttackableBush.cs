using UnityEngine;
using System.Collections;

public class AttackableBush : AttackableBase {

	public GameObject DestroyedEffect;
	public Sprite DestroyedSprite;
	private SpriteRenderer m_Renderer;

	void Awake(){
		m_Renderer = GetComponentInChildren<SpriteRenderer> ();
	}

	public override void onHit (ItemType itemType)
	{
		m_Renderer.sprite = DestroyedSprite;

		if (GetComponent<Collider2D> () != null) {
			GetComponent<Collider2D>().enabled = false;
		}

		if (DestroyedEffect != null) {
			GameObject destroyedEffect = (GameObject) Instantiate(DestroyedEffect);
			destroyedEffect.transform.position = transform.position;
		}
	}
}
