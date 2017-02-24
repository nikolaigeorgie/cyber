using UnityEngine;
using System.Collections;

public class MovieController : MonoBehaviour {


    public MovieTexture movieTexture;
	// Use this for initialization
	void Start () {

        GetComponent<Renderer>().material.mainTexture = movieTexture;
        movieTexture.loop = true;
        movieTexture.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
