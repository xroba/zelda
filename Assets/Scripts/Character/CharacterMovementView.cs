using UnityEngine;
using System.Collections;

public class CharacterMovementView : MonoBehaviour {

	public Animator animator;
	CharacterMovementModel m_characterMovementModel;
	public Transform weaponParent;

	void Awake() {
		m_characterMovementModel = GetComponent<CharacterMovementModel> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateDirection ();
		CheckIfAttack ();
	}

	public void UpdateDirection(){ //updateMovement animation in fact

		if (m_characterMovementModel == null) {
			return;
		}
		
		Vector3 direction = m_characterMovementModel.getDirection ();
		
		if (direction != Vector3.zero) {
			animator.SetFloat ("directionX", direction.x);
			animator.SetFloat ("directionY", direction.y);
		}
		
		animator.SetBool ("isMoving", m_characterMovementModel.IsMoving());
	}

	//call from the modelMouvement
	public void doAttack(){
		animator.SetTrigger ("doAttack");
	}

	void CheckIfAttack(){
		if (m_characterMovementModel.m_IsAttacking) {
			setWeaponActive(true);
		} else {
			setWeaponActive(false);
		}
	}

	void setWeaponActive(bool doActive){
		for (int i=0; i < weaponParent.childCount; i++) {
			Debug.Log (weaponParent.GetChild(i).gameObject.name + "--" + doActive);
			weaponParent.GetChild(i).gameObject.SetActive(doActive);
		}

	}
	
}
