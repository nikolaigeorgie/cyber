using UnityEngine;
using System.Collections;

public class SoundTimeControll : MonoBehaviour {

	void FixedUpdate () 
	{
		GetComponent<AudioSource>().pitch = Time.timeScale;
	}

}
