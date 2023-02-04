using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private float spawnRange = 13.5f;
    private int enemyNumber = 4;
    private int collectibleNumber = 15;
    public int enemyCount;

    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    public GameObject collectiblePrefab;


    void Start()
    {
        // Changes the position of the player to a random position
        PlayerSpawn();

        // Spawns desired amount of enemies
        for (int i = 0; i < enemyNumber; i++)
        {
            Instantiate(enemyPrefab, EnemySpawnPosition(), enemyPrefab.transform.rotation);
        }

        // Spawns desired amount of collectibles
        for (int i = 0; i < collectibleNumber; i++)
        {
            Instantiate(collectiblePrefab, CollectibleSpawnPosition(), collectiblePrefab.transform.rotation);
        }
    }

    // Changes the position of the player to a random position when it is called.
    void PlayerSpawn()
    {
        float playerSpawnPosX = Random.Range(-spawnRange, spawnRange);
        float playerSpawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 playerRandomPos = new Vector3(playerSpawnPosX, 1, playerSpawnPosZ);

        playerPrefab.transform.position = playerRandomPos;
    }


    // Returns a random coordinate for the enemy to spawn.
    private Vector3 EnemySpawnPosition()
    {
        float enemySpawnPosX = Random.Range(-spawnRange, spawnRange);
        float enemySpawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 enemyRandomPos = new Vector3(enemySpawnPosX, 1, enemySpawnPosZ);

        return enemyRandomPos;
    }

    // Returns a random coordinate for the colectible to spawn.
    private Vector3 CollectibleSpawnPosition()
    {
        float collectibleSpawnPosX = Random.Range(-spawnRange, spawnRange);
        float collectibleSpawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 collectibleRandomPos = new Vector3(collectibleSpawnPosX, 0.15f, collectibleSpawnPosZ);

        return collectibleRandomPos;
    }
}
