using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseArea : MonoBehaviour
{

	HealthDisplay healthDisplay;

	void Start()
	{
		healthDisplay = FindObjectOfType<HealthDisplay>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		healthDisplay.DealDamage(1);
		Destroy(other.gameObject);
	}
}
