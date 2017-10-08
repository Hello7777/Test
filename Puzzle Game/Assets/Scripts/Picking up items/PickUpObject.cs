using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

	public float Range;
	public Transform player;

	private bool beingCarried;
	private bool hasPlayer;
	private Camera fpsCam;


	// Use this for initialization
	void Start ()
	{
		fpsCam = GetComponentInParent<Camera>();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float dist = Vector3.Distance(gameObject.transform.position, player.position);
		if (dist <= 2.5f)
		{
			hasPlayer = true;
		}
		else
		{
			hasPlayer = false;
		}
		//if (hasPlayer && Input.GetKeyDown("e"))
		//{
		//	GetComponent<Rigidbody>().isKinematic = true;
		//	transform.parent = fpsCam;
		//	beingCarried = true;
		//}

		if (hasPlayer && Input.GetKeyDown ("e"))
		{
			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

			RaycastHit hit;

			if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, Range))
			{
				//Shootable health = hit.collider.GetComponent<Shootable>();

				if (hit.rigidbody != null)
				{
					hit.rigidbody.isKinematic = true;
					transform.parent = fpsCam.transform;
					beingCarried = true;
				}
			}

		}
		
	}
}
