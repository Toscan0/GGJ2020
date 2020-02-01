using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCar : MonoBehaviour
{
    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Car")
        {
            Destroy(obj.gameObject);
        }
    }
}
