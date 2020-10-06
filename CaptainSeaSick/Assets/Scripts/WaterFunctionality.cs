using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFunctionality : MonoBehaviour
{
    Renderer renderer;
    BoxCollider collider;
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        collider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WaterBlocker")
        {
            renderer.enabled = false;
            collider.isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "WaterBlocker")
        {
            renderer.enabled = true;
            collider.isTrigger = false;
        }
    }
}
