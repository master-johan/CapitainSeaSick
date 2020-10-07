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
    GameObject menuSystemController;

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

        menuSystemController = GameObject.FindGameObjectWithTag("ControllerMenuSystem");
        ship = GameObject.FindGameObjectWithTag("Ship");
    }


    // Update is called once per frame
    public void Update()
    {
        if(ControllerMenuJoinScript.playerReady)
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
        if (other.tag == "PickableObject")
        {
            if (other == target)
            {
                target = null;
                pickedUp = false;
                other.GetComponent<Rigidbody>().useGravity = true;
            }
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

}
