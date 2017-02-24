using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
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
