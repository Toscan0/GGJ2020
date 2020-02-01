using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public GameObject PowerUp = null;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().powerUp(PowerUp);
            Destroy(PowerUp);
            PowerUp = null;
        }
    }
}
