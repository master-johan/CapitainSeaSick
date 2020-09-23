using System.Collections;
using System;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private Dictionary<string,UnityEvent> eventDictionary;
    private static EventManager eventManager;

    //Check so there is EventManager
    public static EventManager instance
    {
        get
        {
            if(!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if(!eventManager)
                {
                    Debug.LogError("there is no active EventManager");
                }
                else
                {
                    eventManager.Initiate();
                }
            }

            return eventManager;
        }
    }

    //Initiate EventManager
    private void Initiate()
    {
        if(eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }
    //Start subscription to event or add to dictionary
    public static void StartSubscribe (string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;

        //If this event exists in dictionary, this event gets value
        if(instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener); //Add listners to event
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener); //Add listner to this event
            instance.eventDictionary.Add(eventName, thisEvent); //Add this event to the event dictionary
        }
    }
    //Stop subscription to event and remove the listener
    public static void StopSubscribe(string eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener); //Remove Listners to event
        }
    }

    //Trigger the event and start all listners to this event
    public static void TriggerEvent (string eventName)
    {
        UnityEvent thisEvent = null;
        if(instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(); //Start all listners to event
        }
    }
}
