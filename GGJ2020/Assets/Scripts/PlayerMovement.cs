using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerId = 1;

    public Animator animator;


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
            var movement = new Vector3(Input.GetAxis("Horizontal" + (playerId > 1 ? "" + playerId : "")) / 50, 0,
                Input.GetAxis("Vertical" + (playerId > 1 ? "" + playerId : "")) / 50);
            transform.Translate(movement);
            if ((movement.z > 0 && movement.x > 0) || (movement.z < 0 && movement.x > 0))
            {
                transform.Rotate(Vector3.up, 1.2f);

            }

            if ((movement.z > 0 && movement.x < 0) || (movement.z < 0 && movement.x < 0))
            {
                transform.Rotate(Vector3.up, -1.2f);

            }

            animator.SetBool("Running", movement.magnitude > 0);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Player":
                animator.SetBool("Fighting", true);
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
