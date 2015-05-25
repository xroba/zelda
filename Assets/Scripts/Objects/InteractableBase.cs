using UnityEngine;
using System.Collections;

public class InteractableBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void onInteract(){
		Debug.Log ("I interact");
	}
}
