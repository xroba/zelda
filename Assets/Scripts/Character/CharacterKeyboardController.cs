using UnityEngine;
using System.Collections;

public class CharacterKeyboardController : CharacterBaseController {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		UpdateDirection ();
		UpdateAction ();
	}

	public void UpdateDirection()
	{
		Vector2 direction = Vector2.zero;

		if(Input.GetKey(KeyCode.DownArrow))
		{
			direction.y = - 1;
		}

		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			direction.y = 1;
		}

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			direction.x = 1;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			direction.x = -1;
		}

		SetDirection (direction);
	}

	public void UpdateAction(){

		if (Input.GetKeyDown (KeyCode.Space)) {
			onActionPressed();
		}

	}
}
