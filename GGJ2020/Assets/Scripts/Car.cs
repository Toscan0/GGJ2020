using System.Collections;
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
        Debug.Log(players.Length);
        for (int i = 0; i < players.Length; i++)
        {
            Debug.Log(players[i].name);
            Physics.IgnoreCollision(players[i].GetComponent<BoxCollider>(),
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
            //lost life
            ScoreManager gameManager = GameObject.Find("GameManager").GetComponent<ScoreManager>(); 
            ScoreManager.LostLife();

            //put player in inicial pos
            if(obj.name == "Filho")
            {
                obj.transform.localPosition = new Vector3(-16.56f, -0.55f, -12.63f);
            }
            if (obj.name == "Pai")
            {
                obj.transform.localPosition = new Vector3(-13.204f, -0.55f, -12.63f);
            }

            PlayerMovement player = obj.GetComponent<PlayerMovement>();
            StartCoroutine(player.DoBlinks(2f, 0.2f));
        }
    }
}
