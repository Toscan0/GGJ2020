using System.Collections;
using System.Timers;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerId = 1;

    public Animator animator;
    public float rotation_speed = 1.5f;

    private bool invincibility = false;
    public int speedModifier = 1;
    public bool halt = false;
    private bool showHelmet = false;

    public AudioSource sfx;

    public Material mat;

    public GameObject ShieldPrefab;
    public GameObject SpeedPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(12345);

        animator = GetComponent<Animator>();

        //pu material as default
        mat.SetColor("_Color", new Color(mat.color.r, mat.color.g, mat.color.b, 255f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("Fighting") && !halt)
        {
            var movement = new Vector3(Input.GetAxis("Horizontal" + (playerId > 1 ? "" + playerId : "")) / 12, 0,
                  Input.GetAxis("Vertical" + (playerId > 1 ? "" + playerId : "")) / 20);

            transform.forward = movement.normalized;
            transform.Translate(movement * speedModifier,Space.World);
            animator.SetBool("Running", movement.magnitude > 0 ? true : false);

        }

        ShieldPrefab.SetActive(showHelmet);
        SpeedPrefab.SetActive(speedModifier > 1);

        halt = true;

    }

    public void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                animator.SetBool("Fighting", true); 
                transform.forward = (collision.transform.position - transform.position);
                AudioManager.PlaySound("Punch", transform.position);
                //Vector3 direction = (collision.transform.position - transform.position).normalized;
                //transform.Translate(-direction);
                break;
            default:
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Car":
                if (!invincibility)
                {
                    AudioManager.PlaySound("Hit" + (playerId > 1 ? "" + playerId : ""), transform.position);
                }
                break;
            case "Garagem":
                animator.SetBool("Running", false);
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
                invincibility = true;
                showHelmet = true;
                timer = (o, args) => {
                    invincibility = false;
                    showHelmet = false;
                };
                break;
            case "Speed":
                speedModifier = 2;
                timer = (o, args) => {
                    speedModifier = 1;
                };
                break;
            default:
                Debug.Log("Unknown Powerup");
                return;
        }
        aTimer.Elapsed += timer;
        aTimer.Enabled = true;
        AudioManager.PlaySound(powerUp.name + "Power", transform.position);

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
        invincibility = false;
    }

    public bool getShieldBool()
    {
        return invincibility;
    }

    public void setShieldBool(bool newBool)
    {
        invincibility = newBool;
    }
}