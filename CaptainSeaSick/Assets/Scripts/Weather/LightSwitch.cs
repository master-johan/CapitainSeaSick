using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    private Light mainLight, secondLight;
    public bool switchLight;
    // Start is called before the first frame update
    void Start()
    {
        mainLight = GameObject.Find("Main Light").GetComponent<Light>();
        secondLight = GameObject.Find("Second Light").GetComponent<Light>();

        mainLight.intensity = 0.6f;
        secondLight.intensity = 0.3f;
        switchLight = false;
    }

    // Update is called once per frame
    void Update()
    {
        TransitionLight();
    }

    public void TransitionLight()
    {

            if (switchLight)
            {
                if (mainLight.intensity >= 0.1)
                {
                    mainLight.intensity -= 0.05f * Time.deltaTime;
                    secondLight.intensity -= 0.025f * Time.deltaTime;
                }
            }
            else
            {
                if (mainLight.intensity <= 0.6)
                {
                    mainLight.intensity += 0.05f * Time.deltaTime;
                    secondLight.intensity += 0.025f * Time.deltaTime;
                }
            }

    }
}
