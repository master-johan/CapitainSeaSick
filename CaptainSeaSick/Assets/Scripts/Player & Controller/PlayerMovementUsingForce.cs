using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementUsingForce : MonoBehaviour
{
    public float speed = 100f;
    public int playerIndex = 0;
    GameObject target;
    GameObject containerTarget;
    GameObject ship;

    private Vector2 i_movement;
    private float cannonOffset;
    private float cannonballOffset;
    private Rigidbody rb;
    private bool pickedUp, inSteeringPlace;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        cannonOffset = 2;
        cannonballOffset = 0.7f;

        ship = GameObject.FindGameObjectWithTag("Ship");
    }


    // Update is called once per frame
    public void Update()
    {

        Vector3 tempVect = new Vector3(i_movement.x, 0, i_movement.y);
        tempVect = tempVect * speed;

        if (Math.Abs(i_movement.x) >= 0.125 || Math.Abs(i_movement.y) >= 0.125)
        {
            transform.forward = tempVect.normalized;

            tempVect.y = rb.velocity.y;
            rb.velocity = tempVect;
        }

        if (pickedUp)
        {
            if (target.gameObject.GetComponent("Cannon_Script"))
            {
                target.transform.position = transform.position + transform.forward * cannonOffset;
                target.transform.right = transform.forward;
            }
            else if (target.GetComponent("CannonBall"))
            {
                target.transform.position = transform.position + transform.forward * cannonballOffset;
                target.GetComponent<CannonBall>().isPickedUp = true;
                // target.GetComponent < Rigidbody >().isKinematic = false;
            }
            else if (target.GetComponent("Plank_Script"))
            {
                target.transform.position = transform.position + transform.forward * cannonballOffset;
                target.GetComponent<Plank_Script>().isPickedUp = true;
            }
            else
            {
                target.transform.position = transform.position + transform.forward * cannonballOffset;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickableObject" && !pickedUp)
        {
            target = other.gameObject;
            Debug.Log("Picked up: " + other.gameObject.name);
        }

        else if (other.tag == "Container" && !pickedUp)
        {
            containerTarget = other.gameObject;
        }

       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Container")
        {
            containerTarget = null;
            Debug.Log("Exited Container");
        }
        if (other.tag == "PickableObject")
        {
            target = null;
            pickedUp = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
    }
    private void OnPickUp()
    {
        if (target != null)
        {
            if (!pickedUp)
            {
                target.GetComponent<Rigidbody>().useGravity = false;
                pickedUp = true;
                target.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
        else if (containerTarget != null)
        {
            if (!pickedUp)
            {
                if (containerTarget.GetComponent("Barrell_Script"))
                {
                    containerTarget.GetComponent<Barrell_Script>().CreateObject(transform.position + transform.forward * cannonballOffset);
                }
            }
        }
    }
    private void OnDrop()
    {
        if (target != null)
        {
            if (target.GetComponent("CannonBall"))
            {
                target.GetComponent<CannonBall>().isPickedUp = false;
            }
            if (target.GetComponent("Plank_Script"))
            {
                target.GetComponent<Plank_Script>().isPickedUp = false;
            }
            target.GetComponent<Rigidbody>().useGravity = true;

            pickedUp = false;
            target = null;
        }


    }

    private void OnInteract()
    {
        if (target != null)
        {
            if (target.GetComponent("Cannon_Script") && target.GetComponent<Cannon_Script>().cannonState == Cannon_Script.CannonState.canFire)
            {
                target.GetComponent<Cannon_Script>().cannonState = Cannon_Script.CannonState.fire;
                target = null;
            }
        }

    }

}
