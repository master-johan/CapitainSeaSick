using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankBandaid_Trigger : MonoBehaviour
{
    public bool isPickedUp = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player")
        //{
        //    other.GetComponent<PlayerActions>().SetFocus(gameObject, GetComponent<OffsetScript>().offsetX, GetComponent<OffsetScript>().offsetY);

        //}
    }

    public void DeactivateTriggerZone()
    {
        GetComponentInChildren<PickUp_Trigger_Script>().Disable();
    }
}
