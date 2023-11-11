using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    public float spawnRangeX = 9;
    public float spawnRangeZ = 9;

    int waveNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectsOfType<Enemy>().Length == 0)
        {
            SpawnEnemyWave(++waveNum);
            Instantiate(powerupPrefab, GenerateSpawnPos(spawnRangeX, spawnRangeZ), enemyPrefab.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPos(float x, float z)
    {
        return new Vector3(Random.Range(-x, x), 0, Random.Range(-z, z));
    }

    void SpawnEnemyWave(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(spawnRangeX, spawnRangeZ), enemyPrefab.transform.rotation);
        }
    }
}
