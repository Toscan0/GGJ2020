using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracaManager : MonoBehaviour
{
    public GameObject ferramenta;

    public void destroy()
    {
        Destroy(ferramenta);
    }

    public void Init()
    {
        GameObject nova_ferramenta = Instantiate(ferramenta);
        //spawn.name = powerUp.name;
        nova_ferramenta.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        //spawnPoint.GetComponent<SpawnPointManager>().PowerUp = spawn;
    }
    //public GameObject PowerUp = null;


    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Player" && ferramenta!=null)
    //    {
    //        gameObject.GetComponent<RepairCar>().hasFerramenta = true;
    //        destroy();
    //    }
    //}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && ferramenta != null)
        {
            if (col.gameObject.GetComponent<RepairCar>().hasFerramenta == false)
            {
                col.gameObject.GetComponent<RepairCar>().hasFerramenta = true;
                destroy();
            }
        }
    }
}

