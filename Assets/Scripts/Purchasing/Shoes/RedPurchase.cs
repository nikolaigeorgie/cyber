
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


	//Sizes
	public void sizeFive() {
		rxsShoe.station = 3;
		rxsShoe.productName = "Revenge X Storm";
		rxsShoe.color = "Red";

		rxsShoe.size = 5;
		sizeSelection.SetActive (false);
		quantitySelection.SetActive(true);
	}

	public void sizeSix() {
		rxsShoe.station = 3;
		rxsShoe.productName = "Revenge X Storm";
		rxsShoe.color = "Red";

		rxsShoe.size = 6;
		sizeSelection.SetActive (false);
		quantitySelection.SetActive(true);
	}

	public void sizeSeven() {
		rxsShoe.station = 3;
		rxsShoe.productName = "Revenge X Storm";
		rxsShoe.color = "Red";

		rxsShoe.size = 7;
		sizeSelection.SetActive (false);
		quantitySelection.SetActive(true);
	}

	public void sizeEight() {
		rxsShoe.station = 3;
		rxsShoe.productName = "Revenge X Storm";
		rxsShoe.color = "Red";

		rxsShoe.size = 8;

		sizeSelection.SetActive (false);
		quantitySelection.SetActive(true);
	}

	public void sizeNine() {
		rxsShoe.station = 3;
		rxsShoe.productName = "Revenge X Storm";
		rxsShoe.color = "Red";

		rxsShoe.size = 9;
	
		sizeSelection.SetActive (false);
		quantitySelection.SetActive(true);
	}

	public void sizeTen() {
		rxsShoe.station = 3;
		rxsShoe.productName = "Revenge X Storm";
		rxsShoe.color = "Red";

		rxsShoe.size = 10;
	
		sizeSelection.SetActive (false);
		quantitySelection.SetActive(true);
	}


	public void sizeEleven() {
		rxsShoe.station = 3;
		rxsShoe.productName = "Revenge X Storm";
		rxsShoe.color = "Red";

		rxsShoe.size = 11;
	
		sizeSelection.SetActive (false);
		quantitySelection.SetActive(true);
	}

	public void sizeTwelve() {
		rxsShoe.station = 3;
		rxsShoe.productName = "Revenge X Storm";
		rxsShoe.color = "Red";

		rxsShoe.size = 12;
		sizeSelection.SetActive (false);
		quantitySelection.SetActive(true);
	}

	public void sizeThirteen() {
		rxsShoe.station = 3;
		rxsShoe.productName = "Revenge X Storm";
		rxsShoe.color = "Red";

		rxsShoe.size = 13;
	
		sizeSelection.SetActive (false);
		quantitySelection.SetActive(true);
	}


	//Quantity
	public void oneQuantity() {
		rxsShoe.quantity = 1;
		rxsShoe.totalPrice = 200;
		quantitySelection.SetActive (false);
		finalMessage.SetActive (true);
		rxsRedShoeDetails = JsonUtility.ToJson (rxsShoe);
	}

	public void twoQuantity() {
		rxsShoe.quantity = 2;
		rxsShoe.totalPrice = 400;
		quantitySelection.SetActive (false);
		finalMessage.SetActive (true);
		rxsRedShoeDetails = JsonUtility.ToJson (rxsShoe);
	}

	public void threeQuantity() {
		rxsShoe.quantity = 3;
		rxsShoe.totalPrice = 600;
		quantitySelection.SetActive (false);
		finalMessage.SetActive (true);
		rxsRedShoeDetails = JsonUtility.ToJson (rxsShoe);
	}
		
	public void PurchaseButton() {
		purchaseOption.SetActive (false);
		sizeSelection.SetActive (true);
	}

}
