using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastBot_Trigger_Script : MonoBehaviour
{
    List<GameObject> players;

    private void Start()
    {
        players = new List<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerActions>().SetFocus(transform.gameObject,0,0);
            Debug.Log("Player Enter Climbing");
            players.Add(other.gameObject);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Exit Climbing");
            PlayerActions pa = other.GetComponent<PlayerActions>();
            players.Remove(other.gameObject);
            if (pa.focusedObject == transform.gameObject)
            {
                pa.SetFocus(null, 0, 0);
            }
        }
    }


}
