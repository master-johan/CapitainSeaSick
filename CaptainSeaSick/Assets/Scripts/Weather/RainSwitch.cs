using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSwitch : MonoBehaviour
{
    public bool rainOn;
    ParticleSystem rain;
    // Start is called before the first frame update
    void Start()
    {
        rain = transform.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rainOn)
        {
            rain.Play();
        }
        else
        {
            rain.Stop();
        }
    }
}
