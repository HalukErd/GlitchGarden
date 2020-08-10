using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AttackerSpawner : MonoBehaviour
{
	[SerializeField] float minSpawnDelay = 1f;
	[SerializeField] float maxSpawnDealy = 5f;
	[SerializeField] Attacker[] attackerPrefabs;
	bool spawn = true;
	// Use this for initialization
	IEnumerator Start () {			
		while (spawn)		
		{
			yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDealy));
			spawnAttacker();
		}
	}
	
	public void StopSpawning()
	{
		spawn = false;
	}

	void spawnAttacker()
	{
		int randomIndex = Mathf.RoundToInt(Random.Range(0, attackerPrefabs.Length));
		Spawn(attackerPrefabs[randomIndex]);
	}

	void Spawn(Attacker attackerPrefab)
	{
		Attacker cloneAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation);
		cloneAttacker.transform.parent = transform;
	}
}
