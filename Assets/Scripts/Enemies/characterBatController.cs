using UnityEngine;
using System.Collections;

public class characterBatController : CharacterBaseController {

    GameObject characterInRange;

   public void setCharacterInRange(GameObject character)
    {
        characterInRange = character;
    }

    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        Vector2 directionToFlee = Vector2.zero;

        if (characterInRange != null)
        {
            if (characterInRange.tag == "Player"){

                directionToFlee = (characterInRange.transform.position - transform.position).normalized;
            }
        }

        SetDirection(directionToFlee);

    }

}
