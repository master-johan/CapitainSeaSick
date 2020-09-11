using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public enum TriggerState { active, inactive, ready };
    public TriggerState triggerState;

    // Start is called before the first frame update
    void Start()
    {
        triggerState = TriggerState.inactive;
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
        triggerState = TriggerState.active;
    }
    void OnTriggerExit(Collider other)
    {
        triggerState = TriggerState.inactive;
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
