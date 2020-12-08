using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankBarrel_Trigger_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Enter PlankBarrel");
            other.GetComponent<PlayerActions>().SetFocus(gameObject, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerActions pa = other.GetComponent<PlayerActions>();
            if (pa.focusedObject == gameObject && pa.playerState == PlayerState.free)
            {
                pa.SetFocus(null, 0, 0);
            }
        }
    }
}
