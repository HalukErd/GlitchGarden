using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

	[SerializeField] Slider volumeSlider;
	[SerializeField] float defaultVolume = .8f;
	
	[SerializeField] Slider difficultySlider;
	[SerializeField] float defaultDifficulty = 0f;
	// Use this for initialization
	void Start ()
	{
		Debug.Log("options controller set slider value: " + PlayerPrefsController.GetMasterVolume());
		volumeSlider.value = PlayerPrefsController.GetMasterVolume();
		difficultySlider.value = PlayerPrefsController.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update ()
	{
		var musicPlayer = FindObjectOfType<MusicPlayer>();
		if (musicPlayer)
		{
			musicPlayer.SetVolume(volumeSlider.value);
		}
		else
		{
			Debug.LogWarning("Couldn't find music player.");
		}
	}

	public void SaveAndExit()
	{
		PlayerPrefsController.SetMasterVolume(volumeSlider.value);
		PlayerPrefsController.SetDifficulty(difficultySlider.value);
		FindObjectOfType<LevelLoader>().LoadMainMenu();
	}

	public void SetDefaults()
	{
		volumeSlider.value = defaultVolume;
		difficultySlider.value = defaultDifficulty;
	}
}
