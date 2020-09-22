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

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Boolen = " + inSteeringPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
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
    public GameObject GetPlayer()
    {
        return player;
    }
}
