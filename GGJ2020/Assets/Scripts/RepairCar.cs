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

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] collidersHit =  Physics.OverlapSphere(collision.transform.position, 1);
        foreach(Collider collider in collidersHit)
        {
            if(collider.name == "Cube" || collider.name == "Cube (2)" || collider.name == "Cube (3)" || collider.name == "Cube (4)" || collider.name == "Cube (5)")
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
        }
    }

    private void OnCollisionStay(Collision collision)
    {
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
                box.GetComponentInChildren<Canvas>().gameObject.SetActive(false);
                Destroy(car);
                if (hasFerramenta)
                    hasFerramenta = false;
            }
        }
    }
}
