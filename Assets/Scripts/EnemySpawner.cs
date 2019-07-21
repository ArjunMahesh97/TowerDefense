using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemies());
	}
	
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
