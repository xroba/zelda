using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractableSign : InteractableBase {

	public string m_text;

	public override void onInteract(){

		if (DialogBox.isVisible()) {
			DialogBox.Hide ();
		} else {
			DialogBox.Show (m_text);
		}


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
