using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    //public enum TriggerState { active, inactive, ready };
    //public TriggerState triggerState;

    List<Collider> colliderList;
    Cannon_Spot_Script cannonSpot;
    GameObject child, cannonOnSpot;
    // Start is called before the first frame update
    void Start()
    {
        cannonSpot = GetComponentInChildren<Cannon_Spot_Script>();
        colliderList = new List<Collider>();
        child = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {



    }
    /// <summary>
    /// if a trigger collides with a collider under the cannon it becomes active as in blue
    /// If a trigger collides with either the box under a cannon or the cannon it gets added to a list
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "CannonTriggerUnder" && cannonSpot.triggerState != Cannon_Spot_Script.TriggerState.ready)
        {
            cannonSpot.triggerState = Cannon_Spot_Script.TriggerState.active;
            //triggerState = TriggerState.active;

        }
        if (other.GetComponent("Cannon_Script") || other.name == "CannonTriggerUnder")
        {
            colliderList.Add(other);

        }
        if (cannonSpot.triggerState == Cannon_Spot_Script.TriggerState.ready)
        {
            if (other.GetComponent("Cannon_Script") && cannonOnSpot.GetComponent<Cannon_Script>().onSpot)
            {
                other.transform.position = Vector3.zero;
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
    /// <summary>
    /// If a trigger collides with a cannon, the cannons position gets set to the trigger position.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {



        foreach (Collider loop in colliderList)
        {
            if (other.GetComponent("Cannon_Script"))
            {
               
                if (cannonSpot.triggerState != Cannon_Spot_Script.TriggerState.ready)
                {
                    cannonOnSpot = other.gameObject;
                    cannonOnSpot.GetComponent<Cannon_Script>().onSpot = true;
                    
                }

                if (cannonOnSpot.GetComponent<Cannon_Script>().onSpot)
                {
                    cannonSpot.triggerState = Cannon_Spot_Script.TriggerState.ready;
                    cannonOnSpot.transform.position = child.GetComponent<Renderer>().bounds.center;
                    cannonOnSpot.transform.right = cannonSpot.transform.forward;
                }
                

                //triggerState = TriggerState.ready;
                //other.transform.position = new Vector3(cannonSpot.transform.position.x, cannonSpot.transform.position.y, cannonSpot.transform.position.z);


                if (other.GetComponent<Cannon_Script>().cannonState == Cannon_Script.CannonState.loaded)
                {
                    other.GetComponent<Cannon_Script>().cannonState = Cannon_Script.CannonState.canFire;
                }
            }
            else if (colliderList.Count == 1 && loop.name == "CannonTriggerUnder" && cannonSpot.triggerState != Cannon_Spot_Script.TriggerState.ready)
            {
                cannonSpot.triggerState = Cannon_Spot_Script.TriggerState.active;
                //triggerState = TriggerState.active;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        cannonSpot.triggerState = Cannon_Spot_Script.TriggerState.inactive;
        //triggerState = TriggerState.inactive;
        if (other.GetComponent("Cannon_Script") || other.name == "CannonTriggerUnder")
        {
            cannonOnSpot.GetComponent<Cannon_Script>().onSpot = false;

            colliderList.Remove(other);
        }
        if (other.name == "CannonTriggerUnder")
        {
            if (other.transform.parent.GetComponent<Cannon_Script>().cannonState == Cannon_Script.CannonState.canFire)
            {
                other.transform.parent.GetComponent<Cannon_Script>().cannonState = Cannon_Script.CannonState.loaded;
            }
        }

    }
    /// <summary>
    /// Setting the trigger colors depending on state
    /// </summary>
    //void UpdateIndication()
    //{
    //    var objects = GameObject.FindGameObjectsWithTag("CannonSpot");
    //    var objectCount = objects.Length;
    //    foreach (var obj in objects)
    //    {
    //        if (triggerState == TriggerState.active)
    //        {
    //            Renderer render = GetComponent<Renderer>();
    //            render.material.color = Color.blue;
    //        }
    //        else if (triggerState == TriggerState.ready)
    //        {
    //            Renderer render = GetComponent<Renderer>();
    //            render.material.color = Color.red;
    //        }
    //        else if (triggerState == TriggerState.inactive)
    //        {
    //            Renderer render = GetComponent<Renderer>();
    //            render.material.color = Color.white;
    //        }
    //    }
    //}

}
