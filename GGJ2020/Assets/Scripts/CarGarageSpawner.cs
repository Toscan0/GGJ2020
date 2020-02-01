using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarGarageSpawner : MonoBehaviour
{

    public GameObject[] garages;
    public GameObject car;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCars", 0, 1);
    }

    void SpawnCars()
    {
        GameObject garage = garages[Random.Range(0, 6)];
        if (!garage.GetComponent<GaragemManager>().hasCar)
        {
            if (garage.name == "Cube" || garage.name == "Cube (1)" || garage.name == "Cube (2)")
            {
                car.transform.localScale = new Vector3(58f, 58f, 58f);
                garage.GetComponent<GaragemManager>().car = Instantiate(car, garage.transform.position, Quaternion.AngleAxis(-90, new Vector3(0, 1, 0)));

            }
            else
            {
                car.transform.localScale = new Vector3(58f, 58f, 58f);
                garage.GetComponent<GaragemManager>().car = Instantiate(car, garage.transform.position, Quaternion.AngleAxis(90, new Vector3(0, 1, 0)));
            }
            garage.GetComponent<GaragemManager>().hasCar = true;
            garage.GetComponent<GaragemManager>().EnableIcon();
            garage.GetComponent<GaragemManager>().StartTimer();
        }

        
    }
}
