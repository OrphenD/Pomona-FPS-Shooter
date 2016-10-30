using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour 
{

	public float fireSpeed = 15.0f;
	public float waitTilNextFire = 0.0f;
	public GameObject bullet;
	public GameObject bulletSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButton("Fire1"))
		{
			if(waitTilNextFire <=0)
			{
				if (bullet) {
					Instantiate (bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
					this.GetComponent<AudioSource> ().Play ();
				}
				waitTilNextFire = 1;
			}
		}
		waitTilNextFire -= Time.deltaTime * fireSpeed;
	}
}
