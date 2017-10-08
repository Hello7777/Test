using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float rotSpeed;
	private float rotationX;

	void FixedUpdate () 
	{
		rotationX += Input.GetAxis("Mouse Y") * - rotSpeed;
		rotationX = Mathf.Clamp(rotationX, -90, 90);

		transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
	}
}