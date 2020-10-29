using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.Utilities;

public class PlayerInputs : MonoBehaviour
{
    Vector2 leftStick, rightStick;
    PlayerActions playerActions;
    

    public Vector2 LeftStick { get => leftStick; set => leftStick = value; }

    // Start is called before the first frame update
    void Start()
    {
        playerActions = GetComponent<PlayerActions>();
    }

    // Update is called once per frame
    void Update()
    {
  

   
    }

 
    void OnLeftStick(InputValue value)
    {
        //Saves the value from the controller into a vector which is used to steer the character.
        leftStick = value.Get<Vector2>();
       
    }
    void OnRightStick(InputValue value)
    {
        //Saves the value from the controller into a vector
        rightStick = value.Get<Vector2>();
     
    }



    void OnButtonA()
    {
   
        playerActions.PickUp();
        Debug.Log("Button A pressed");
    }
    void OnButtonB()
    {
        playerActions.Interact();
        Debug.Log("Button B pressed");
    }
    void OnButtonX()
    {
        playerActions.Boost();
        Debug.Log("Button X pressed");
    }

    void OnButtonY()
    {
        Debug.Log("Button Y pressed");
    }
}
