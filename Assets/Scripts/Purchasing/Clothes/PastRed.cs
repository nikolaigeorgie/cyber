
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
public class PastRedClothes{

	public int station;
	public string productName;
	public string color;
	public int size;
	public int quantity;
	public int totalPrice;
}


public class PastRed : MonoBehaviour {


	public GameObject sizeSelection;
	public GameObject quantitySelection;
	public GameObject finalMessage;
	public GameObject purchaseOption;

		public void SizeButton()
		{
			//            Debug.Log("Red Button Clicked");
			//			size5.SetActive(false);

			sizeSelection.SetActive (false);
			quantitySelection.SetActive(true);
		}


		public void QuantityButton() {

			quantitySelection.SetActive (false);
			finalMessage.SetActive (true);
		}


		public void PurchaseButton() {

			purchaseOption.SetActive (false);
			sizeSelection.SetActive (true);
		}


	}
