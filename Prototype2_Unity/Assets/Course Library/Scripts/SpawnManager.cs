using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject parent;
    public GameObject[] animalPrefabsVertical;
    private readonly float spawnRangeXVertical = 20f;
    private readonly float[] spawnPointsXHorizontal = new float[2] { -30f, 30f };
    private readonly float spawnRangeUpperZHorizontal = 15f;
    private readonly float spawnRangeLowerZHorizontal = 4f;
    private readonly float[] rotationHorizontal = new float[2] { 90f, -90f };
    private readonly float startDelayVertical = 2f;
    private readonly float spawnInterval = 1.5f;
    private readonly float startDelayHorizontal = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomAnimalVertical());
        StartCoroutine(SpawnRandomAnimalHorizontal());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRandomAnimalVertical()
    {
        yield return new WaitForSeconds(startDelayVertical);

        while (true)
        {
            int animalIndex = Random.Range(0, animalPrefabsVertical.Length);
            Instantiate(animalPrefabsVertical[animalIndex], new Vector3(Random.Range(-spawnRangeXVertical, spawnRangeXVertical), 0, 20), 
                animalPrefabsVertical[animalIndex].transform.rotation, parent.transform);
            yield return new WaitForSeconds(spawnInterval);

        }
    }

    IEnumerator SpawnRandomAnimalHorizontal()
    {
        yield return new WaitForSeconds(startDelayHorizontal);

        while(true)
        {
            int animalIndex = Random.Range(0, animalPrefabsVertical.Length);
            int animalSide = Random.Range(0, spawnPointsXHorizontal.Length); //Both side and rotation arrays use this to choose direction
            Instantiate(animalPrefabsVertical[animalIndex], new Vector3(spawnPointsXHorizontal[animalSide], 0, Random.Range(spawnRangeLowerZHorizontal, spawnRangeUpperZHorizontal)),
                Quaternion.Euler(new Vector3(animalPrefabsVertical[animalIndex].transform.rotation.x, rotationHorizontal[animalSide],
                animalPrefabsVertical[animalIndex].transform.rotation.z)), parent.transform);
            yield return new WaitForSeconds(spawnInterval);
        }

    }
}
