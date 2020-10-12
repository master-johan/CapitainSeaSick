using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    Renderer thisRenderer;
    public bool plateIsTriggered;

    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
        thisRenderer.material.color = Color.red;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            thisRenderer.material.color = Color.green;
            plateIsTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            thisRenderer.material.color = Color.red;
            plateIsTriggered = false ;
        }
    }
}
