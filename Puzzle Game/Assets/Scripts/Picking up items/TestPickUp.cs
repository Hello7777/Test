using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPickUp : MonoBehaviour {
	
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
			GetComponent<Rigidbody>().useGravity = false;
			//GetComponent<Rigidbody>().isKinematic = true;
			GetComponent<BoxCollider>().isTrigger = true;
			transform.parent = playerCam;
			beingCarried = true;
		}
		if (beingCarried)
		{
			if (touched)
			{
				//GetComponent<Rigidbody>().isKinematic = false;
				GetComponent<BoxCollider>().isTrigger = false;
				GetComponent<Rigidbody>().useGravity = true;
				transform.parent = null;
				beingCarried = false;
				touched = false;
			}
			if (Input.GetMouseButtonDown(0))
			{
				//GetComponent<Rigidbody>().isKinematic = false;
				GetComponent<Rigidbody>().useGravity = true;
				GetComponent<BoxCollider>().isTrigger = false;
				transform.parent = null;
				beingCarried = false;
				GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
			}
			else if (Input.GetMouseButtonDown(1))
			{
				//GetComponent<Rigidbody>().isKinematic = false;
				GetComponent<Rigidbody>().useGravity = true;
				GetComponent<BoxCollider>().isTrigger = false;
				transform.parent = null;
				beingCarried = false;
			}
		}
	}

	void OnTriggerEnter()
	{
		if (beingCarried)
		{
			touched = true;
		}
	}
}