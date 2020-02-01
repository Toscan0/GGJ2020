using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerId = 1;

    public Animator animator;
    public float rotation_speed = 0.5f;
    public static float MAX_SPEED = 1.5f;

    public Material mat;

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
        var movement = new Vector3(Input.GetAxis("Horizontal" + (playerId > 1 ? "" + playerId : "")) / 50, 0,
            Input.GetAxis("Vertical" + (playerId > 1 ? "" + playerId : "")) / 50);
        transform.Translate(movement);
        animator.SetBool("Running", movement.magnitude > 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
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

    public IEnumerator DoBlinks(float duration, float blinkTime)
    {
        bool transparente = false;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            currentTime += blinkTime;

            Debug.Log("Duration " + duration);
            Debug.Log("delta time " + Time.time);

            //toggle renderer
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

        //make sure renderer is enabled when we exit
        mat.SetColor("_Color", new Color(mat.color.r, mat.color.g, mat.color.b, 255f));
    }

}