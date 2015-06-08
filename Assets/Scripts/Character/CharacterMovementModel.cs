using UnityEngine;
using System.Collections;

public class CharacterMovementModel : MonoBehaviour {

	public float speed = 5 ;
	public Vector3 m_MovementDirection;
	public Vector3 m_MovementFacing;
	private Rigidbody2D m_Rb2d;
	private bool m_frozen;
    private GameObject m_DisplayItemPickup;
	public bool m_IsAttacking;
	public ItemType m_equippedWeapon;

	public Transform weaponParent;
    public Transform shieldParent;
    public Transform displayParent;
    private ItemType m_ItemBeenPicked;
    private bool isPickingUpOneHand;
    private bool isPickingUpTwoHand;
    private Vector2 m_pushDirection;
    private float m_timePushed;

	void Awake()
	{
		m_Rb2d = GetComponent<Rigidbody2D> ();
		
        //code due to the fact that the visual is on the character
        if (m_Rb2d == null)
        {
            m_Rb2d = GetComponentInChildren<Rigidbody2D>();
        }
        m_equippedWeapon = ItemType.None;
        m_ItemBeenPicked = ItemType.None;
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
        calculatePushTime();
	}

	void FixedUpdate()
	{
		UpdateMovement ();
	}

	public void SetDirection(Vector2 Direction)
	{
       
        if (Direction != Vector2.zero && m_ItemBeenPicked != ItemType.None)
        {
            setIsFrozen(false, true);
            m_ItemBeenPicked = ItemType.None;
            Destroy(m_DisplayItemPickup);
        }

		if( m_frozen == true){
			return;
		}

        if (isBeingPushed() == true)
        {
            m_MovementDirection = m_pushDirection ;
        }

		m_MovementDirection = new Vector3 (Direction.x, Direction.y, 0);

		if (Direction != Vector2.zero) {
			m_MovementFacing = m_MovementDirection;
		}
	}

    public void calculatePushTime(){
        m_timePushed =  Mathf.MoveTowards(m_timePushed, 0f, Time.deltaTime);
    }

    public void pushCharacter(Vector2 pushDirection, float timePushed)
    {
           m_pushDirection = pushDirection;
           m_timePushed = timePushed;
    }

    public bool isBeingPushed()
    {
        return m_timePushed > 0;
    }

	public Vector3 getDirection(){
		return m_MovementDirection;
	}

	public Vector3 getFacingDirection(){
		return m_MovementFacing;
	}

	public void UpdateMovement(){

		if (m_frozen == true || m_IsAttacking == true) {
			m_Rb2d.velocity = Vector3.zero;
			return;
		}

		if (m_MovementDirection != Vector3.zero) {
			m_MovementDirection.Normalize();
		}

        if (isBeingPushed())
        {
            m_Rb2d.velocity = m_pushDirection;
        }
        else
        {
            m_Rb2d.velocity = m_MovementDirection * speed;
        }

			
	}

	public bool IsMoving(){

		if (m_frozen == true) {
			return false;
		}

		return m_MovementDirection != Vector3.zero;
	}

	public void setIsFrozen(bool frozen, bool affectGameTime){
		m_frozen = frozen;
        if (affectGameTime == true)
        {
            if (m_frozen == true)
            {
                StartCoroutine("FreezeTimeRoutine");
            }
            else
            {
                Time.timeScale = 1;
            }

        }
	}

    public bool isFrozen()
    {
        return m_frozen;
    }

    IEnumerator FreezeTimeRoutine()
    {
        yield return null;
        Time.timeScale = 1;
    } 

	public bool canAttack(){
		if (m_IsAttacking == true) {
			return false;
		} 

		if (m_equippedWeapon == ItemType.None) {
			return false;
		}


		return true;

	}

	public void EquipWeapon( ItemType itemType){
		m_equippedWeapon = itemType;

        DataItem m_DataItem = Database.item.FindItem(itemType);

        if (m_DataItem == null)
        {
            return;
        }

        if (m_DataItem.isEquipable == DataItem.equipable.NotEquipable)
        {
            return;
        }

        if (weaponParent == null)
        {
            return;
        }

        GameObject swordPrefab = m_DataItem.Prefabs;
		//Instantiate(swordPrefab, weaponParent.position, Quaternion.identity);
		GameObject newSword = Instantiate<GameObject> (swordPrefab);
		newSword.transform.parent = weaponParent;
		newSword.transform.localPosition = Vector2.zero;
		newSword.transform.rotation = Quaternion.identity;

	}

    public void ShowEquipItem(ItemType itemType) 
    {

        DataItem m_DataItem = Database.item.FindItem(itemType);

        if (m_DataItem == null)
        {
            return;
        }

        if (displayParent == null)
        {
            return;
        }

        GameObject itemPrefab = m_DataItem.Prefabs;
        //Instantiate(swordPrefab, weaponParent.position, Quaternion.identity);
        m_DisplayItemPickup = Instantiate<GameObject>(itemPrefab);
        m_DisplayItemPickup.transform.parent = displayParent;
        m_DisplayItemPickup.transform.localPosition = Vector2.zero;
        m_DisplayItemPickup.transform.rotation = Quaternion.identity;


        setIsFrozen(true, true);
        m_ItemBeenPicked = itemType;
    
    }

    public ItemType getItemBeenPicked()
    {
        return m_ItemBeenPicked;
    }

	public void doAttack(){
		//Debug.Log ("yes do attack");
	}

    //from Animation
	public void onAttackStarted(){
		m_IsAttacking = true;

	}

    //from Animation
	public void onAttackEnded(){
		m_IsAttacking = false;
	}

    //from Animation
    public void setSortingOrderOfLayer( int orderLayer ) 
    {
        if (weaponParent == null)
        {
            return;
        }
        
        SpriteRenderer[] spriteRenderes = weaponParent.GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer spriteRenderer in spriteRenderes)
        {
            spriteRenderer.sortingOrder = orderLayer;
        }
    }


}
