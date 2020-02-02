using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarGarageSpawner : MonoBehaviour
{

    public GameObject[] garages;
    public GameObject[] barracas;
    public GameObject car;
    public GameObject specialCar;
    public GameObject dadCar;
    public GameObject sonCar;

    public Sprite toolSprite;
    public Sprite dadSprite;
    public Sprite sonSprite;

    public GameObject ferramenta;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCars", 1.5f, 3);
        barracas = GameObject.FindGameObjectsWithTag("Barraca");

        Random.InitState(42);
    }

    void SpawnCars()
    {
        GameObject garage = garages[Random.Range(0, 6)];
        var probability = Random.Range(0, 100);
        Sprite sprite = null;
        if (!garage.GetComponent<GaragemManager>().hasCar)
        {
            if (probability < 16)
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
                while (barraca.gameObject.GetComponent<BarracaManager>().ferramenta != null)
                {
                    barraca = barracas[Random.Range(0, barracas.Length)];
                }
                barraca.gameObject.GetComponent<BarracaManager>().ferramenta = Instantiate(ferramenta, barraca.transform.position + new Vector3(0, 1.5f, 0), Quaternion.AngleAxis(-90, new Vector3(0, 1, 0)));
                garage.GetComponent<GaragemManager>().barraca = barraca;
                sprite = toolSprite;

            }
            else if (probability > 15 && probability < 26)
            {
                // Create Dad specific car
                if (garage.name == "Cube" || garage.name == "Cube (1)" || garage.name == "Cube (2)")
                {
                    car.transform.localScale = new Vector3(58f, 58f, 58f);
                    garage.GetComponent<GaragemManager>().car = Instantiate(dadCar, garage.transform.position,
                        Quaternion.AngleAxis(-90, new Vector3(0, 1, 0)));

                }
                else
                {
                    car.transform.localScale = new Vector3(58f, 58f, 58f);
                    garage.GetComponent<GaragemManager>().car = Instantiate(dadCar, garage.transform.position,
                        Quaternion.AngleAxis(90, new Vector3(0, 1, 0)));
                }

                sprite = dadSprite;
            }
            else if (probability > 25 && probability < 36)
            {
                // Create Son specific car
                if (garage.name == "Cube" || garage.name == "Cube (1)" || garage.name == "Cube (2)")
                {
                    car.transform.localScale = new Vector3(58f, 58f, 58f);
                    garage.GetComponent<GaragemManager>().car = Instantiate(sonCar, garage.transform.position,
                        Quaternion.AngleAxis(-90, new Vector3(0, 1, 0)));

                }
                else
                {
                    car.transform.localScale = new Vector3(58f, 58f, 58f);
                    garage.GetComponent<GaragemManager>().car = Instantiate(sonCar, garage.transform.position,
                        Quaternion.AngleAxis(90, new Vector3(0, 1, 0)));
                }

                sprite = sonSprite;
            }
            else {
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
            garage.GetComponent<GaragemManager>().EnableIcon(sprite);
            garage.GetComponent<GaragemManager>().StartTimer();
            AudioManager.PlaySound("Horn", Camera.main.transform.position);
        }

        
    }
}
