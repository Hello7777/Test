using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {

	public Text moneyText;
	public RayCastShooting ammoCrate;

	private int money;

	void Start () 
	{
		money = 0;
		currentMoney ();
	}
		
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUpMoney"))
		{
			money = money + Random.Range (5, 50);
			currentMoney ();
			Destroy (other.gameObject);
		}
		if (other.gameObject.CompareTag ("PickUpAmmo")) 
		{
			ammoCrate.ammoResupply();
			Destroy (other.gameObject);
		}
	}

	void currentMoney ()
	{
		moneyText.text = "$" + money.ToString ();
	}
}