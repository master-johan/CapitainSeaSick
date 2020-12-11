using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateFunctionality : MonoBehaviour
{
    public Animator pressureAnimator;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pressureAnimator.SetBool("Triggered", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pressureAnimator.SetBool("Triggered", false);
        }
    }
}
