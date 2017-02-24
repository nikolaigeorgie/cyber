using UnityEngine;
using System.Collections;

public class LightingShaderPrev : MonoBehaviour {

	Color LightColor;
	float _LightAlpha;

	bool _Up;

	// Use this for initialization
	void Start () 
	{
		LightColor = this.gameObject.GetComponent<Renderer>().material.GetColor("_TintColor");
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			Time.timeScale = 0.1f;
		}
		if(Input.GetKeyDown(KeyCode.E))
		{
			Time.timeScale = 1f;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		ChangeAlpha();

		this.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(LightColor.r, LightColor.g, LightColor.b, _LightAlpha));
	}

	void ChangeAlpha ()
	{
		if(_LightAlpha >= 1 && _Up == true)
		{
			_Up = false;
		}

		if(_LightAlpha <= 0 && _Up == false)
		{
			_Up = true;
		}

		if(_Up == false)
		_LightAlpha -= 0.01f;
		if(_Up == true)
		_LightAlpha += 0.01f;
	}
}
