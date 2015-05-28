using UnityEngine;
using System.Collections;

public class CharacterBaseController : MonoBehaviour {

	CharacterMovementModel m_MovementModel;
	CharacterMovementView m_MovementView;
	CharacterInteractionModel m_InteractionModel;

	
	void Awake()
	{
		m_MovementModel = GetComponent<CharacterMovementModel> ();
		m_MovementView = GetComponent<CharacterMovementView> ();
		m_InteractionModel = GetComponent<CharacterInteractionModel> ();
	}

	protected void SetDirection( Vector2 direction)
	{
		if (m_MovementModel == null) 
		{
			return;
		}

		m_MovementModel.SetDirection (direction);
	}

	protected void onActionPressed(){

		if (m_InteractionModel == null) {
			return;
		}
		m_InteractionModel.onInterract ();

	}

	protected void onAttackPressed(){

		if (m_MovementModel == null) {
			return;
		}

		if (m_MovementModel.canAttack() == false) {
			return;
		}

		m_MovementModel.doAttack ();
		m_MovementView.doAttack ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
