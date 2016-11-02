using UnityEngine;
using System.Collections;

public class DeathState : IEnemyState 

{

	private readonly EnemyAi enemy;
	private float waitTilRemove = 0.0f;

	public DeathState (EnemyAi statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		death ();
	}

	public void OnTriggerEnter (Collider other)
	{

	}

	public void ToPatrolState(){
	}

	public void ToAlertState(){
	}

	public void ToChaseState(){
	}

	public void ToAttackState (){
	}

	public void ToDeathState()
	{
	}
		
	public void death()
	{
		enemy.GetComponent<Rigidbody> ().isKinematic = false;
		enemy.GetComponent<GameObject>().SetActive (false);
	}
}

