using UnityEngine;
using System.Collections;

public class CharacterMovementView : MonoBehaviour {

	public Animator animator;
	CharacterMovementModel m_characterMovementModel;

	void Awake() {
		m_characterMovementModel = GetComponent<CharacterMovementModel> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

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
}
