using UnityEngine;
using System.Collections;

public class EnemyAi: MonoBehaviour 
{
	
	private NavMeshAgent agent;
	public GameObject player;

	public float enemyHealth;

	private bool isDead;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
		isDead = false;
	}

	// Update is called once per frame
	void Update () 
	{

		if (!isDead) {

			Vector3 target = player.transform.position - this.transform.position;
			target.y = 0;

			//Vector3 target = player.transform.position;

			float dist = Vector3.Distance (transform.position, player.transform.position);

			if (dist > 4.0f) {
				agent.SetDestination (player.transform.position);
				agent.Resume ();
			} else {
				agent.Stop ();
			}
			//this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation(target), 0.001f);
			this.transform.rotation = Quaternion.LookRotation(target);
			//this.transform.LookAt(target);

			if (enemyHealth <= 0) {
				death ();
			}
		}

	}

	void death()
	{
		this.GetComponent<Rigidbody> ().isKinematic = false;
		this.gameObject.SetActive (false);
	}

}
