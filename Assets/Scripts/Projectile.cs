using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

	[SerializeField] float projectileSpeed = 1f;
	[SerializeField] int rotationSpeed = 180;
	[SerializeField] int damage = 100;
	
	void Update () {
		transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
//		transform.RotateAround(Vector3.forward , Time.deltaTime * projectileSpeed);
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		var health = other.GetComponent<Health>();
		var attacker = other.GetComponent<Attacker>();
		
		if (health && attacker)
		{
			other.GetComponent<Health>().DealDamage(damage);
			Destroy(gameObject);
		}
	}
}
