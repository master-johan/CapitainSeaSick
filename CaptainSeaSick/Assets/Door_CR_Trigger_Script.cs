using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_CR_Trigger_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "CaptainsKey")
        {
            Debug.Log("KEY ENTER");
            GameObject.Find("DoorPivot_CR").GetComponent<Door_CR_Script>().OpenDoor();
        }
       
    }
}
