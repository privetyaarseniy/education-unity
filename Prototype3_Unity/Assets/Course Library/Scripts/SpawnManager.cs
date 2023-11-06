using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    readonly Vector3 spawnPos = new Vector3(25, 0, 0);
    public GameObject obstaclePrefab;
    readonly float startDelay = 2f;
    readonly float delay = 1.5f;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstacle");
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObstacle() 
    {
        yield return new WaitForSeconds(startDelay);

        while (!player.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            yield return new WaitForSeconds(delay);
        }
    }
}
