using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs;
    private float[] spawnRangeX = { -10, 0, 10};

    // Start is called before the first frame update
    void Start()
    {
        
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
}
