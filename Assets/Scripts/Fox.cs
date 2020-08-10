using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Gravestone>())
		{
			GetComponent<Animator>().SetTrigger("jump");
		}
		else if (other.GetComponent<Defender>())
		{
			GetComponent<Attacker>().Attack(other.gameObject);
		}
	}
}
