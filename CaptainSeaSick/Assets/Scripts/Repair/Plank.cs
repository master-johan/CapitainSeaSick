using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public bool isPickedUp;
    public bool isInRadius;

    private Vector3 forwardPos;
    void Start()
    {
        isPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnCollisionEnter(Collision collision)
    {

    }

}
