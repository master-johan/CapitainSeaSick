using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastBot_Trigger_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Enter Climbing");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Exit Climbing");
        }
    }
}
