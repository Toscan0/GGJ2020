using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerId = 1;

    public Animator animator;
    public float rotationSpeed = 0.2f;


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
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal" + (playerId > 1 ? "" + playerId : "")) * rotationSpeed);

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
