using UnityEngine;
using System.Collections;

public class FloatBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyDown("t"))
        {
            GetComponent<Animation>().Play("Sphere|Float");
        }
	}
}
