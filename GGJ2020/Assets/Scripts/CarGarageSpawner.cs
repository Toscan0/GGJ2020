using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarGarageSpawner : MonoBehaviour
{

    public GameObject[] garages;
    public GameObject[] barracas;
    public GameObject car;
    public GameObject specialCar;
    public GameObject ferramenta;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCars", 0, 1);
        barracas = GameObject.FindGameObjectsWithTag("Barraca");
    }

    void SpawnCars()
    {
        GameObject garage = garages[Random.Range(0, 6)];
        var specialCarProbability = Random.Range(0, 100);
        if (!garage.GetComponent<GaragemManager>().hasCar)
        {
            if (specialCarProbability < 16)
            {
                if (garage.name == "Cube" || garage.name == "Cube (1)" || garage.name == "Cube (2)")
                {
                    car.transform.localScale = new Vector3(58f, 58f, 58f);
                    garage.GetComponent<GaragemManager>().car = Instantiate(specialCar, garage.transform.position, Quaternion.AngleAxis(-90, new Vector3(0, 1, 0)));

                }
                else
                {
                    car.transform.localScale = new Vector3(58f, 58f, 58f);
                    garage.GetComponent<GaragemManager>().car = Instantiate(specialCar, garage.transform.position, Quaternion.AngleAxis(90, new Vector3(0, 1, 0)));
                }

                var barraca = barracas[Random.Range(0, barracas.Length)];
                while (barraca.gameObject.GetComponent<BarracaManager>().hasFerramenta)
                {
                    barraca = barracas[Random.Range(0, barracas.Length)];
                }
                barraca.gameObject.GetComponent<BarracaManager>().ferramenta = Instantiate(ferramenta, barraca.transform.position + new Vector3(0,1,0), Quaternion.AngleAxis(-90, new Vector3(0, 1, 0)));
                garage.GetComponent<GaragemManager>().barraca = barraca;

            }
            else
            {
                if (garage.name == "Cube" || garage.name == "Cube (1)" || garage.name == "Cube (2)")
                {
                    car.transform.localScale = new Vector3(58f, 58f, 58f);
                    garage.GetComponent<GaragemManager>().car = Instantiate(car, garage.transform.position,
                        Quaternion.AngleAxis(-90, new Vector3(0, 1, 0)));

                }
                else
                {
                    car.transform.localScale = new Vector3(58f, 58f, 58f);
                    garage.GetComponent<GaragemManager>().car = Instantiate(car, garage.transform.position,
                        Quaternion.AngleAxis(90, new Vector3(0, 1, 0)));
                }
            }

            garage.GetComponent<GaragemManager>().hasCar = true;
            garage.GetComponent<GaragemManager>().EnableIcon();
            garage.GetComponent<GaragemManager>().StartTimer();
        }

        
    }
}
