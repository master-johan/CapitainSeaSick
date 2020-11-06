using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor_CR : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("DoorPivot_CR").GetComponent<Door_Script>().OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("DoorPivot_CR").GetComponent<Door_Script>().CloseDoor();
        }
    }
}
