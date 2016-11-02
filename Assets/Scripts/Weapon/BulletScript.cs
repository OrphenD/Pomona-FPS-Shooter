using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour 
{
	public float maxDist = 1000000f;
	public GameObject decalHitWall;
	public float floatInFrontofWall = 0.00001f;
	public float damage = 15f;
	public float bulletForce = 500;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, maxDist)) 
		{
			if (decalHitWall && hit.transform.tag == "LevelPart") 
			{
				print ("I hit something!");
				Instantiate (decalHitWall, hit.point + (hit.normal * floatInFrontofWall), Quaternion.LookRotation (hit.normal));
			}

			if (hit.collider.tag == "Enemy") 
			{
				print ("I'm hit!");
				hit.transform.GetComponent<EnemyAi>().takeDamage(damage);
				if (hit.transform.GetComponent<EnemyAi>().enemyHealth > 0) {

				} else {
					hit.transform.GetComponent<Rigidbody>().AddForce (transform.forward * bulletForce);
				}
			}
		}
			
		Destroy (gameObject);
	
	}
}
