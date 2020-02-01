using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerId = 1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal" + (playerId > 1 ? "" + playerId : "")) / 50, 0, Input.GetAxis("Vertical" + (playerId > 1 ? "" + playerId : "")) / 50));        
    }

    public void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Player":
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                transform.Translate(-direction);
                break;
            case "Barraca":
                Destroy(collision.gameObject);
                break;
            case "Car":
                break;
            default:
                break;
        }
    }
}
