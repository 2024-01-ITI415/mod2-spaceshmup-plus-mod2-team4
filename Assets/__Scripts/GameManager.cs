using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn
    public float spawnInterval = 10f; // Time between spawns, in seconds
    public int startSpawnCount = 1; // Initial number of enemies to spawn
    public float multiplier = 2; // Multiplier to increase spawn count
    public float increaseInterval = 120f; // Time interval to increase spawn count, in seconds

    private float nextIncreaseTime;
    private int currentSpawnCount;

    void Start()
    {
        currentSpawnCount = startSpawnCount;
        nextIncreaseTime = Time.time + increaseInterval;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < currentSpawnCount; i++)
            {
                // Select a random enemy prefab
                GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            }

            if (Time.time >= nextIncreaseTime)
            {
                currentSpawnCount = Mathf.FloorToInt(currentSpawnCount * multiplier);
                nextIncreaseTime += increaseInterval;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
