using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{

    //public GameObject powerUp;
    public List<GameObject> powerUps = new List<GameObject>();
    public GameObject[] barracas;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerUps", 0, 1);
    }

    void SpawnPowerUps() {
        GameObject barraca = barracas[Random.Range(0, 4)];
        if (barraca.GetComponent<BarracaManager>().PowerUp == null) {
            GameObject powerUp = powerUps[Random.Range(0, 2)];
            GameObject spawn = Instantiate(powerUp);
            spawn.name = powerUp.name;
            spawn.transform.position = new Vector3(barraca.transform.position.x, barraca.transform.position.y + 1, barraca.transform.position.z);
            barraca.GetComponent<BarracaManager>().PowerUp = spawn;
        }
        
    }

    // Update is called once per frame
    /*void Update()
    {
        //spawn PowerUp
        if (nextTimeToSpawn <= Time.time)
        {
            Debug.Log("spawnPowerUP");
            GameObject spawn = Instantiate(powerUps[0]);
            spawn.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            nextTimeToSpawn = Time.time + spawnDelay;
        }

        if (Input.GetMouseButton(1))
        {
            GameObject spawn = Instantiate(powerUps[1]);
            spawn.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }*/

}
