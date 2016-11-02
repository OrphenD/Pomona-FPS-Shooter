using UnityEngine;
using System.Collections;

public class EnemyBody : MonoBehaviour 
{
	Transform parentToFollow;
	private GameObject player;

	void Awake()
	{
		parentToFollow = transform.parent;
		transform.parent = null;


	}

	void Start () 
	{
		GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null)
		{
			player = playerObject;
		}
		if (playerObject == null)
		{
			Debug.Log ("Cannot find 'Player'");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = parentToFollow.position;

		Vector3 target = player.transform.position - transform.position;
		target.y = 0;
		this.transform.rotation = Quaternion.LookRotation(target);
	}
}
