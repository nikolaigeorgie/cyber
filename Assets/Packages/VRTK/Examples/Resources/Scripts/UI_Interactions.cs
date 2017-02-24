namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class UI_Interactions : MonoBehaviour
    {
        private const int EXISTING_CANVAS_COUNT = 4;

		public GameObject buttonRed;

/*
		public GameObject size5;
		public GameObject size6;
		public GameObject size7;
		public GameObject size8;
		public GameObject size9;
		public GameObject size10;
		public GameObject size11;
		public GameObject size12;
*/
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
}