using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.WSA.Input;

public class PlayerActions : MonoBehaviour
{
    public float speed = 6;
    Vector3 direction;
    PlayerInputs playerInputs;

    GameObject focusedObject;
    Vector2 focusedObjectOffset;


    bool carryingItem, carryFocusedObject;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInputs = GetComponent<PlayerInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement(playerInputs.LeftStick);
        // PickUp();
        if (carryingItem)
        {
            CarryFocusedObject();
        }
    }

    void PlayerMovement(Vector2 input)
    {
        direction = new Vector3(input.x, 0, input.y) * speed;

        if (direction != Vector3.zero)
        {
            transform.forward = direction.normalized;
        }
        if (Math.Abs(input.x) >= 0.125 || Math.Abs(input.y) >= 0.125)
        {
            direction.y = rb.velocity.y;
            rb.velocity = direction;
        }
    }

    public void SetFocus(GameObject target,float offsetX, float offsetY)
    {
        if (!carryingItem)
        {

            Debug.Log("Got a new focus");
            focusedObject = target;
            focusedObjectOffset = new Vector2(offsetX, offsetY);

        }
    }

    public void PickUp()
    {
        if (focusedObject.tag== "Container")
        {
            focusedObject.GetComponent<Barrell_Script>().CreateObject(gameObject);
        }
        if (carryingItem)
        {
            ReleaseItem();
        }
        else if(focusedObject!= null && focusedObject.tag == "PickableObject" )
        {
            carryingItem = true;
            Debug.Log("Pick up");
            carryFocusedObject = true;
            focusedObject.GetComponent<Rigidbody>().useGravity = false;

        }
    }

    private void ReleaseItem()
    {
        focusedObject.GetComponent<Rigidbody>().useGravity = true;
        carryingItem = false;
        carryFocusedObject = false;
        Debug.Log("letting go");
        focusedObject = null;
    }

    private void CarryFocusedObject()
    {
        focusedObject.transform.position = transform.position + (transform.forward * focusedObject.GetComponent<OffsetScript>().offsetX) + new Vector3(0,focusedObject.GetComponent<OffsetScript>().offsetY, 0);
    }
}
