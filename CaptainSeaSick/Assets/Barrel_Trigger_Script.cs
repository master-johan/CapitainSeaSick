using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Trigger_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (!collider.isTrigger)
            {
                GameObject.Find("BarrellManager").GetComponent<BarrellSpawner>().spawnBarrel = true;
            }

            Debug.Log("Player Enter Spawn Barrel");
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            
            Debug.Log("Player Exit Spawn Barrel");
        }
    }
}
