using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.WSA.Input;


public enum PlayerState { carrying, free, interacting, climbing };
public class PlayerActions : MonoBehaviour
{
    public float speed = 6;
    Vector3 direction;
    PlayerInputs playerInputs;
    public PlayerState playerState;
    public GameObject focusedObject;
    Vector2 focusedObjectOffset;
    public  Rigidbody rb;
    GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
        rb = GetComponent<Rigidbody>();
        playerInputs = GetComponent<PlayerInputs>();
        playerState = PlayerState.free;
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerState)
        {
            case PlayerState.carrying:
                CarryFocusedObject();
                break;
            case PlayerState.free:
                break;
            case PlayerState.interacting:
                break;

            default:
                break;
        }
        PlayerMovement(playerInputs.LeftStick);

    }

    void PlayerMovement(Vector2 input)
    {


        if (playerState == PlayerState.climbing)
        {
            direction = focusedObject.transform.up * input.y * speed;

            if (Math.Abs(input.x) >= 0.125 || Math.Abs(input.y) >= 0.125)
            {
                //direction.y = rb.velocity.y;
                rb.velocity = direction;

            }
            else
            {
                rb.velocity = Vector3.zero;
            }

        }
        else
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
            
            //var rotation = ship.transform.eulerAngles.x;
            //transform.Rotate( rotation, transform.eulerAngles.y, transform.eulerAngles.z);

        }


    }

    public void SetFocus(GameObject target, float offsetX, float offsetY)
    {
        //if (target == null)
        //{

        //    playerState = PlayerState.free;
        //    return;
        //}
        if (playerState == PlayerState.free)
        {
            Debug.Log("Got a new focus");
            focusedObject = target;
            focusedObjectOffset = new Vector2(offsetX, offsetY);
        }
        else
        {
            return;
        }
    }

    public void PickUp()
    {
        switch (playerState)
        {
            case PlayerState.carrying:
                ReleaseItem();
                break;
            case PlayerState.free:
                if (focusedObject != null)
                {
                    if (focusedObject.tag == "PickableObject")
                    {
                        PickingUpObject();
                    }
                    else if (focusedObject.tag == "Container")
                    {
                        SpawingFromContainer();
                    }
                }
                break;
            case PlayerState.interacting:
                break;
            default:
                break;
        }
    }

    private void SpawingFromContainer()
    {
        GameObject toSpawn = focusedObject.GetComponent<Barrell_Script>().CreateObject(gameObject);
        SetFocus(toSpawn, toSpawn.GetComponent<OffsetScript>().offsetX, toSpawn.GetComponent<OffsetScript>().offsetY);
        PickingUpObject();
    }

    private void PickingUpObject()
    {
        playerState = PlayerState.carrying;
        //focusedObject.GetComponentInChildren<PickUp_Trigger_Script>().StartDropTimer();
        focusedObject.GetComponentInChildren<PickUp_Trigger_Script>().PickedUp(gameObject);
        Debug.Log("Pick up");
        //focusedObject.GetComponent<Rigidbody>().detectCollisions = false;
        //focusedObject.GetComponent<Rigidbody>().useGravity = false;

    }

    private void ReleaseItem()
    {
        //focusedObject.GetComponent<Rigidbody>().detectCollisions = true;
        //focusedObject.GetComponent<Rigidbody>().useGravity = true;
        focusedObject.GetComponentInChildren<PickUp_Trigger_Script>().Released();
        Debug.Log("letting go");
        //focusedObject = null;
        playerState = PlayerState.free;
    }

    private void CarryFocusedObject()
    {
        if (focusedObject != null)
        {
            focusedObject.transform.position = transform.position +
                                               (transform.forward *
                                               focusedObject.GetComponent<OffsetScript>().offsetX) +
                                               new Vector3(0, focusedObject.GetComponent<OffsetScript>().offsetY,
                                               0);
            focusedObject.transform.right = transform.forward;
        }
    }

    public void Interact()
    {
        if (focusedObject != null)
        {

            if (playerState == PlayerState.free)
            {
                if (focusedObject.GetComponent<MastBot_Trigger_Script>())
                {
                    StartClimb();
                    return;
                }
                else
                {
                    playerState = focusedObject.GetComponent<Interactable_Script>().Interact();
                    return;
                }

            }
            if (playerState == PlayerState.climbing)
            {
                StopClimb();
            }
        }


    }

    public void StartClimb()
    {
        playerState = PlayerState.climbing;
        rb.useGravity = false;
    }

    public  void StopClimb()
    {
        playerState = PlayerState.free;
        rb.useGravity = true;
    }
}
