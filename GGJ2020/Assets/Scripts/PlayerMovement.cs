using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerId = 1;

    public Animator animator;
    public float rotation_speed = 1.5f;
    private bool shield = false;

    public Material mat;
    private int speedModifier = 1;

    float startingTime = 0;
    bool isStarted = false;
    bool hasBlinked = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //pu material as default
        mat.SetColor("_Color", new Color(mat.color.r, mat.color.g, mat.color.b, 255f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("Fighting"))
        {
            var movement = new Vector3(Input.GetAxis("Horizontal" + (playerId > 1 ? "" + playerId : "")) / 45, 0,
                  Input.GetAxis("Vertical" + (playerId > 1 ? "" + playerId : "")) / 50);

            transform.forward = movement.normalized;
            transform.Translate(movement * speedModifier,Space.World);
            animator.SetBool("Running", movement.magnitude > 0 ? true : false);

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                animator.SetBool("Fighting", true); 
                transform.forward = (collision.transform.position - transform.position);
                //Vector3 direction = (collision.transform.position - transform.position).normalized;
                //transform.Translate(-direction);
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

    public IEnumerator DoBlinks(float duration, float blinkTime)
    {
        bool transparente = false;
        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += blinkTime;

            if (transparente == false)
            {
                mat.SetColor("_Color", new Color(mat.color.r, mat.color.g, mat.color.b, 0f));
            }
            else
            {
                mat.SetColor("_Color", new Color(mat.color.r, mat.color.g, mat.color.b, 255f));
            }
            transparente = !transparente;

            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }

        mat.SetColor("_Color", new Color(mat.color.r, mat.color.g, mat.color.b, 255f));
        shield = false;
    }

    public bool getShieldBool()
    {
        return shield;
    }
}