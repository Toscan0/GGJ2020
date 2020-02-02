using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RepairCar : MonoBehaviour
{
    public bool hitBox = false;
    public bool hitCar = false;
    public bool hitSpecialCar = false;
    public bool sRepair = false;
    public bool hasFerramenta = false;
    GameObject box;
    GameObject car;
    public ProgressBarCircle pbc;
    Color tmp;



    private void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Garagem":
                if (collision.gameObject.GetComponent<GaragemManager>().hasCar && !sRepair)
                {
                    car = collision.gameObject.GetComponent<GaragemManager>().car;
                    PlayerMovement movement = this.transform.GetComponent<PlayerMovement>();

                    if ((car.CompareTag("SpecialCar") && !hasFerramenta) || 
                       (car.CompareTag("DadCar") && movement.playerId != 1) ||
                       (car.CompareTag("SonCar") && movement.playerId != 2))
                    {
                        return;
                    }
                    box = collision.gameObject;
                    this.transform.GetComponent<PlayerMovement>().halt = true;
                    pbc = box.GetComponentInChildren<Canvas>().GetComponentInChildren<ProgressBarCircle>();
                    pbc.BarValue = 1;
                    tmp = box.GetComponent<Renderer>().material.color;
                    tmp.a = 1.0f;
                    box.GetComponent<Renderer>().material.color = tmp;
                    sRepair = true;
                }
                break;
            default:
                break;
        }

        /*if (collision.gameObject.GetComponent<GaragemManager>().hasCar)
        {
            box = collision.gameObject;
            this.transform.GetComponent<PlayerMovement>().speedModifier = 0;
            pbc = box.GetComponentInChildren<Canvas>().GetComponentInChildren<ProgressBarCircle>();
            pbc.BarValue = 0;
            tmp = box.GetComponent<Renderer>().material.color;
            tmp.a = 1.0f;
            box.GetComponent<Renderer>().material.color = tmp;
            sRepair = true;
        }*/

        /*Collider[] collidersHit =  Physics.OverlapSphere(this.transform.position, 1);
        foreach(Collider collider in collidersHit)
        {
            if(collider.CompareTag("Garagem"))
            {
                hitBox = true;
                box = collider.gameObject;
            
            }
            if(collider.name == "Car_1_Green(Clone)")
            {
                hitCar = true;
                car = collider.gameObject;
            }

            if (collider.CompareTag("SpecialCar"))
            {
                hitSpecialCar = true;
                car = collider.gameObject;
            }
            if((hitBox && hitCar) || (hitBox && hitSpecialCar && hasFerramenta))
            {
                var a = box.GetComponentInChildren<Canvas>();
                pbc = a.GetComponentInChildren<ProgressBarCircle>();
                pbc.BarValue = 0;
                tmp = box.GetComponent<Renderer>().material.color;
                tmp.a = 1.0f;
                box.GetComponent<Renderer>().material.color = tmp;
                sRepair = true;
                break;
            }
        }*/
    }

    private void OnTriggerStay(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Garagem":

                PlayerMovement movement = this.transform.GetComponent<PlayerMovement>();
                car = collision.gameObject.GetComponent<GaragemManager>().car;

                if (collision.gameObject.GetComponent<GaragemManager>().hasCar && ((car.CompareTag("SpecialCar") && !hasFerramenta) ||
                   (car.CompareTag("DadCar") && movement.playerId != 1) ||
                   (car.CompareTag("SonCar") && movement.playerId != 2)))
                {
                    return;
                }

                //if (collision.gameObject.GetComponent<GaragemManager>().hasCar)
                //{
                //    this.transform.GetComponent<PlayerMovement>().halt = true;
                //}
                /*else
                {
                    this.transform.GetComponent<PlayerMovement>().speedModifier = 1;
                }*/
                if (sRepair)
                {
                    this.transform.GetComponent<PlayerMovement>().halt = true;
                    pbc.BarValue = pbc.BarValue + Time.deltaTime * 50;
                    if (pbc.BarValue >= 100)
                    {
                        hitBox = false;
                        hitCar = false;
                        tmp.a = 0.37f;
                        box.GetComponent<Renderer>().material.color = tmp;
                        sRepair = false;
                        box.GetComponentInChildren<Canvas>().enabled = false;

                        switch(car.tag)
                        {
                            case "SpecialCar":
                                ScoreManager.score += 200;
                                break;
                            case "DadCar":
                            case "SonCar":
                                ScoreManager.score += 150;
                                break;
                            default:
                                ScoreManager.score += 100;
                                break;
                        }

                        Destroy(collision.gameObject.GetComponent<GaragemManager>().car);
                        collision.gameObject.GetComponent<GaragemManager>().hasCar = false;
                        this.transform.GetComponent<PlayerMovement>().halt = false;

                        AudioManager.PlaySound("Cash", Camera.main.transform.position);
                        if (hasFerramenta)
                            hasFerramenta = false;
                           
                    }
                }
                break;
            default:
                break;
        }
        

        
    }

    private void OnTriggerExit(Collider collision)
    {
        if(!sRepair)
            this.transform.GetComponent<PlayerMovement>().halt = false;
    }

    private void Update()
    {
        this.transform.Find("Ferramenta").gameObject.SetActive(hasFerramenta);
    }
}
