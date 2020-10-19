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
    GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        //triggerState = TriggerState.inactive;
        cannonSpot = GetComponentInChildren<Cannon_Spot_Script>();
        colliderList = new List<Collider>();
        child = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //switch (triggerState)
        //{
        //    case TriggerState.active:
        //        UpdateIndication();
        //        break;
        //    case TriggerState.inactive:
        //        UpdateIndication();
        //        break;
        //    case TriggerState.ready:
        //        UpdateIndication();
        //        break;
        //}

    }
    /// <summary>
    /// if a trigger collides with a collider under the cannon it becomes active as in blue
    /// If a trigger collides with either the box under a cannon or the cannon it gets added to a list
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "CannonTriggerUnder")
        {
            cannonSpot.triggerState = Cannon_Spot_Script.TriggerState.active;
            //triggerState = TriggerState.active;
 
        }
        if (other.GetComponent("Cannon_Script") || other.name == "CannonTriggerUnder") 
        {
            colliderList.Add(other);

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
                cannonSpot.triggerState = Cannon_Spot_Script.TriggerState.ready;
                //triggerState = TriggerState.ready;
                //other.transform.position = new Vector3(cannonSpot.transform.position.x, cannonSpot.transform.position.y, cannonSpot.transform.position.z);
                other.transform.position = child.GetComponent<Renderer>().bounds.center;
                other.transform.forward = cannonSpot.transform.forward;
                if (other.GetComponent<Cannon_Script>().cannonState == Cannon_Script.CannonState.loaded)
                {
                    other.GetComponent<Cannon_Script>().cannonState = Cannon_Script.CannonState.canFire;
                }
            }
            else if (colliderList.Count == 1 && loop.name == "CannonTriggerUnder")
            {
                cannonSpot.triggerState = Cannon_Spot_Script.TriggerState.active;
                //triggerState = TriggerState.active;
                if (other.transform.parent.GetComponent<Cannon_Script>().cannonState == Cannon_Script.CannonState.canFire)
                {
                    other.transform.parent.GetComponent<Cannon_Script>().cannonState = Cannon_Script.CannonState.loaded;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        cannonSpot.triggerState = Cannon_Spot_Script.TriggerState.inactive;
        //triggerState = TriggerState.inactive;
        if (other.GetComponent("Cannon_Script") || other.name == "CannonTriggerUnder")
        {
            colliderList.Remove(other);
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
