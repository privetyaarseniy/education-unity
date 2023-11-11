using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    readonly Vector3 spawnPos = new Vector3(25, 0, 0);
    public float spawnRange;
    public GameObject[] prefabs = new GameObject[3];
    readonly float startDelay = 2f;
    readonly float delay = 1.5f;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle() 
    {  
        if (!player.gamePause)
        {
            int prefabsNum = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[prefabsNum], spawnPos + new Vector3(Random.Range(-spawnRange, spawnRange), 0, 0), prefabs[prefabsNum].transform.rotation);
        }
    }
}
