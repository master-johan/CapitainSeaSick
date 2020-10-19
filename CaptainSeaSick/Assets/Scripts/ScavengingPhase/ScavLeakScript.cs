using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavLeakScript : MonoBehaviour
{
    Renderer renderer;
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WaterBlocker")
        {
            renderer.enabled = false;
            if (!collider.isTrigger)
            {
                collider.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "WaterBlocker")
        {
            renderer.enabled = true;
            if (!collider.isTrigger)
            {
                collider.enabled = true;
            }
        }
    }
}
