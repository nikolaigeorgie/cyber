
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using SimpleFirebaseUnity;
using SimpleFirebaseUnity.MiniJSON;

using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

public class Checkout : MonoBehaviour {

	System.Guid myGUID = System.Guid.NewGuid();

	public static string rxsRedPurchased;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void checkedOUT(){

		StartCoroutine (checkoutCompleted ());

	}

	string customerId = "124211234";

	IEnumerator checkoutCompleted() {

		rxsRedPurchased = RedPurchase.rxsRedShoeDetails;

		Firebase firebase = Firebase.CreateNew ("fir-test-884fd.firebaseio.com");

		FirebaseQueue firebaseQueue = new FirebaseQueue();

		//firebaseQueue.AddQueuePush(firebase.Child("order/customer", true), secondDetails + newDetails, true);
		firebaseQueue.AddQueuePush(firebase.Child("customers/" + myGUID, true), rxsRedPurchased, true);
		firebaseQueue.AddQueuePush(firebase.Child("customers/" + myGUID + "/Shoe", true), rxsRedPurchased, true);

		yield return new WaitForSeconds (15f);

		yield return null;


	}

}
