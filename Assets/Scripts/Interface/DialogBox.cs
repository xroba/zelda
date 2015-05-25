using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

	string displayText;
	static DialogBox instance;
	Image m_image;
	Text m_text;

	// Use this for initialization
	void Awake () {
		instance = this;
		m_image = GetComponent<Image> ();
		m_text = GetComponentInChildren<Text> ();
	}


	public static void Show( string displayText){
		instance.doShow(displayText);
	}

	public static void Hide(){
		instance.doHide ();
	}

	void doShow(string displayText){

		m_text.enabled = true;
		m_text.text = displayText;

		m_image.enabled = true;

	}

	void doHide(){
		m_text.enabled = false;
		m_image.enabled = false;
	}

	public static bool isVisible(){
		return instance.m_image.enabled;
	}
}
