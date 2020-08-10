using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Defender>() != null)
		{
			GetComponent<Attacker>().Attack(other.gameObject);
		}
		
	}

//	void OnTriggerExit(Collider other)
//	{
//		other.GetComponent<Animator>().SetBool("isAttacking", false);
//		Debug.Log("exit trigger");
//	}
}
