using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeBlinkScript : MonoBehaviour
{
    public GameObject Cone;
    public GameObject enemyShip;
    public Color myColor;

    bool tint;
    float blinkSpeed;
   
    void Start()
    {
        blinkSpeed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if(myColor.a <= 0.1f)
        {
            tint = false;
        }
        else if (myColor.a >= 0.7f)
        {
            tint = true;
        }

        if(enemyShip.GetComponent<enemyShipScript>().lifeTimer <= 5)
        {
            blinkSpeed = 0.05f;
        }

        if(tint)
        {
            myColor.a -= blinkSpeed;
        }
        else
        {
            myColor.a += blinkSpeed;
        }
        Cone.GetComponent<Renderer>().material.SetColor("_Color", myColor);
    }
}
