using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs
    public float spawnInterval = 5f; // Initial interval between spawns
    public int startSpawnCount = 1; // Initial number of enemies to spawn at once
    public float increaseInterval = 60f; // Interval to increase spawn count (every minute)
    public int increaseAmount = 1; // Amount to increase spawn count by
    private float nextSpawnTime;
    private float nextIncreaseTime;
    private int currentSpawnCount;

    void Start()
    {
        currentSpawnCount = startSpawnCount;
        nextSpawnTime = Time.time + spawnInterval;
        nextIncreaseTime = Time.time + increaseInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            for (int i = 0; i < currentSpawnCount; i++)
            {
                SpawnEnemy();
            }
            nextSpawnTime = Time.time + spawnInterval;
        }

        if (Time.time >= nextIncreaseTime)
        {
            currentSpawnCount += increaseAmount; // Increase the spawn count
            nextIncreaseTime = Time.time + increaseInterval; // Set the next time to increase spawn count
        }
    }

    void SpawnEnemy()
    {
        // Check if the enemyPrefabs array is not empty
        if (enemyPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], GenerateSpawnPosition(), Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Enemy prefabs array is empty. Assign enemy prefabs in the inspector.");
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        // Generate a random position within a specified range
        // This example just provides a simple method, adjust according to your game's needs
        float spawnPosX = Random.Range(-10, 10);
        float spawnPosY = Random.Range(-10, 10); // Assuming a 2D game or enemies that spawn at ground level
        float spawnPosZ = 0;
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }
}
