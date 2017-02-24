using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look Smooth")]

public class MouseLookSM : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;
	float rotationX = 0F;

	//Сглаживание
	public float _Smooth = 0.1f; //Коэффициент скорости интерполяции, чем меньше, тем быстрее.
	float _rotationY;
	float _rotationX;

	void Update ()
	{
		//Unity5
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;

		//Unity4
		/*Screen.lockCursor = true;
		Screen.showCursor = false;*/

		if (axes == RotationAxes.MouseXAndY)
		{
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			//Интерполяция поворота
			_rotationY = Mathf.Lerp(_rotationY, rotationY, _Smooth);
			_rotationX = Mathf.Lerp(_rotationX, rotationX, _Smooth);

			//Применение значений к объеку
			transform.localEulerAngles = new Vector3(-_rotationY, _rotationX, 0); 
		}
		else if (axes == RotationAxes.MouseX)
		{
			//transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0); Опять странная фигня

			rotationX += Input.GetAxis("Mouse X") * sensitivityX;

			//Интерполяция поворота
			_rotationX = Mathf.Lerp(_rotationX, rotationX, _Smooth);

			transform.localEulerAngles = new Vector3(0, _rotationX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

			//Интерполяция числа
			_rotationY = Mathf.Lerp(_rotationY, rotationY, _Smooth);

			transform.localEulerAngles = new Vector3(-_rotationY, transform.localEulerAngles.y, 0);
		}
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;

		Cursor.lockState = CursorLockMode.Locked;
	}
}