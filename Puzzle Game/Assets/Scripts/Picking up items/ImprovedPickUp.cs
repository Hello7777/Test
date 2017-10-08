using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedPickUp : MonoBehaviour {

	public Transform player;
	public Transform playerCam;
	public float throwForce = 10;
	bool hasPlayer = false;
	bool beingCarried = false;
	private bool touched = false;

	void Update()
	{
		float dist = Vector3.Distance(gameObject.transform.position, player.position);
		if (dist <= 3.5f)
		{
			hasPlayer = true;
		}
		else
		{
			hasPlayer = false;
		}
		if (hasPlayer && Input.GetKeyDown("e"))
		{
			print ("hello player");
			GetComponent<Rigidbody>().useGravity = false;
			transform.parent = playerCam;
			beingCarried = true;
		}
		if (beingCarried)
		{
			if (touched)
			{
				GetComponent<Rigidbody>().useGravity = true;
				transform.parent = null;
				beingCarried = false;
				touched = false;
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
			}
			if (Input.GetMouseButtonDown(0))
			{
				GetComponent<Rigidbody>().useGravity = true;
				transform.parent = null;
				beingCarried = false;
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
			}
		}
	}

	void OnCollisonEnter(Collision col)
	{
		if(col.gameObject.name == "Cube (5)")
		{
			Debug.Log (gameObject.name + "something something" + col.gameObject.name);
			print ("hello collison");
			//GetComponent<Rigidbody>().useGravity = true;
			//transform.parent = null;
			//beingCarried = false;
			//touched = false;
			//GetComponent<Rigidbody> ().velocity = Vector3.zero;
			//if (beingCarried)
			//{
				//touched = true;
			//}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Collider>() != null)
		{
			Debug.Log (gameObject.name + "was trigger by" + other.gameObject.name);
	
		}
	}
}