using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

	[SerializeField] float health;
	[SerializeField] GameObject explosionVFX;
	
	void Update () {
			
	}

	public void DealDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			TriggerDeathVFX();
			Destroy(gameObject);
		}
	}

	void TriggerDeathVFX()
	{
		if(!explosionVFX) { return;}
		GameObject cloneVFX = Instantiate(explosionVFX, transform.position, transform.rotation);
		Destroy(cloneVFX, 1f);
	}
}
