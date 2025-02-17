﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public Collider carCollider;

    //public float minSpeed = 8f;
    //public float maxSpeed = 12f;

    //float speed = 1f;



    void Start()
    {
        //speed = Random.Range(minSpeed, maxSpeed);
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            Physics.IgnoreCollision(players[i].GetComponent<SphereCollider>(),
                carCollider);
        }
    }

    void FixedUpdate()
    {
        Vector3 forward = new Vector3(transform.right.x, transform.right.y, transform.right.z);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            PlayerMovement player = obj.GetComponent<PlayerMovement>();

            if (player.getShieldBool() == false)
            {
                player.setShieldBool(true);
                //lost life
                ScoreManager gameManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
                ScoreManager.LostLife();

                //put player in inicial pos
                if (obj.name == "Filho")
                {
                    obj.transform.localPosition = new Vector3(-16.56f, -0.55f, -13.74f);
                }
                if (obj.name == "Pai")
                {
                    obj.transform.localPosition = new Vector3(-12.1f, -0.55f, -13.75f);
                }


                StartCoroutine(player.DoBlinks(2f, 0.2f));
            }
            
        }
    }
}
