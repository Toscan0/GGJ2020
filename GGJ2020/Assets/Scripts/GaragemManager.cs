using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaragemManager : MonoBehaviour
{

    public bool hasCar = false;
    public GameObject car;
    public GameObject specialCar;
    public Canvas canva;
    public ProgressBarCircle pbc;
    public GameObject barraca;
    public Sprite normalSprite;

    private void Start()
    {
        canva.enabled = false;

    }

    private void Update()
    {
        this.pbc.BarValue = this.pbc.BarValue - Time.deltaTime * 5;
        if(pbc.BarValue <= 0)
        {
            canva.enabled = false;
            Destroy(car);
            //AudioManager.PlaySound("Greta", Camera.main.transform.position);
            hasCar = false;
            if (barraca != null)
            {
                barraca.GetComponent<BarracaManager>().destroy();
                barraca = null;
            }
        }
    }

    public void EnableIcon(Sprite sprite)
    {
        canva.enabled = true;
        if (sprite != null)
        {
            canva.transform.Find("Image").GetComponent<Image>().sprite = sprite;
        } else
        {
            canva.transform.Find("Image").GetComponent<Image>().sprite = normalSprite;
        }
    }
    public void StartTimer()
    {
        pbc.BarValue = 100;
    }

}
