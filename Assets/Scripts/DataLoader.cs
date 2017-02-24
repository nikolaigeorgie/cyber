using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour {

	// Use this for initialization
	public string[] items;


	IEnumerator Start () {
	
		WWW itemsData = new WWW ("http://localhost/CyberShop/itemsdata.php");
		yield return itemsData;
		string itemsDataString = itemsData.text;
		print (itemsDataString);
		items = itemsDataString.Split (';');
		print (GetDataValue (items [0], "Name:"));
	}

	string GetDataValue(string data, string index) {
	
		string value = data.Substring (data.IndexOf (index) + index.Length);
		if(value.Contains("|"))value = value.Remove (value.IndexOf ("|"));	return value;
	}

}
