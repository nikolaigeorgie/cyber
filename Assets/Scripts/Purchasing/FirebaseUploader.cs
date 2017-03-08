/*
using UnityEngine;

using SimpleFirebaseUnity;
using SimpleFirebaseUnity.MiniJSON;

using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

[System.Serializable]
public class RevengeShoeRed{

	public int station;
	public string productName;
	public string color;
	public int size;
	public int quantity;
	public int totalPrice;
}

public class FirebaseUploader: MonoBehaviour
{

		// Use this for initialization
		void Start()
		{
			StartCoroutine (Tests ());
		}

	public static string rxsRedPurchased;

		IEnumerator Tests()
		{
			Firebase firebase = Firebase.CreateNew ("fir-test-884fd.firebaseio.com");

			FirebaseQueue firebaseQueue = new FirebaseQueue();

		
			OrderDetails details = new OrderDetails ();
			details.station = 3;
			details.name = "NIKO";
			string newDetails = JsonUtility.ToJson (details);
			Debug.Log (newDetails);

		OrderDetails anotherdetails = new OrderDetails ();
		anotherdetails.station = 2;
		anotherdetails.name = "aaa";
		string secondDetails = JsonUtility.ToJson (anotherdetails);
		Debug.Log (secondDetails);


			//firebaseQueue.AddQueueSet (firebase, FirebaseParam.Empty.PrintSilent ());
		firebaseQueue.AddQueuePush(firebase.Child("order/customer", true), secondDetails + newDetails, true);
		firebaseQueue.AddQueuePush(firebase.Child("order/customer/shoe", true), rxsRedPurchased, true);
			yield return new WaitForSeconds (15f);

			yield return null;
		}


}
*/