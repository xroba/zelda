using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour {

    characterBatController characterbatcontroller;

    void Awake()
    {
        characterbatcontroller = GetComponentInParent<characterBatController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            characterbatcontroller.onHitCharacter(other.gameObject);
        }

    }
}
