using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickUp { pickedUp, free}
public class PickUp_Trigger_Script : MonoBehaviour
{
    OffsetScript offset;
    public float dropTimer = 0.2f;
    float currentDropTimer;
    bool countingDown;
    public PickUp pickUpStatus;
    Rigidbody rb;

    private void Start()
    {
        OffsetScript offset = GetComponent<OffsetScript>();
        rb = transform.parent.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    private void FixedUpdate()
    {
        if (countingDown)
        {
            currentDropTimer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Enter" + transform.parent.name);
            other.GetComponent<PlayerActions>().SetFocus(transform.parent.gameObject, offset.offsetX, offset.offsetY);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && currentDropTimer <= 0)
        {
            Debug.Log("Player Exit");
            PlayerActions pa = other.GetComponent<PlayerActions>();
            if (pa.focusedObject = transform.parent.gameObject)
            {
                pa.SetFocus(null, 0, 0);
            }
            currentDropTimer = dropTimer;
        }
    }

    public void StartDropTimer()
    {
        countingDown = true;

    }

    public void PickedUp()
    {
        if (pickUpStatus == PickUp.free)
        {
            rb.detectCollisions = false;
            rb.useGravity = false;
        }
        
    }
    public void Released()
    {
        if (pickUpStatus == PickUp.pickedUp)
        {
            rb.detectCollisions = true;
            rb.useGravity = true;
        }
       
    }
}
