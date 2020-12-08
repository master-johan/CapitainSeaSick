using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLeak_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WaterBlocker")
        {
            transform.GetComponentInChildren<ParticleSystem>().Stop();

            if(!transform.GetComponent<BoxCollider>().isTrigger)
            {
                transform.GetComponent<BoxCollider>().enabled = false;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "WaterBlocker")
        {
            transform.GetComponentInChildren<ParticleSystem>().Play();

            if (!transform.GetComponent<BoxCollider>().isTrigger)
            {
                transform.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
