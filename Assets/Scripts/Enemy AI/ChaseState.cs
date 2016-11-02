using UnityEngine;
using System.Collections;

public class ChaseState : IEnemyState 

{

	private readonly EnemyAi enemy;


	public ChaseState (EnemyAi statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		if (!enemy.isDead ()) {
			Look ();
			Chase ();

		} else {
			enemy.meshRendererFlag.material.color = Color.black;
			ToDeathState ();
		}



	}

	public void OnTriggerEnter (Collider other)
	{

	}

	public void ToPatrolState()
	{

	}

	public void ToAlertState()
	{

	}

	public void ToChaseState()
	{

	}

	public void ToAttackState()
	{
	}

	public void ToDeathState()
	{
		
	}

	private void Look()
	{
		RaycastHit hit;
		Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.reticle.transform.position;
		if (Physics.Raycast (enemy.reticle.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
			enemy.chaseTarget = hit.transform;

		}
	

	}

	private void Chase()
	{
		float dist = Vector3.Distance (enemy.transform.position, enemy.chaseTarget.position);

		if (dist > 4.0f) {
			enemy.navMeshAgent.destination = enemy.chaseTarget.position;
			enemy.navMeshAgent.Resume ();
		} else {
			enemy.navMeshAgent.Stop ();
		}

		enemy.meshRendererFlag.material.color = Color.red;

	}


}
