using UnityEngine;
using System.Collections;

public class Database  {

    private static ItemDatabase m_databaseItem;
    public static ItemDatabase item
    {
        get{

            if (m_databaseItem == null)
            {
                m_databaseItem = Resources.Load<ItemDatabase>("Databases/dataofitem");
                Debug.Log(m_databaseItem);
            }
            return m_databaseItem;
        }
    }



}
