using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public Rigidbody rb;
    public float speed; 
    //public float minSpeed = 8f;
    //public float maxSpeed = 12f;

    //float speed = 1f;

    void Start()
    {
        //speed = Random.Range(minSpeed, maxSpeed);
    }

    void FixedUpdate()
    {
        Vector3 forward = new Vector3(transform.right.x, transform.right.y, transform.right.z);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }

}
