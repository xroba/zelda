﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractableSign : InteractableBase {

	public string m_text;

	public override void onInteract(Character character){

		if (DialogBox.isVisible()) {
			Time.timeScale = 1;
			character.Movement.setIsFrozen(false);
			DialogBox.Hide ();
		} else {



			character.Movement.setIsFrozen(true);
			StartCoroutine(FreezeTimeRoutine()) ;

			DialogBox.Show (m_text);
		}
	}

	IEnumerator FreezeTimeRoutine(){
		yield return null;
		Time.timeScale = 0;
	}
}
