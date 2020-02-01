using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesController : MonoBehaviour
{

    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Cars"), LayerMask.NameToLayer("Boundaries"));
    }

    // Update is called once per frame
    void Update()
    {

    }

}
