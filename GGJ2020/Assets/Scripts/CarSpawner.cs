using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public float spawnDelay = .3f;

    public GameObject[] Cars;

    public Transform[] spawnPoints;

    float nextTimeToSpawn = 0f;

    void Update()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            SpawnCar();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void SpawnCar()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        randomIndex = Random.Range(0, Cars.Length);
        Debug.Log(Cars.Length);
        Debug.Log(randomIndex);
        GameObject car = Cars[randomIndex];

        car.transform.localScale = new Vector3(58f, 58f, 58f);
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }

}
