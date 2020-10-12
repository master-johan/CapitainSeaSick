using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrell_Script : MonoBehaviour
{
    public List<GameObject> takeOutList;

    public GameObject takeOutObject;

    public GameObject tempObject;
    float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        takeOutList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }
    /// <summary>
    /// Create the Object together with using a 1 second timer so it can not be spammed.
    /// </summary>
    /// <param name="position"></param>
    public void CreateObject(Vector3 position)
    {
        if (timer <= 0)
        {
            takeOutList.Add(tempObject = Instantiate(takeOutObject, position, Quaternion.identity));
            timer = 1;
        }
    }
}
