using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractableSign : InteractableBase {

	public string m_text;

	public override void onInteract(Character character){

		if (DialogBox.isVisible()) {
			character.Movement.setIsFrozen(false, false);
			DialogBox.Hide ();
		} else {
			character.Movement.setIsFrozen(true, true);
			DialogBox.Show (m_text);
		}
	}

}
