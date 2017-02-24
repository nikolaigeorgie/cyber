///**********<KerKerO>*******(つ ☻_☻ )つ*↯↯↯↯*
///******Lightning Generator for UNITY 5*****
///**********<v.1.5.>************************
///******************************************
///*******☁☁**☁☁***☁☁****☁☁*☁*****☁****
///********ϟ****ϟ******ϟ******ϟ**************
///******************************************
///*************☂****************************
///******www.kerkero.ucoz.org****************
///******************************************
using UnityEngine;
using System.Collections;

public class LightGenerator : MonoBehaviour {

	GameObject _Player;

	public float _LightFadeDelay = 0.015f;

	public float _RatioRameRelativelyMain = 1.5f;

	//Основная искра
	public int _MaxLightPoint;//Максимальное количество точек основной искры
    Vector3[] _LightPart;
	LineRenderer _LineRender;
    int _Point = 0;

    //Ответвления
    public int _MaxRamePoint;//Максимальное количество точек ответвлений
	Vector3[] _StartPointRame;
	Vector3[] _LightPartRame;
	public GameObject _LightRame_Prefab;
	GameObject[] _LightRame = new GameObject[0];

	//Сила смещения точек
	public PointRange _PointRange;
	[System.Serializable]
	public class PointRange
	{
		public float _Min;
		public float _Max;
	}

	//Свет
	public Light _LightSource;
	float _LightIntensity = 6;
	float _k;
	//Звук
	public AudioClip[] _LAC;
	int _LACcount;

	Vector3 _TGP;//Позиция источника
	float _LightAlpha = 2;//Альфа молнии

	//Точки смещений
	float X;
	float Y;
	float Z;
	//Точки смещений ответвлений
	float Xrame;
	float Yrame;
	float Zrame;
	
	//Цвет молнии
	Color LightColor;
    public Flare[] _Flares;

    //Количество вспышек
    int SecondFlashCount = 0;
    int Flash = 0;

    //Руды
    public bool _UseRod = true;
    GameObject[] _Rods;
    int rr = 0;
    float ll = 0;

    public bool _ForceUseRod = true;

    //-----------
    void Start () 
	{
        int rc = FindObjectsOfType<LightningRod>().Length;
        if (rc > 0)
        {
            _Rods = new GameObject[rc];

            for (int q = 0; q < rc; q++)
            {
                _Rods[q] = FindObjectsOfType<LightningRod>()[q].gameObject;
            }
        }
        else
        {
            _UseRod = false;
        }

        LightColor = this.gameObject.GetComponent<Renderer>().material.GetColor("_TintColor");

		_LineRender = this.gameObject.GetComponent<LineRenderer>();
		_TGP = this.gameObject.transform.position;

		_Player = Camera.main.gameObject;

		GenerateLight();

		_LACcount = _LAC.Length;

		_k = _LightIntensity * 0.084f;

        if(_Flares.Length != 0)
        _LightSource.flare = _Flares[Random.Range(0, _Flares.Length)];

        SecondFlashCount = Random.Range(0, 2); 
	}

	//Основная точка
	void OnDrawGizmos() 
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, 1);
	}
    
    //-----Генерация основных точек молнии--------------------------------------------------------------------------------------------
    void GenerateLight ()
    {
		_Point = Random.Range(5, _MaxLightPoint);
		_LightPart = new Vector3[_Point];

        ll = _Point * _PointRange._Max;//Длина молнии

        if (_UseRod == true)
        {
            float MinD = 0;

            for (int q = 0; q < _Rods.Length; q++)
            {
                float D = Vector3.Distance(this.transform.position, _Rods[q].transform.position);
                if (q > 0)
                {
                    if (MinD > D)
                    {
                        MinD = D;
                        rr = q;
                    }
                }
                else
                {
                    MinD = D;
                    rr = q;
                }
            }

            if (ll < MinD/2)
                _UseRod = false;

            if (_ForceUseRod == true)
                _UseRod = true;
        }

        for (int _l = 0; _l < _LightPart.Length; _l++)
		{
			if(_l == 0)
			{
				_LightPart[_l] = new Vector3(_TGP.x, _TGP.y, _TGP.z);
			}
			else
			{
				X = _LightPart[_l - 1].x;
				Y = _LightPart[_l - 1].y;
				Z = _LightPart[_l - 1].z;

                if (_UseRod == false)
                {
                    _LightPart[_l] = new Vector3(X + Random.Range(_PointRange._Min, _PointRange._Max), Y + Random.Range(_PointRange._Min, -_PointRange._Max), Z + Random.Range(_PointRange._Min, _PointRange._Max));
                }
                else
                {
                    InRod(_l, rr);
                }
            }
		}

		GenerateLightRame();
		DrawLight();
		SoundLight();
		_LightSource.intensity = _LightIntensity;
		_Rods [rr].GetComponent<LightningRod> ().LightningHit();
	}
	//--------------------------------------------------------------------------------------------------------------------------------
	//-----Графическое построение молнии----------------------------------------------------------------------------------------------
	void DrawLight ()
	{
		_LightAlpha = 1.1f;
		_LineRender.SetVertexCount(_LightPart.Length);

		for(int _p = 0; _p < _LightPart.Length; _p++)
		{
			_LineRender.SetPosition(_p, _LightPart[_p]);
        }

		InvokeRepeating("AnimLight", 0, _LightFadeDelay);//0.08f//un4-0.07f
	}

	//-----Анимация-------------------------------------------------------------------------------------------------------------------
	void AnimLight ()
	{
		if(_LightAlpha > 0.1f)
		{
            _LightAlpha -= 0.05f;
			_LightSource.intensity -= _k;

            if(_LightAlpha < 0.6f && Flash < SecondFlashCount)
            {
                Flash++;
                _LightAlpha = 1.1f;
                _LightSource.intensity = 5;
            }
		}
		else
		{
			_LightAlpha = 0;
			_LightSource.intensity = 0;
			CancelInvoke("AnimLight");

			//Optim
			Destroy(this.gameObject.GetComponent<LineRenderer>());
			for(int _rame = 0; _rame < _LightRame.Length; _rame++)
			{
				Destroy(_LightRame[_rame].GetComponent<LineRenderer>());
			}
		}

		this.gameObject.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(LightColor.r, LightColor.g, LightColor.b, _LightAlpha));

		for(int _rame = 0; _rame < _LightRame.Length; _rame++)
		{
			_LightRame[_rame].GetComponent<Renderer>().material.SetColor("_TintColor", new Color(LightColor.r, LightColor.g, LightColor.b, _LightAlpha));
		}
	}
	//---------------------------------------------------------------------------------------------------------------------------------
	//-----Звук------------------------------------------------------------------------------------------------------------------------
	void SoundLight ()
	{
		float _Distance = Vector3.Distance(_TGP, _Player.transform.position);
		float _Latency = _Distance/300;

		Invoke("PlaySound", _Latency);
	}
	void PlaySound ()
	{
		int _AC = Random.Range(0, _LACcount);
		if(_AC == _LACcount)
			_AC = 1;

		GetComponent<AudioSource>().PlayOneShot(_LAC[_AC]);
        Destroy(this.gameObject, 10);

        CancelInvoke("PlaySound");
	}
	//---------------------------------------------------------------------------------------------------------------------------------
	//-----Свет------------------------------------------------------------------------------------------------------------------------
	void LightSource ()
	{

	}
	//---------------------------------------------------------------------------------------------------------------------------------
	//-----Генератор точек ответвлений--------------------------------------------------------------------------------------------
	void GenerateLightRame ()
	{
		int _LP = _LightPart.Length;//Количество точек основной молнии

		if(_LP > 10)
		{
            int _LPrame = Random.Range(3, 10);//Количество начальных точек ответвления
			_StartPointRame = new Vector3[_LPrame];//Количество начальных точек ответвлений
			_LightRame = new GameObject[_LPrame];//Количество объектов ответвлений


			for(int _l = 0; _l < _StartPointRame.Length; _l++)
			{
				int _s = Random.Range(0, _LP);
				_StartPointRame[_l] = _LightPart[_s];//Координаты начальных точек ответвлений

				//Объект ответвления
				_LightRame[_l] = Instantiate(_LightRame_Prefab, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
				_LightRame[_l].gameObject.transform.parent = this.gameObject.transform;

				int _PointsOneRame = Random.Range(3, _MaxRamePoint);//Количиство точек одного ответвления
				_LightPartRame = new Vector3[_PointsOneRame];

				//Создание ответвления
				for(int _lrame = 0; _lrame < _PointsOneRame; _lrame++)
				{
					if(_lrame == 0)
					{
						_LightPartRame[_lrame] = new Vector3(_StartPointRame[_l].x, _StartPointRame[_l].y, _StartPointRame[_l].z);
					}
					else
					{
						Xrame = _LightPartRame[_lrame - 1].x;
						Yrame = _LightPartRame[_lrame - 1].y;
						Zrame = _LightPartRame[_lrame - 1].z;

						_LightPartRame[_lrame] = new Vector3(Xrame + Random.Range(_PointRange._Min, _PointRange._Max) * _RatioRameRelativelyMain, Yrame + Random.Range(-_PointRange._Max, _PointRange._Max), Zrame + Random.Range(_PointRange._Min, _PointRange._Max) * _RatioRameRelativelyMain);
					}
				}
				DrawLightRame(_l);
			}
        }
	}
	void DrawLightRame (int _l)
	{
        _LightRame[_l].GetComponent<LineRenderer>().SetVertexCount(_LightPartRame.Length);
		
		for(int _q = 0; _q < _LightPartRame.Length; _q++)
		{
			_LightRame[_l].GetComponent<LineRenderer>().SetPosition(_q, _LightPartRame[_q]);
		}

	}
	//--------------------------------------------------------------------------------------------------------------------------------
    void InRod (int _l, int Rod)
    {
        Vector3 s = this.transform.position;
        Vector3 rod = _Rods[Rod].transform.position;

        Vector3 heading = this.transform.position - rod;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;

        if (_l == _LightPart.Length-1)
        {
            _LightPart[_l] = rod;
        }
        else
        {
            _LightPart[_l] = this.transform.position 
                + new Vector3(Random.Range(_PointRange._Min, _PointRange._Max), Random.Range(_PointRange._Min, _PointRange._Max), Random.Range(_PointRange._Min, _PointRange._Max))
                - direction * distance/_Point * _l;
        }
    }

}
