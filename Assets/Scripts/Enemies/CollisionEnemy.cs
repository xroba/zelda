using UnityEngine;
using System.Collections;

public class CollisionEnemy : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collide");

        }

    }
}
