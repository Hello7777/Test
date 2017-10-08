using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

	public int bulletDamage = 25;
	public PlayerHealth damageHealth;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Bullet(Clone)")
		{
			damageHealth.RemoveHealth(bulletDamage);
		}
	}
}