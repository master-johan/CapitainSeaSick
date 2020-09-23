using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public enum TriggerState { active, inactive, ready };
    public TriggerState triggerState;

    List<Collider> colliderList;

    // Start is called before the first frame update
    void Start()
    {
        triggerState = TriggerState.inactive;
        colliderList = new List<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (triggerState)
        {
            case TriggerState.active:
                UpdateIndication();
                break;
            case TriggerState.inactive:
                UpdateIndication();
                break;
            case TriggerState.ready:
                UpdateIndication();
                break;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "CannonTriggerUnder")
        {
            triggerState = TriggerState.active;
        }
        if (other.GetComponent("Cannon_Script") || other.name == "CannonTriggerUnder") 
        {
            colliderList.Add(other);
        }
    }

    void OnTriggerStay(Collider other)
    {

        foreach (Collider loop in colliderList)
        {
            if (other.GetComponent("Cannon_Script"))
            {
                triggerState = TriggerState.ready;
                other.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                other.transform.forward = transform.forward;
                if (other.GetComponent<Cannon_Script>().cannonState == Cannon_Script.CannonState.loaded)
                {
                    other.GetComponent<Cannon_Script>().cannonState = Cannon_Script.CannonState.canFire;
                }
            }
            else if (colliderList.Count == 1 && loop.name == "CannonTriggerUnder")
            {
                triggerState = TriggerState.active;
                if (other.transform.parent.GetComponent<Cannon_Script>().cannonState == Cannon_Script.CannonState.canFire)
                {
                    other.transform.parent.GetComponent<Cannon_Script>().cannonState = Cannon_Script.CannonState.loaded;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        triggerState = TriggerState.inactive;
        if (other.GetComponent("Cannon_Script") || other.name == "CannonTriggerUnder")
        {
            colliderList.Remove(other);
        }
    }
    void UpdateIndication()
    {
        var objects = GameObject.FindGameObjectsWithTag("CannonSpot");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            if (triggerState == TriggerState.active)
            {
                Renderer render = GetComponent<Renderer>();
                render.material.color = Color.blue;
            }
            else if (triggerState == TriggerState.ready)
            {
                Renderer render = GetComponent<Renderer>();
                render.material.color = Color.red;
            }
            else if (triggerState == TriggerState.inactive)
            {
                Renderer render = GetComponent<Renderer>();
                render.material.color = Color.white;
            }
        }
    }

}
