using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	Defender defender;
	StarDisplay starDisplay;
	const string DEFENDERS_PARRENT_NAME = "Defenders";
	GameObject defendersParent;

	void Start()
	{
		starDisplay = FindObjectOfType<StarDisplay>();
		CreateDefendersParent();
	}

	private void CreateDefendersParent()
	{
		defendersParent = GameObject.Find(DEFENDERS_PARRENT_NAME);
		if (!defendersParent)
		{
			defendersParent = new GameObject(DEFENDERS_PARRENT_NAME);
		}
	}

	void OnMouseDown()
	{
		SpawnDefender(GetSquareClicked());
	}

	public void SetSelectedDefender(Defender defenderToSelect)
	{
		defender = defenderToSelect;
	}

	private Vector2 GetSquareClicked()
	{
		Vector2 mousePosInScreen = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosInScreen);
		Vector2 roundedPos = fitPosToGrid(mousePosInWorld);
		return roundedPos;
	}

	private Vector2 fitPosToGrid(Vector2 rawPos)
	{
		float newX = Mathf.RoundToInt(rawPos.x);
		float newY = Mathf.RoundToInt(rawPos.y);
		return new Vector2(newX, newY);
	}
	
	private void SpawnDefender(Vector2 roundedMousePosInWorld)
	{
		if (starDisplay.SpendStars(defender.GetStarCost()))
		{
			Defender cloneDefender = Instantiate(defender, roundedMousePosInWorld, Quaternion.identity) as Defender;
			cloneDefender.transform.parent = defendersParent.transform;
		}
	}

}
