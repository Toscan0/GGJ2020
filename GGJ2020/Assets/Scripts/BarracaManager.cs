using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracaManager : MonoBehaviour
{
    public bool hasFerramenta = false;
    public GameObject ferramenta;

    public void destroy()
    {
        Destroy(ferramenta);
        hasFerramenta = false;
    }

    public void Init()
    {
        GameObject nova_ferramenta = Instantiate(ferramenta);
        //spawn.name = powerUp.name;
        nova_ferramenta.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        //spawnPoint.GetComponent<SpawnPointManager>().PowerUp = spawn;
        hasFerramenta = true;
    }
    /*public GameObject PowerUp = null;


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().powerUp(PowerUp);
            Destroy(PowerUp);
            PowerUp = null;
        }
    }*/
}

