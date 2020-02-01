using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerId = 1;

    private bool shield = false;

    private int speedModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal" + (playerId > 1 ? "" + playerId : "")) * speedModifier / 50, 0, Input.GetAxis("Vertical" + (playerId > 1 ? "" + playerId : "")) * speedModifier / 50));        
    }

    public void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Player":
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                transform.Translate(-direction);
                break;
            case "Car":
                break;
            default:
                break;
        }
    }

    public void powerUp(GameObject powerUp) {

        // Create a timer with a two second interval.
        System.Timers.Timer aTimer = new System.Timers.Timer(10000);
        // Hook up the Elapsed event for the timer.
        aTimer.AutoReset = true;
        ElapsedEventHandler timer;
        switch (powerUp.name)
        {
            case "Shield":
                shield = true;
                timer = (o, args) => {
                    shield = false;
                };
                aTimer.Elapsed += timer;
                aTimer.Enabled = true;
                break;
            case "Speed":
                speedModifier = 2;
                timer = (o, args) => {
                    speedModifier = 1;
                };
                aTimer.Elapsed += timer;
                aTimer.Enabled = true;
                break;
            default:
                Debug.Log("Unknown Powerup");
                break;
        }

    }
}
