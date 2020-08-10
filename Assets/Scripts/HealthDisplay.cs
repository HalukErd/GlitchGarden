using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

	[SerializeField] int health = 50;

	Text textComponent;  
	// Use this for initialization
	void Start ()
	{
		textComponent = GetComponent<Text>();
		UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateDisplay();
	}

	void UpdateDisplay()
	{
		textComponent.text = health.ToString();
	}

	public void DealDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			FindObjectOfType<LevelController>().HandleLoseCondition();
		}
	}
}
