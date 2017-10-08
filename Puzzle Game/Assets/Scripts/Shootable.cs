using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {
	
	public int health;
	public GameObject money;
	public Transform npc;

	public void Damage(int damageAmount)
	{
		health -= damageAmount;
		if (health <= 0) 
		{
			Instantiate (money, npc.position, npc.rotation);
			Destroy (gameObject);
		}
	}
}