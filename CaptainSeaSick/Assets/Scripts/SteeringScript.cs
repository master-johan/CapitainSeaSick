using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SteeringScript : MonoBehaviour
{
    bool inSteeringPosition;
    GameObject player;
    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inSteeringPosition = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inSteeringPosition = false;
        }
    }
    public bool GetSteeringBool()
    {
        return inSteeringPosition;
    }
}
