using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakScript : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 3;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            DoDamage();
        }
    }

    void DoDamage()
    {
        GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipHealth>().ModifyHealth(-5);
        timer = 3;
    }
}
