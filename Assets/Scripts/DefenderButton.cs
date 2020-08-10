using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
	[SerializeField] Defender defenderPrefab;
	Text textComponent;
	
	void Start()
	{
		LabelButtonWithCost();
	}

	void LabelButtonWithCost()
	{
		textComponent = GetComponentInChildren<Text>();
		if (!textComponent)
		{
			Debug.LogError(name + "has no cost text");
		}
		else
		{
			textComponent.text = defenderPrefab.GetStarCost().ToString();
		}
	}

	void OnMouseDown()
	{
		var buttons = FindObjectsOfType<DefenderButton>();
		foreach (var button in buttons)
		{
			button.GetComponent<SpriteRenderer>().color = new Color32(75, 75, 75, 255);
		}
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
	}
	
	
}

