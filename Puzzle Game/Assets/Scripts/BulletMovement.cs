using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public int enemyDamage = 25;

		public Rigidbody rocketPrefab;
		public Transform barrelEnd;

		void FixedUpdate ()
		{
		if(Input.GetKeyDown(KeyCode.Mouse0))
			{
				Rigidbody rocketInstance;
				rocketInstance = Instantiate(rocketPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
				rocketInstance.AddForce(barrelEnd.forward * 500);
			}
		}
}