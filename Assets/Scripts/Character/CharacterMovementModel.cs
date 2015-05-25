using UnityEngine;
using System.Collections;

public class CharacterMovementModel : MonoBehaviour {

	public float speed = 5 ;
	public Vector3 m_MovementDirection;
	public Vector3 m_MovementFacing;
	public Rigidbody2D m_Rb2d;

	void Awake()
	{
		m_Rb2d = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		SetDirection (new Vector2(0,-1));
	}

	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		UpdateDirection ();
	}

	public void SetDirection(Vector2 Direction)
	{
		m_MovementDirection = new Vector3 (Direction.x, Direction.y, 0);

		if (Direction != Vector2.zero) {
			m_MovementFacing = m_MovementDirection;
		}
	}

	public Vector3 getDirection(){
		return m_MovementDirection;
	}

	public Vector3 getFacingDirection(){
		return m_MovementFacing;
	}

	public void UpdateDirection(){

		if (m_MovementDirection != Vector3.zero) {
			m_MovementDirection.Normalize();
		}
			m_Rb2d.velocity = m_MovementDirection * speed;
	}

	public bool IsMoving(){

		/*if (m_MovementDirection == Vector3.zero) {
			return false;
		}*/

		return m_MovementDirection != Vector3.zero;
	}
}
