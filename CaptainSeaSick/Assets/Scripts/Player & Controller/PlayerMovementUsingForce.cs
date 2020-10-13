using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    public bool pickedUp;

    Vector3 tempVect;

    private bool pickUpActionTriggered = true;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        cannonOffset = 2;
        cannonballOffset = 0.7f;
    }


    // Update is called once per frame
    public void Update()
    {
        if (ControllerMenuJoinScript.playerReady)
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
                    TargetOffsetPosition(cannonOffset);
                    target.transform.right = transform.forward;
                }
                else if (target.GetComponent("CannonBall"))
                {
                    TargetOffsetPosition(cannonballOffset);
                    target.GetComponent<CannonBall>().isPickedUp = true;
                }
                else if (target.GetComponent("Plank_Script"))
                {
                    TargetOffsetPosition(cannonballOffset);
                    target.GetComponent<Plank_Script>().isPickedUp = true;
                }
                else
                {
                    TargetOffsetPosition(cannonballOffset);
                }
            }
        }


    }

    private void TargetOffsetPosition(float offset)
    {
        target.transform.position = transform.position + transform.forward * offset;
        target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + (target.transform.position.y / 4), target.transform.position.z);
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PickableObject" && !pickedUp)
        {
            target = other.gameObject;
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

    private void OnMove(InputValue value)
    {
        //Saves the value from the controller into a vector which is used to steer the character.
        i_movement = value.Get<Vector2>();
    }
    private void OnPickUp()
    {
        // sets the bool to the other value of what it is right now
        pickUpActionTriggered ^= true;

        if (pickUpActionTriggered)
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
                {   // When you press A and is close to a barrell, then create an object from "inside" the barrell.
                    if (containerTarget.GetComponent("Barrell_Script"))
                    {
                        containerTarget.GetComponent<Barrell_Script>().CreateObject(transform.position);
                        target = containerTarget.GetComponent<Barrell_Script>().tempObject;
                        PickUpOrDropItem(true);
                        pickedUp = true;

                    }
                }
            }
        }
        else
        {
            if (target != null)
            {
                PickUpOrDropItem(false);
                target.GetComponent<Rigidbody>().useGravity = true;

                target.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                pickedUp = false;
                target = null;
            }
        }

    }

    private void PickUpOrDropItem(bool tempBool)
    {
        if (target.GetComponent("CannonBall"))
        {
            target.GetComponent<CannonBall>().isPickedUp = tempBool;
        }
        if (target.GetComponent("Plank_Script"))
        {
            target.GetComponent<Plank_Script>().isPickedUp = tempBool;
        }
    }

    /// <summary>
    /// First checks if a cannon is the players target, then checks if the cannon is inside the "canFire" state which means that it is on a triggerspot and has a cannonball inside.
    /// Then turns the cannons state to fire.
    /// </summary>
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