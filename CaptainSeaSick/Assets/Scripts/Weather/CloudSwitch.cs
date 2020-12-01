using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSwitch : MonoBehaviour
{
    public ParticleSystem heavyClouds, lightClouds;
    public bool startHeavyClouds;
    // Start is called before the first frame update
    void Start()
    {
        startHeavyClouds = false;
    }

    void Update()
    {
        if (startHeavyClouds)
        {
           
            if (!heavyClouds.isPlaying)
            {
                heavyClouds.Clear();
                heavyClouds.Play();
            }
        }
        else
        {
            heavyClouds.Stop();
        }
    }
}
