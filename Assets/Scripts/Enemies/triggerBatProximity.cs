using UnityEngine;
using System.Collections;

public class triggerBatProximity : MonoBehaviour {

    characterBatController m_characterBat;

    void Awake()
    {
        m_characterBat = GetComponentInParent<characterBatController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            m_characterBat.setCharacterInRange(other.gameObject);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            m_characterBat.setCharacterInRange(null);
        }
    }

}
