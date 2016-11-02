using UnityEngine;
using System.Collections;

public class EnemyAi: MonoBehaviour 
{

	public Transform[] wayPoints;
	public Transform reticle;

	public float searchingTurnSpeed = 180f;
	public float searchingDuration = 4f;
	public float sightRange = 30f;
	public Vector3 offset = new Vector3 (0,.5f,0);
	public float enemyHealth;
	public float currentHealth;

	public MeshRenderer meshRendererFlag;

	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public AttackState attackState;
	[HideInInspector] public DeathState deathState;
	[HideInInspector] public NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Awake()
	{
		chaseState = new ChaseState (this);
		patrolState = new PatrolState (this);
		attackState = new AttackState (this);
		deathState = new DeathState (this);

		navMeshAgent = GetComponent<NavMeshAgent> ();

	}

	void Start () 
	{
		currentState = patrolState;
		currentHealth = enemyHealth;

		GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null)
		{
			chaseTarget = playerObject.transform;
		}
		if (playerObject == null)
		{
			Debug.Log ("Cannot find 'Player'");
		}
	}

	// Update is called once per frame
	void Update () 
	{
		currentState.UpdateState ();
	}

	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter (other);
	}

	public bool isDamaged()
	{
		return currentHealth < enemyHealth;
	}

	public bool isDead()
	{
		return currentHealth <= 0;
	}

	public void takeDamage(float dmg)
	{
		currentHealth -= dmg;
	}
}
