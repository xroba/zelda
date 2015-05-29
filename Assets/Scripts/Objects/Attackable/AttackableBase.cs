using UnityEngine;
using System.Collections;

public class AttackableBase : MonoBehaviour {
	
	public virtual void onHit(ItemType itemType){
		Debug.Log ("Non onHit Method for " + gameObject.name);
	}
}
