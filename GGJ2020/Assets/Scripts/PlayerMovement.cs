using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerId = 1;

    public Animator animator;
    public float rotation_speed = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("Fighting"))
        {
            var movement = new Vector3(Input.GetAxis("Horizontal" + (playerId > 1 ? "" + playerId : "")), 0,
                  Input.GetAxis("Vertical" + (playerId > 1 ? "" + playerId : "")));

            transform.forward = movement;
            transform.Translate(movement / 50,Space.World);
            animator.SetBool("Running", movement.magnitude > 0 ? true : false);

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Player":
                animator.SetBool("Fighting", true); 
                transform.forward = (collision.transform.position - transform.position);
                //Vector3 direction = (collision.transform.position - transform.position).normalized;
                //transform.Translate(-direction);
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
