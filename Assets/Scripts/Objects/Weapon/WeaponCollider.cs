using UnityEngine;
using System.Collections;

public class WeaponCollider : MonoBehaviour {
	public ItemType type;

	void OnTriggerEnter2D(Collider2D other) {

		AttackableBase attackable = other.gameObject.GetComponent<AttackableBase> ();

		if(attackable == null){
			return;
		}
		other.gameObject.GetComponent<AttackableBase> ().onHit (type);
	}
}
