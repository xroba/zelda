using UnityEngine;
using System.Collections;
using UnityEditor;


public class editorDatabaseItems  {

	[MenuItem("Rubbik/DatabaseOfItems/createData")]
	public static void CreateDatabaseAsset(){

		ItemDatabase databaseAsset = ScriptableObject.CreateInstance<ItemDatabase> ();
        AssetDatabase.CreateAsset(databaseAsset, "Assets/Resources/Databases/dataofitem.asset");
		AssetDatabase.SaveAssets ();

	}


}
