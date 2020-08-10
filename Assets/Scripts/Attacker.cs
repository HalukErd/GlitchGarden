
using System;
using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{

	float currentSpeed = 0f;
	GameObject targetDefender;
	GameObject currentTarget;

	void Awake()
	{
		FindObjectOfType<LevelController>().AttackerSpawned();
	}

	void OnDestroy()
	{
		
		LevelController levelController = FindObjectOfType<LevelController>();
		if (levelController)
		{
			levelController.AttackerKilled();
		}
	}

	void Update ()
	{
		Move();
		UpdateAnimationState();
	}

	void UpdateAnimationState()
	{
		if (!currentTarget)
		{
			GetComponent<Animator>().SetBool("isAttacking", false);
		}
	}

	void Move()
	{
		transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
	}

	public void SetMovementSpeed(float speed)
	{
		currentSpeed = speed;
	}

	public void Attack(GameObject target)
	{
		if (target)
		{
			GetComponent<Animator>().SetBool("isAttacking", true);
			currentTarget = target;
			
		}
		
	}
	
	public void StrikeCurrentTarget(float damage)
	{
		if (!currentTarget) {return;}

		Health health = currentTarget.GetComponent<Health>();
		health.DealDamage(damage);
	}

	
}
