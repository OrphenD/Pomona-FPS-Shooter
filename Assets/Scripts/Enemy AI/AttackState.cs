using UnityEngine;
using System.Collections;

public class AttackState : IEnemyState 

{

	private readonly EnemyAi enemy;


	public AttackState (EnemyAi statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Chase ();

		if (enemy.isDead ()) {
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
