using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    public GameObject powerUp;
    //private Transform spawn;


    // Start is called before the first frame update
    void Start()
    {
        //spawn = transform;
        //spawn.position.y = spawn.position.y + 1;
    }

    // Update is called once per frame
    void Update()
    {
        //spawn PowerUp
        if(Input.GetMouseButton(0))
        {
            GameObject spawn = Instantiate(powerUp);
            spawn.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "player") {
            //Verify powerup
            //Destroy powerup
        }
    }
}
