using UnityEngine;
using System.Collections;

public class HandSpawn : MonoBehaviour {

	LightingBox _LB;

    //-------------------------
    void Awake ()
	{
        try
        {
            _LB = GameObject.Find("LightningBox").GetComponent<LightingBox>();
        }
        catch
        {

        }
    }
	//-------------------------
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
            if(_LB != null)
			    _LB.OneSpawn();
        }
	}
	//-------------------------
}
