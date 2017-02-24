using UnityEngine;
using System.Collections;

public class LightningRod : MonoBehaviour 
{
	public int _Hits = 0;

	public void LightningHit ()
    {
		_Hits++;
	}
}
