using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health = 100;
	// Use this for initialization

	public void TakeDamage()
	{
		//all enemies extending the enemy class can access this attack
		health -= 10;

	}

	public virtual void DoAttack()
	{
		Debug.Log("doattack");
		//all enemies extending the Enemy class can access this attack
	
	}

}
