using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public float spawnDelay = .3f;
    public float minSpawnDelay;

    public GameObject[] Cars;

    public Transform[] spawnPoints;

    float nextTimeToSpawn = 0f;

    void Update()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            SpawnCar();
            nextTimeToSpawn = Time.time + spawnDelay * Random.Range(1, 3);

            if(nextTimeToSpawn < minSpawnDelay)
            {
                nextTimeToSpawn = minSpawnDelay;
            }
        }
    }

    void SpawnCar()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        randomIndex = Random.Range(0, Cars.Length);
        GameObject car = Cars[randomIndex];

        car.transform.localScale = new Vector3(58f, 58f, 58f);
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }

}
