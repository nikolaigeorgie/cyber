using UnityEngine;
using System.Collections;

public class RainConrtoller : MonoBehaviour {
	
	public GameObject _Player;
	
	void Start () 
	{
		_Player = Camera.main.gameObject;
	}

	void FixedUpdate ()
	{
		this.transform.position = new Vector3(_Player.transform.position.x, this.transform.position.y, _Player.transform.position.z);
	}
}
