using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	[SerializeField] GameObject winLabel;
	[SerializeField] GameObject loseLabel;
	[SerializeField] float timeAfterWin = 4;
	int numberOfAttackers = 0;
	bool levelTimerFinished = false;
	
	// Use this for initialization
	void Start ()
	{
		if(winLabel)
		{
			winLabel.SetActive(false);
		}

		if (loseLabel)
		{
			loseLabel.SetActive(false);
		}
	}

	public void AttackerSpawned()
	{
		numberOfAttackers++;
		
	}
	
	public void AttackerKilled()
	{
		numberOfAttackers--;
		if (levelTimerFinished && numberOfAttackers <= 0)
		{
			
			StartCoroutine(HandleWinCondition());
			
		}
	}

	public void HandleLoseCondition()
	{
		loseLabel.SetActive(true);
		Time.timeScale = 0.1f;
	}

	IEnumerator HandleWinCondition()
	{
		winLabel.SetActive(true);
		GetComponent<AudioSource>().Play();
		Debug.Log("End Level");
		yield return new WaitForSeconds(timeAfterWin);
		FindObjectOfType<LevelLoader>().LoadNextScene();
	}

	public void SetTimerFinished()
	{
		levelTimerFinished = true;
		StopSpawners();
	}

	void StopSpawners()
	{
		var spawners = FindObjectsOfType<AttackerSpawner>();
		foreach (var spawner in spawners)
		{
			spawner.StopSpawning();
			Debug.Log(spawner + " is called as stop method");
		}
	}
}
