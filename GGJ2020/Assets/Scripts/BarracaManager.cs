using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracaManager : MonoBehaviour
{
    public GameObject PowerUp = null;


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().powerUp(PowerUp);
            Destroy(PowerUp);
            PowerUp = null;
        }
    }
}

