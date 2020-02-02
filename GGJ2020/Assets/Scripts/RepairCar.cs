using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairCar : MonoBehaviour
{
    public bool hitBox = false;
    public bool hitCar = false;
    public bool sRepair = false;
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
                    box = collision.gameObject;
                    this.transform.GetComponent<PlayerMovement>().speedModifier = 0;
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
            if(hitBox && hitCar)
            {
                pbc = box.GetComponentInChildren<Canvas>().GetComponentInChildren<ProgressBarCircle>();
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
                if (collision.gameObject.GetComponent<GaragemManager>().hasCar)
                {
                    this.transform.GetComponent<PlayerMovement>().speedModifier = 0;
                }
                /*else
                {
                    this.transform.GetComponent<PlayerMovement>().speedModifier = 1;
                }*/
                if (sRepair)
                {
                    pbc.BarValue = pbc.BarValue + Time.deltaTime * 50;
                    if (pbc.BarValue >= 100)
                    {
                        hitBox = false;
                        hitCar = false;
                        tmp.a = 0.37f;
                        box.GetComponent<Renderer>().material.color = tmp;
                        sRepair = false;
                        box.GetComponentInChildren<Canvas>().enabled = false;
                        Destroy(collision.gameObject.GetComponent<GaragemManager>().car);
                        collision.gameObject.GetComponent<GaragemManager>().hasCar = false;
                        this.transform.GetComponent<PlayerMovement>().speedModifier = 1;
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
            this.transform.GetComponent<PlayerMovement>().speedModifier = 1;
    }

}
