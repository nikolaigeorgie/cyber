
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
public class SprayClothes{

	public int station;
	public string productName;
	public string color;
	public int size;
	public int quantity;
	public int totalPrice;
}

public class Spray : MonoBehaviour {

	/*
		public GameObject sizeSelection;
		public GameObject quantitySelection;
		public GameObject finalMessage;
		public GameObject purchaseOption;


	SprayClothes sprayClothes = new SprayClothes ();

	public static string sprayClothesDetails;

		public void SizeButton()
		{
		rxsShoe.station = 3;
		rxsShoe.productName = "Revenge X Storm";
		rxsShoe.color = "Blue";
		rxsShoe.size = 9;


			sizeSelection.SetActive (false);
			quantitySelection.SetActive(true);
		}


		public void QuantityButton() {

			quantitySelection.SetActive (false);
			finalMessage.SetActive (true);

		rxsShoe.quantity = 1;
		rxsShoe.totalPrice = 200;
		rxsBlackShoeDetails = JsonUtility.ToJson (rxsShoe);

		}


		public void PurchaseButton() {

			purchaseOption.SetActive (false);
			sizeSelection.SetActive (true);
		}
		*/

	}
