﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterInventoryModel : MonoBehaviour {
	CharacterMovementModel m_MovementModel;
	Dictionary<ItemType,int> m_Items = new Dictionary<ItemType,int> ();

	void Awake(){
		m_MovementModel = GetComponent<CharacterMovementModel>();
	}
	
	public void addItem(ItemType itemType){
		AddItem (itemType, 1);
	}

	public void AddItem(ItemType itemType ,int amount){

		if (m_Items.ContainsKey (itemType)) {
			m_Items [itemType] += amount;
		} else {
			m_Items.Add (itemType, amount);
		}

        if (amount > 0)
        {
            DataItem m_data = Database.item.FindItem(itemType);
            if (m_data != null )
            {
                if(m_data.animation != DataItem.PickupAnimation.None)
                    m_MovementModel.ShowEquipItem(itemType);

                if(m_data.isEquipable == DataItem.equipable.SwordHand)
                    m_MovementModel.EquipWeapon(itemType);
            }

        }
	}



   

}
