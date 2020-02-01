using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaragemManager : MonoBehaviour
{

    public bool hasCar = false;
    public GameObject car;
    public Canvas canva;
    public ProgressBarCircle pbc;

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
