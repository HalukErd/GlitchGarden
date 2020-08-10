using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	[SerializeField] float timeToWait = 4;
	int currentSceneIndex;

	// Use this for initialization
	void Start ()
	{
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentSceneIndex == 0)
		{
			StartCoroutine(WaitAndLoad());
		}
	}
	IEnumerator WaitAndLoad()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene("Start");
		
	}

	public void LoadLevel1Scene()
	{
		SceneManager.LoadScene(2);
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene(currentSceneIndex + 1);
	}

	public void LoadLoseScene()
	{
		SceneManager.LoadScene("LoseScreen");
	}
	
	public void LoadMainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Start");
	}
	
	public void LoadOptionsScene()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Options");
	}

	public void RestartScene()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(currentSceneIndex);
	}

	public void Quit()
	{
		Application.Quit();
		
	}
	
	
}
