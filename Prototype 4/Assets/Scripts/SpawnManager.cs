using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerupPrefabs;
    public GameObject bossPrefab;
    private float spawnRange = 9f;
    private int enemyCount;
    private int waveNumber = 1;

    private bool inABossFight = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0 && PlayerController.isAlive)
        {
            waveNumber++;
            if (!inABossFight)
            {
                SpawnEnemyWave(waveNumber);
            }
            else
            {
                SpawnBoss();
            }
        }
        if (waveNumber % 5 == 0)
        {
            inABossFight = true;
        }
        else
        {
            inABossFight = false;
        }
    }

    public void SpawnEnemyWave(int numberOfEnemies)
    {
        GameObject powerupPrefab = powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        for (int i = 0;i< numberOfEnemies; i++)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnPositionX, 0f, spawnPositionZ);
        return randomPosition;
    }

    void SpawnBoss()
    {
        Instantiate(bossPrefab, GenerateSpawnPosition() + new Vector3(0f, 7.1f, 0f), bossPrefab.transform.rotation);
    }
}
