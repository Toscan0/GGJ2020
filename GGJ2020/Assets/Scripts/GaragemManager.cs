using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaragemManager : MonoBehaviour
{

    public bool hasCar = false;
    public GameObject car;
    public GameObject specialCar;
    public Canvas canva;
    public ProgressBarCircle pbc;
    public GameObject barraca;

    private void Start()
    {
        canva.enabled = false;

    }

    private void Update()
    {
        this.pbc.BarValue = this.pbc.BarValue - Time.deltaTime * 20;
        if(pbc.BarValue <= 0)
        {
            canva.enabled = false;
            Destroy(car);
            hasCar = false;
            if (barraca != null)
            {
                barraca.GetComponent<BarracaManager>().destroy();
                barraca = null;
            }
        }
    }

    public void EnableIcon()
    {
        canva.enabled = true;
    }
    public void StartTimer()
    {
        pbc.BarValue = 100;
    }

}
