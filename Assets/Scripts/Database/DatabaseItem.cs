using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : ScriptableObject {

    public List<DataItem> m_items;


    public DataItem FindItem(ItemType itemType)
    {
        for (int i=0;  i < m_items.Count; i++)
        {
            if (m_items[i].type == itemType)
            {
                return m_items[i];
            }
        }
        return null;
    }
	
}


[System.Serializable]
public class DataItem {
	public ItemType type;
	public GameObject Prefabs;
    public bool isEquipable;
}
