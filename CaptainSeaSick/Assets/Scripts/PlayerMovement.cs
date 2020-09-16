using Boo.Lang.Environments;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    GameObject target;

    private Vector2 i_movement;
    private Vector3 cannonBallOffset;
    private Rigidbody rb;
    private bool pickedUp;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        cannonBallOffset = new Vector3(2, -transform.localScale.y/3, 0);
    }


    // Update is called once per frame
    public void Update()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        Vector3 tempVect = new Vector3(i_movement.x, 0, i_movement.y);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + tempVect);

        if (pickedUp)
        {
            target.transform.position = transform.position + cannonBallOffset;
            if (Input.GetButtonUp("Jump"))
            {
                target.GetComponent<Rigidbody>().useGravity = true;
                pickedUp = false;
                target = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickableObject" && !pickedUp)
            target = other.gameObject;
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
    }
    private void OnDrop()
    {

        pickedUp = false;
        target = null;

    }
}
