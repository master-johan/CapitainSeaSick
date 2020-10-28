using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable_Script : MonoBehaviour
{

    public UnityEvent toCall;
    public PlayerState playerStateToReturn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerState Interact()
    {
        toCall.Invoke();
        return playerStateToReturn;
    }   
}
