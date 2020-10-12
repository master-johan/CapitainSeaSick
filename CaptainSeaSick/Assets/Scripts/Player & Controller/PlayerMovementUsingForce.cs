using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementUsingForce : MonoBehaviour
{
    public float speed = 100f;
    public int playerIndex = 0;
    GameObject target;
    GameObject containerTarget;

    private Vector2 i_movement;
    private float cannonOffset;
    private float cannonballOffset;
    private Rigidbody rb;
    private bool pickedUp;

    Vector3 tempVect;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        cannonOffset = 2;
        cannonballOffset = 0.7f;
    }


    // Update is called once per frame
    public void Update()
    {
        if(ControllerMenuJoinScript.playerReady)
        {
            tempVect = new Vector3(i_movement.x, 0, i_movement.y);
            tempVect = tempVect * speed;

            if (Math.Abs(i_movement.x) >= 0.125 || Math.Abs(i_movement.y) >= 0.125)
            {
                
                transform.forward = tempVect.normalized;

                tempVect.y = rb.velocity.y;
                rb.velocity = tempVect;
            }

            if (pickedUp)
            {
                //Different offsets depending on which item is picked up.
                if (target.gameObject.GetComponent("Cannon_Script"))
                {
                    target.transform.position = transform.position + transform.forward * cannonOffset;
                    target.transform.right = transform.forward;
                }
                else if (target.GetComponent("CannonBall"))
                {
                    target.transform.position = transform.position + transform.forward * cannonballOffset;
                    target.GetComponent<CannonBall>().isPickedUp = true;
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

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickableObject" && !pickedUp)
        {
            target = other.gameObject;
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
        }
        if (other.tag == "PickableObject" && !pickedUp)
        {
            target = null;
            pickedUp = false;
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnMove(InputValue value)
    {
        //Saves the value from the controller into a vector which is used to steer the character.
        i_movement = value.Get<Vector2>();
    }
    private void OnPickUp()
    {
        if (target != null)
        {
            if (!pickedUp)
            {
                //Remove gravity is the target is picked up.
                target.GetComponent<Rigidbody>().useGravity = false;
                pickedUp = true;
            }
        }
        else if (containerTarget != null)
        {
            if (!pickedUp)
            {
                if (containerTarget.GetComponent("Barrell_Script"))
                {
                    containerTarget.GetComponent<Barrell_Script>().CreateObject(transform.position);
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

            target.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
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

    private void OnBoost()
    {
        Vector3 boostVec = transform.forward;
        Vector3 currentVel = rb.velocity;
        rb.AddForce(currentVel + (boostVec * 1000), ForceMode.Impulse);
    }
}