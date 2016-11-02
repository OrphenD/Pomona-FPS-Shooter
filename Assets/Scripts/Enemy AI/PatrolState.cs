using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState 

{
	private readonly EnemyAi enemy;
	private int nextWayPoint;

	public PatrolState (EnemyAi statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		
		if (!enemy.isDead ()) {
			Look ();
			Patrol ();

			if (enemy.isDamaged ()) {
				ToChaseState ();
			}

		} else {
			enemy.meshRendererFlag.material.color = Color.black;
			ToDeathState ();
		}
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			ToAlertState ();
	}

	public void ToPatrolState()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToAlertState()
	{
	}

	public void ToChaseState()
	{
		enemy.currentState = enemy.chaseState;
	}

	public void ToAttackState(){
	}

	public void ToDeathState()
	{
	}

	private void Look()
	{
		RaycastHit hit;
		if (Physics.Raycast (enemy.reticle.transform.position, enemy.reticle.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
			enemy.chaseTarget = hit.transform;
			ToChaseState();
		}
	}

	void Patrol ()
	{
		enemy.meshRendererFlag.material.color = Color.green;
		enemy.navMeshAgent.destination = enemy.wayPoints [nextWayPoint].position;
		enemy.navMeshAgent.Resume ();

		Debug.Log("WayPoint:" + nextWayPoint);

		if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending) 
		{
			nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
			Debug.Log("Im Here!");
		}

	}
}
