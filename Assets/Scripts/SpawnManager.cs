using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public GameObject healthCollectible;
    private float[] spawnRangeX = { -10, 0, 10};
    private float carStartDelay = 2;
    private float carSpawnInterval = 1;

    private float healthStartDelay = 10;
    private float healthSpawnInterval = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomCar", carStartDelay, carSpawnInterval);
        InvokeRepeating("SpawnHealthCollectible", healthStartDelay, healthSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomCar();
        }
    }

    void SpawnRandomCar()
    {
        //Get random cars and positions from given range
        int carIndex = Random.Range(0, carPrefabs.Length);
        int rnd = Random.Range(0, spawnRangeX.Length);
        float xPosition = spawnRangeX[rnd];

        //Spawn random cars at random lanes
        Vector3 spawnPos = new Vector3(xPosition, 0, 40);
        Instantiate(carPrefabs[carIndex], spawnPos, carPrefabs[carIndex].transform.rotation);
    }

    void SpawnHealthCollectible()
    {
        Debug.Log("health spawned");

        int rnd = Random.Range(0, spawnRangeX.Length);
        float xPosition = spawnRangeX[rnd];

        Vector3 spawnPos = new Vector3(xPosition, 2.5f, 40);
        Instantiate(healthCollectible, spawnPos, healthCollectible.transform.rotation);
    }
}
