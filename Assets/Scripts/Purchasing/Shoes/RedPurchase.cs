
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using SimpleFirebaseUnity;
using SimpleFirebaseUnity.MiniJSON;

using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

[System.Serializable]
public class RxsShoeRed{

	public int station;
	public string productName;
	public string color;
	public int size;
	public int quantity;
	public int totalPrice;
}

public class RedPurchase : MonoBehaviour {


	public GameObject sizeSelection;
	public GameObject quantitySelection;
	public GameObject finalMessage;
	public GameObject purchaseOption;

	RxsShoeRed rxsShoe = new RxsShoeRed ();

	public static string rxsRedShoeDetails;

	//Debug.Log (rxsRedShoeDetails);

	public void SizeButton()
	{
		//            Debug.Log("Red Button Clicked");
		//			size5.SetActive(false);

		rxsShoe.station = 3;
		rxsShoe.productName = "Revenge X Storm";
		rxsShoe.color = "Red";
		rxsShoe.size = 9;


		sizeSelection.SetActive (false);
		quantitySelection.SetActive(true);



	}


	public void QuantityButton() {

		rxsShoe.quantity = 1;
		rxsShoe.totalPrice = 200;
		quantitySelection.SetActive (false);
		finalMessage.SetActive (true);
		rxsRedShoeDetails = JsonUtility.ToJson (rxsShoe);

	}


	public void PurchaseButton() {

		purchaseOption.SetActive (false);
		sizeSelection.SetActive (true);

	}



		

}
