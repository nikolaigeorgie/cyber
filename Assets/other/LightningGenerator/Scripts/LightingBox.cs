///**********<KerKerO>*******(つ ☻_☻ )つ*↯↯↯↯*
///******Lightning Generator*LightBox*U5*****
///**********<v.1.5.>************************
///******************************************
///*******☁☁**☁☁***☁☁****☁☁*☁*****☁****
///********ϟ****ϟ******ϟ******ϟ**************
///******************************************
///*************☂***************************
///******www.kerkero.ucoz.org****************
///******************************************
using UnityEngine;
using System.Collections;
//using UnityEditor;

public class LightingBox : MonoBehaviour {

	public GameObject _light;

	public bool _ShowGizmo = true;
    public Color _ColorGizmo = Color.yellow;
    Vector3 _Size;
	public float _X;
	public float _Y;
	public float _Z;

	float _Xu;
	float _Yu;
	float _Zu;

	public bool _AutoSpawn;
	float _RateAutoSpawn;//In Sec

	bool _BlockAutoSpawn;

	//SecToNewSpawn
	public int _MinSec = 1;
	public int _MaxSec = 10;

	//-------------------------
	void Start () 
	{
		_Xu = _X/2;
		_Yu = _Y/2;
		_Zu = _Z/2;

		if(_RateAutoSpawn <= 0)
		{
			_RateAutoSpawn = 1;
		}
		_BlockAutoSpawn = false;

		//LagsBlocker 3000 :D
		if(_MaxSec <= 0)
		{
			_MaxSec = 1;
		}
	}
	//--------------------------
	void Update () 
	{
		if(_AutoSpawn == true && _BlockAutoSpawn == false)
		{
			AutoSpawn();
			_BlockAutoSpawn = true;
		}

		if(_AutoSpawn == false)
		{
			CancelInvoke("Spawn");
			_BlockAutoSpawn = false;
		}
	}
	//--------------------------
	void AutoSpawn ()
	{
		_RateAutoSpawn = Random.Range(_MinSec, _MaxSec + 1);
		InvokeRepeating("Spawn", _RateAutoSpawn, 0);
	}
	void Spawn ()
	{
        OneSpawn();
        CancelInvoke("Spawn");
		AutoSpawn();
	}
	public void OneSpawn ()
	{
		GameObject _LGO = Instantiate(_light, this.transform.localPosition + new Vector3(Random.Range(-_Xu, _Xu), Random.Range(-_Yu, _Yu), Random.Range(-_Zu, _Zu)), this.gameObject.transform.rotation) as GameObject;
		_LGO.transform.parent = this.gameObject.transform;
	}
    //---------------------------
    [Header("Max Height Lightning In Unit (Read Only)")]
    public float _Height = 20;
    void OnDrawGizmos() 
	{
		if(_ShowGizmo == true)
		{
            Gizmos.color = _ColorGizmo;
            Gizmos.DrawCube(transform.position, new Vector3(_X, _Y, _Z));
		}
        _Height = _light.GetComponent<LightGenerator>()._MaxLightPoint * _light.GetComponent<LightGenerator>()._PointRange._Max;
    }
}
