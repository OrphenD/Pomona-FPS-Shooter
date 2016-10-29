using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour 
{
	public float maxDist = 10000000f;
	public GameObject decalHitWall;
	public float floatInFrontofWall = 0.00001f;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, hit, maxDist)) {
			if (decalHitWall && hit.transform.tag == "Level Parts") {
				Instantiate (decalHitWall, hit.point + (hit.normal * floatInFrontofWall), Quaternion.LookRotation (hit.normal));
			}
		}
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
