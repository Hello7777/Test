using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int health = 100;
	public Slider healthSlider;

	public void RemoveHealth(int amount)
	{
		health -= amount;
		SetHealth (health);
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void SetHealth(int MyHealth)
	{
		healthSlider.value = MyHealth;
	}
}