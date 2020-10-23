using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrell_Script : MonoBehaviour
{
    public List<GameObject> takeOutList;
    Vector2 spawnPos;

    public GameObject takeOutObject;

    public GameObject tempObject;
    float offsetX, offsetY;

    float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        takeOutList = new List<GameObject>();

        spawnPos = transform.position;
            //+ new Vector3(0, transform.localScale.y
            //                                        * GetComponent<MeshRenderer>().bounds.size.y 
            //                                        + takeOutObject.transform.localScale.y 
            //                                        * takeOutObject.GetComponent<MeshRenderer>().bounds.size.y,
            //                                        0);
    }

    private void GetOffsetValues()
    {
        offsetX = tempObject.GetComponent<OffsetScript>().offsetX;
        offsetY = tempObject.GetComponent<OffsetScript>().offsetY;
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
    public GameObject CreateObject(GameObject player)
    {
        if (timer <= 0)
        {
            
            takeOutList.Add(tempObject = Instantiate(takeOutObject, spawnPos/*player.transform.position + player.transform.forward *  offsetX*/, Quaternion.identity));
            GetOffsetValues();
            //player.GetComponent<PlayerActions>().SetFocus(tempObject, offsetX, offsetY);
            timer = 1;
            return tempObject;
        }
        return null;
    }
}
