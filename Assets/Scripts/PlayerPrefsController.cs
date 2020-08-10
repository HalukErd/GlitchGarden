using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{

	const string MASTER_VOLUME_KEY = "master volume";
	
	const string DIFFICULTY_KEY = "difficulty";

	const float MIN_VALUE = 0f;
	const float MAX_VALUE = 1f;

	const float MIN_DIFFICULTY = 0f;
	const float MAX_DIFFICULTY = 2f;
	
	

	public static void SetDifficulty(float difficulty)
	{
		if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
		{
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		}
		else
		{
			Debug.LogError("Difficulty setting is not in range");
		}
	}
	
	public static float GetDifficulty()
	{
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}

	public static void SetMasterVolume(float volume)
	{
		if (volume >= MIN_VALUE && volume <= MAX_VALUE)
		{
			Debug.Log("Master Volume set to: " + volume);
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
		else
		{
			Debug.LogError("Master Volume is out of range now");
		}
	}

	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
}
