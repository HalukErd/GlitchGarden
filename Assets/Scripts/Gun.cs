using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] GameObject projectile, gun;
	[SerializeField] float projectileSpeed = 1f;
	AttackerSpawner myLaneSpawner;
	Animator animator;
	private void Start()
	{
		animator = GetComponent<Animator>();
		SetLaneSpawner();
	}

	private void Update()
	{
		if(IsAttackerInLane())
		{
			animator.SetBool("isAttacking", true);
		}
		else
		{
			animator.SetBool("isAttacking", false);
		}
	}

	private void SetLaneSpawner()
	{
		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

		foreach (AttackerSpawner spawner in spawners)
		{
			bool IsCloseEnough = 
				(Mathf.Abs(spawner.transform.position.y - transform.position.y) 
				 <= Mathf.Epsilon);
			if (IsCloseEnough)
			{
				myLaneSpawner = spawner;
			}
		}
	}

	private bool IsAttackerInLane()
	{
		if (myLaneSpawner.transform.childCount <= 0)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public void Fire()
	{
		GameObject cloneProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
		//cloneProjectile.transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
		cloneProjectile.transform.parent = transform;
	}
}
