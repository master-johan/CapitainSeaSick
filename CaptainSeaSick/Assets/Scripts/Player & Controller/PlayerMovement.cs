using Boo.Lang.Environments;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Lumin;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public int playerIndex = 0;
    GameObject target;
    GameObject containerTarget;
    GameObject ship;

    private Vector2 i_movement;
    private Vector2 lastForward;
    private float cannonOffset;
    private float cannonballOffset;
    private Quaternion playerRotation;
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
        playerRotation = transform.rotation;

        Vector3 tempVect = new Vector3(i_movement.x, 0, i_movement.y);
        tempVect = tempVect.normalized * speed * Time.deltaTime;

        if (Math.Abs(i_movement.x) >= 0.125 || Math.Abs(i_movement.y) >= 0.125)
        {
            transform.forward = tempVect.normalized;
            rb.MovePosition(transform.position + tempVect);
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
                if (containerTarget.GetComponent("CannonballBarrel_Script"))
                {
                    containerTarget.GetComponent<CannonballBarrel_Script>().CreateCannonball(transform.position + transform.forward * cannonballOffset);
                    Debug.Log("Added CannonBall");
                }
            }
        }
    }
    private void OnDrop()
    {
        if(target != null)
        {
            if (target.GetComponent("CannonBall"))
            {
                target.GetComponent<CannonBall>().isPickedUp = false;
            }
            target.GetComponent<Rigidbody>().useGravity = true;

            pickedUp = false;
            target = null;
        }


    }

    private void OnInteract()
    {
        if(target != null)
        {
            if (target.GetComponent("Cannon_Script") && target.GetComponent<Cannon_Script>().cannonState == Cannon_Script.CannonState.canFire)
            {
                target.GetComponent<Cannon_Script>().cannonState = Cannon_Script.CannonState.fire;
                target = null;
            }
        }

    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }
}
