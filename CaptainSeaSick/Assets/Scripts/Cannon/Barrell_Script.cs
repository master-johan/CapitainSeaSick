using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrell_Script : MonoBehaviour
{
    public List<GameObject> takeOutList;

    public GameObject takeOutObject;
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

    public void CreateObject(Vector3 position)
    {
        if (timer <= 0)
        {
            takeOutList.Add(Instantiate(takeOutObject, position, Quaternion.identity));
            timer = 1;
        }
    }
}
