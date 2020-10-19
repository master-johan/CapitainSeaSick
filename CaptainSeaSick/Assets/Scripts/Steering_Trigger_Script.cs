using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering_Trigger_Script : MonoBehaviour
{
    SteeringScript steering;
    private void Start()
    {
        steering = GetComponent<SteeringScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            steering.inSteeringPosition = true;
            Debug.Log("Player Enter Steering Zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            steering.inSteeringPosition = false;
            Debug.Log("Player Exit Steering Zone");
        }
    }
}
