using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak_Trigger_Script : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Enter LeakZone");
            other.GetComponent<PlayerActions>().SetFocus(transform.parent.gameObject, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerActions pa = other.GetComponent<PlayerActions>();
            if (pa.focusedObject == null)
            {
                pa.SetFocus(transform.parent.gameObject, 0, 0);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerActions pa = other.GetComponent<PlayerActions>();
            if (pa.focusedObject == transform.parent.gameObject && pa.playerState == PlayerState.free)
            {
                pa.SetFocus(null, 0, 0);
            }
        }
    }


}
