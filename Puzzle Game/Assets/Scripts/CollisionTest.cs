using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

	void OnCollisonEnter(Collision col)
	{
		Debug.Log (gameObject.name + "something something" + col.gameObject.name);
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log (gameObject.name + "was trigger by" + other.gameObject.name);
	}
}