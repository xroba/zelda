using UnityEngine;
using System.Collections;

public class characterBatController : CharacterBaseController {

    GameObject characterInRange;

    public float strenghtPush;
    public float timePushed;



    void Update()
    {
        UpdateMovement();
    }

    public void setCharacterInRange(GameObject character)
    {
        characterInRange = character;
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

    public void onHitCharacter(GameObject character)
    {
        characterInRange = null;
        CharacterMovementModel m_characterMovement = character.GetComponent<CharacterMovementModel>();
        Vector2 directionToPush = (character.transform.position - transform.position).normalized;
        m_characterMovement.pushCharacter(directionToPush * strenghtPush, timePushed);
       
    }
}
