using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Trigger_Script : MonoBehaviour
{
    public bool spawnWithTimers;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (!collider.isTrigger)
            {
                if (spawnWithTimers)
                {
                    foreach (var item in GameObject.FindGameObjectsWithTag("BarrelSpawner"))
                    {
                        item.GetComponent<BarrellSpawner>().spawnWithTimer = true;
                    }
                    
                }
                else
                {
                    foreach (var item in GameObject.FindGameObjectsWithTag("BarrelSpawner"))
                    {
                        item.GetComponent<BarrellSpawner>().spawnBarrel = true;
                    }
                }
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
