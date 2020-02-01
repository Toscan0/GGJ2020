using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerId = 1;

    public Animator animator;
    public float rotation_speed = 0.5f;
    public static float MAX_SPEED = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal" + (playerId > 1 ? "" + playerId : "")) / 50, 0,
            Input.GetAxis("Vertical" + (playerId > 1 ? "" + playerId : "")) / 50);
        transform.Translate(movement);
        if ((movement.z > 0 && movement.x > 0) || (movement.z < 0 && movement.x > 0))
        {
            transform.Rotate(Vector3.up, 1);

        }
        if ((movement.z > 0 && movement.x < 0) || (movement.z < 0 && movement.x < 0))
        {
            transform.Rotate(Vector3.up, -1);

        }
        animator.SetBool("Running", movement.magnitude > 0);
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
