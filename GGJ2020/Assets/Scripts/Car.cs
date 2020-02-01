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
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length);
        for (int i = 0; i < players.Length; i++)
        {
            Debug.Log(players[i].name);
            Physics.IgnoreCollision(players[i].GetComponent<Collider>(), this.GetComponent<Collider>());
        }
    }

    void FixedUpdate()
    {
        Vector3 forward = new Vector3(transform.right.x, transform.right.y, transform.right.z);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            Debug.Log("aaaaaaaaaaaaa");
            
        }
    }
}
