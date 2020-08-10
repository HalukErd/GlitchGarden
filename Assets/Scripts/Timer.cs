using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	[Tooltip("Level Timer In Seconds")] [SerializeField]
	float levelTimer = 10f;

	bool triggeredLevelFinished = false;
	Slider slider;
	// Use this for initialization
	void Start ()
	{
		slider = GetComponent<Slider>();

		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(triggeredLevelFinished) { return; }
		slider.value = Time.timeSinceLevelLoad / levelTimer;
		bool timerFinished = (Time.timeSinceLevelLoad >= levelTimer);
		if (timerFinished)
		{
			FindObjectOfType<LevelController>().SetTimerFinished();
			triggeredLevelFinished = true;
			Debug.Log(timerFinished);
		}
	}
}
