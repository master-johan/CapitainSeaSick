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


            //other.gameObject.transform.position = this.transform.position;
            steering.inSteeringPosition = true;
            Debug.Log("Steering_Trigger_script: " + steering.inSteeringPosition);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            steering.inSteeringPosition = false;
        }
    }
}
