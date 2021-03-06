using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RayCastShooting : MonoBehaviour {

	public int gunDamage;
	public float fireRate;
	public float weaponRange;
	public float hitForce;   
	public Transform gunEnd;
	public Text gunAmmoText;
	public Text ammoText;


	private Camera fpsCam;                                              
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
	private AudioSource gunAudio;
	private LineRenderer laserLine;
	private float nextFire;
	private int gunAmmo;
	private int ammo;


	void Start () 
	{
		laserLine = GetComponent<LineRenderer>();
		gunAudio = GetComponent<AudioSource>();
		fpsCam = GetComponentInParent<Camera>();
		gunAmmo = 9;
		ammo = 18;
		currentAmmo ();
	}


	void Update () 
	{
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire && gunAmmo > 0) 
		{
			nextFire = Time.time + fireRate;

			StartCoroutine (ShotEffect());

			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));

			RaycastHit hit;

			laserLine.SetPosition (0, gunEnd.position);

			if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
			{
				laserLine.SetPosition (1, hit.point);
				Shootable health = hit.collider.GetComponent<Shootable>();

				if (health != null)
				{
					health.Damage (gunDamage);
				}

				if (hit.rigidbody != null)
				{
					hit.rigidbody.AddForce (-hit.normal * hitForce);
				}
			}
			else
			{
				laserLine.SetPosition (1, rayOrigin + (fpsCam.transform.forward * weaponRange));
			}
		}
		if (Input.GetKeyDown (KeyCode.R) && ammo > 0) 
		{
			if (ammo < 9) 
			{
				gunAmmo = ammo;
				ammo = 0;
				currentAmmo ();
			} 
			else
			{
				ammo = gunAmmo + ammo - 9;
				gunAmmo = 9;
				currentAmmo ();
			}
		}
	}

	public void ammoResupply()
	{
		ammo += 30;
		currentAmmo ();
	}

	private IEnumerator ShotEffect()
	{
		gunAmmo -= 1;
		currentAmmo ();
		gunAudio.Play ();

		laserLine.enabled = true;

		yield return shotDuration;

		laserLine.enabled = false;
	}
	void currentAmmo()
	{
		gunAmmoText.text = "Ammo: " + gunAmmo.ToString ();
		ammoText.text = "/" + ammo.ToString ();
	}
}