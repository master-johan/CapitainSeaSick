using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!other.isTrigger)
            {
                Debug.Log("Player Enter");
                GameObject.Find("DoorPivot").GetComponent<Door_Script>().OpenDoor();
            }

        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        GameObject.Find("DoorPivot").GetComponent<Door_Script>().StayOpen();
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if(!other.isTrigger)
            {
                Debug.Log("Player Exit");
                GameObject.Find("DoorPivot").GetComponent<Door_Script>().CloseDoor();
            }
        }
    }
}
