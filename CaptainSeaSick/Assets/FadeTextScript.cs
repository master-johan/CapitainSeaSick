using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeTextScript : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Color myColor;

    bool tint;
    float blinkSpeed;
    void Start()
    {
        blinkSpeed = 0.007f;
    }

    // Update is called once per frame
    void Update()
    {
        if (myColor.a <= 0f)
        {
            tint = false;
        }
        else if (myColor.a >= 1f)
        {
            tint = true;
        }


        if (tint)
        {
            myColor.a -= blinkSpeed;
        }
        else
        {
            myColor.a += blinkSpeed;
        }
        //Text.GetComponent<Renderer>().material.SetColor("_Color", myColor);

        Text.color = myColor;
    }
}
