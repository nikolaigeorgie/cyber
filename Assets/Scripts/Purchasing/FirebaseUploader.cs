using UnityEngine;

using SimpleFirebaseUnity;
using SimpleFirebaseUnity.MiniJSON;

using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

[System.Serializable]
public class OrderDetails{

	public int station;
	public string name;

}

public class FirebaseUploader: MonoBehaviour
{

	static int debug_idx = 0;



	string jsonString;
	string path;

	// Use this for initialization
	void Start()
	{
		StartCoroutine (Tests ());




	}

	void upload(){




	}



	IEnumerator Tests()
	{
		// Inits Firebase using Firebase Secret Key as Auth
		// The current provided implementation not yet including Auth Token Generation
		// If you're using this sample Firebase End, 
		// there's a possibility that your request conflicts with other simple-firebase-c# user's request
		Firebase firebase = Firebase.CreateNew ("fir-test-884fd.firebaseio.com");

		// Get child node from firebase, if false then all the callbacks are not inherited.
		Firebase temporary = firebase.Child ("temporary", true);
		Firebase lastUpdate = firebase.Child ("lastUpdate");

		// Make observer on "last update" time stamp
		FirebaseObserver observer = new FirebaseObserver(lastUpdate, 1f);
		observer.OnChange += (Firebase sender, DataSnapshot snapshot)=>{

		};
		observer.Start ();


		// Create a FirebaseQueue
		FirebaseQueue firebaseQueue = new FirebaseQueue();


		// testing 
		//path = Application.streamingAssetsPath + "/Order.json";
		//jsonString = File.ReadAllText (path);
		//Debug.Log (jsonString);

		//	Order Details = JsonUtility.FromJson<Order>(jsonString);

		OrderDetails details = new OrderDetails ();
		details.station = 3;
		details.name = "NIKO";
		string newDetails = JsonUtility.ToJson (details);
		Debug.Log (newDetails);



		// Test #1: Test all firebase commands, using FirebaseQueueManager
		// The requests should be running in order 
		firebaseQueue.AddQueueSet (firebase, GetSampleScoreBoard (), FirebaseParam.Empty.PrintSilent ());
		//firebaseQueue.AddQueuePush (firebase.Child ("broadcasts", true), "{ \"name\": \"simple-firebase-csharp\", \"message\": \"awesome!\"}", true);
		firebaseQueue.AddQueuePush(firebase.Child("order", true), newDetails, true);

		firebaseQueue.AddQueueSetTimeStamp (firebase, "lastUpdate");
		firebaseQueue.AddQueueGet (firebase, "print=pretty");
		//	firebaseQueue.AddQueueUpdate (firebase.Child ("layout", true), "{\"x\": 5.8, \"y\":-94}", true);
		//	firebaseQueue.AddQueueGet (firebase.Child ("layout", true));
		firebaseQueue.AddQueueGet (lastUpdate);

		//Deliberately make an error for an example
		firebaseQueue.AddQueueGet (firebase, FirebaseParam.Empty.LimitToLast(-1));

		// (~~ -.-)~~
		yield return new WaitForSeconds (15f);

		// Test #2: Calls without using FirebaseQueueManager
		// The requests could overtake each other (ran asynchronously)
		firebase.Child("broadcasts", true).Push("{ \"name\": \"dikra\", \"message\": \"hope it runs well...\"}", true);

		firebase.Child("broadcasts", true).Push("{ \"test\": \"test\", \"atest\": \"atest\"}", true);


		firebase.GetValue(FirebaseParam.Empty.OrderByKey().LimitToFirst(2));
		temporary.GetValue ();
		firebase.GetValue (FirebaseParam.Empty.OrderByKey().LimitToLast(2));
		temporary.GetValue ();
		firebase.Child ("scores", true).GetValue(FirebaseParam.Empty.OrderByChild ("rating").LimitToFirst(2));

		// Test #3: Delete the frb_child and broadcasts
		firebaseQueue.AddQueueDelete(temporary);
		// please notice that the OnSuccess/OnFailed handler is not inherited since Child second parameter not set to true.
		firebaseQueue.AddQueueDelete (firebase.Child ("broadcasts")); 
		firebaseQueue.AddQueueGet (firebase);

		// ~~(-.-)~~
		yield return null;
		yield return new WaitForSeconds (15f);
		observer.Stop ();
	}


	Dictionary<string, object> GetSampleScoreBoard()
	{
		Dictionary<string, object> rxsShop = new Dictionary<string, object> ();
		Dictionary<string, object> shop = new Dictionary<string, object> ();
		Dictionary<string, object> station = new Dictionary<string, object> ();
		Dictionary<string, object> customer = new Dictionary<string, object> ();
		Dictionary<string, object> customerId = new Dictionary<string, object> ();
		Dictionary<string, object> orders = new Dictionary<string, object> ();
		Dictionary<string, object> rxsShoe = new Dictionary<string, object> ();
		Dictionary<string, object> p3 = new Dictionary<string, object> ();

		//shoeType = "RevengeXStorm";

		//testing serialization


		//	string json = JsonUtility.ToJson ();



		rxsShoe.Add ("Brand", "RevengeXStorm");
		//	rxsShoe.Add ("Size", "9");
		//	rxsShoe.Add ("Amount", "1");


		orders.Add ("gaergasersea", rxsShoe);
		orders.Add ("StationNumber", "1");

		//	customerId.Add ("stationNumber", "1");

		customerId.Add ("orders", orders);

		customer.Add ("asdfasdf", customerId);

		customer.Add ("eeeeeee", customerId);

		shop.Add ("customer", customer);



		rxsShop.Add ("shop", shop);

		//rxsShop.Add("layout", Json.Deserialize("{\"x\": 0, \"y\":10}") as Dictionary<string, object>);
		//rxsShop.Add ("resizable", true);

		//rxsShop.Add("temporary" , "will be deleted later");

		return rxsShop;
	}
}

