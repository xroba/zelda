using UnityEngine;
using System.Collections;

public class CharacterInteractionModel : MonoBehaviour {

	CharacterMovementModel m_MovementModel;
	InteractableBase usableInteractable;


	void Awake(){
		m_MovementModel = GetComponent<CharacterMovementModel> ();
	}
	

	public void onInterract(){

		usableInteractable = FindUsableInteract ();

		if (usableInteractable == null) {
			return;
		}

		usableInteractable.onInteract ();

	}

	protected InteractableBase FindUsableInteract(){

		Collider2D[] closeColliders;
		float angleToInteract;
		float myAngle = Mathf.Infinity;
		InteractableBase myInteractable = null;;

		closeColliders = Physics2D.OverlapCircleAll (transform.position, 1f);

		for (int i=0; i < closeColliders.Length; i++) {

			InteractableBase colliderInteractable = closeColliders[i].gameObject.GetComponent<InteractableBase>();
			if( colliderInteractable == null)
			{
				continue;
			}

			Vector3 directionToInteractable = closeColliders[i].transform.position - transform.position;
			Vector3 facingDirection = m_MovementModel.getFacingDirection();

			angleToInteract = Vector3.Angle(directionToInteractable, facingDirection);

			if(angleToInteract < 40){

				if(angleToInteract < myAngle){

					myAngle = angleToInteract;
					myInteractable = colliderInteractable;
				}
				Debug.Log(myInteractable.gameObject.name + " : " + myAngle);
			}


		}
 	
		return myInteractable;
	}
}
