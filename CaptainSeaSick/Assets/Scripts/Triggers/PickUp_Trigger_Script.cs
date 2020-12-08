using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickUp { free, pickedUp }
public class PickUp_Trigger_Script : MonoBehaviour
{
    OffsetScript offset;
    public float dropTimer = 0.2f;
    bool isActive;
    public PickUp pickUpStatus;
    Rigidbody rb;
    GameObject player;



    private void Awake()
    {
        offset = transform.parent.GetComponent<OffsetScript>();
        rb = transform.parent.GetComponent<Rigidbody>();
        pickUpStatus = PickUp.free;
        isActive = true;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            if (pickUpStatus == PickUp.free)
            {
                if (other.tag == "Player")
                {
                    Debug.Log("Player Enter" + transform.parent.name);
                    other.GetComponent<PlayerActions>().SetFocus(transform.parent.gameObject, offset.offsetX, offset.offsetY);
                    //GetComponentInParent<Outline>().OutlineMode = Outline.Mode.OutlineAndSilhouette;

                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (isActive)
        {
            if (pickUpStatus == PickUp.free)
            {
                if (other.tag == "Player")
                {
                    Debug.Log("Player Exit");
                    PlayerActions pa = other.GetComponent<PlayerActions>();
                    //pa.focusedObject.GetComponentInParent<Outline>().OutlineMode = Outline.Mode.SilhouetteOnly;

                    if (pa.focusedObject == transform.parent.gameObject)
                    {
                        pa.SetFocus(null, 0, 0);
                    }

                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isActive)
        {
            if (other.tag == "Player")
            {
                if (pickUpStatus == PickUp.free)
                {
                    PlayerActions pa = other.GetComponent<PlayerActions>();
                    if (pa.focusedObject == null)
                    {
                        //GetComponentInParent<Outline>().OutlineMode = Outline.Mode.OutlineAndSilhouette;

                        pa.SetFocus(transform.parent.gameObject, offset.offsetX, offset.offsetY);
                    }

                }
            }

        }
    }


    public void PickedUp(GameObject player)
    {
        if (pickUpStatus == PickUp.free)
        {
            //Debug.Log("is this happening" + GetComponentInParent<SwordTag_Script>());

            if (CheckIfCollitionsShouldBeDeactivated())
            {
                rb.detectCollisions = false;
            }

            this.player = player;
            rb.useGravity = false;
            pickUpStatus = PickUp.pickedUp;
        }
    }
    public void Released()
    {
        if (pickUpStatus == PickUp.pickedUp)
        {
            rb.detectCollisions = true;
            rb.useGravity = true;
            pickUpStatus = PickUp.free;
        }

    }

    public void Disable()
    {
        if (player != null)
        {
            player.GetComponent<PlayerActions>().SetFocus(null, 0, 0);
        }
        isActive = false;
    }

    private bool CheckIfCollitionsShouldBeDeactivated()
    {
        if (GetComponentInParent<SwordTag_Script>())
        {
            return false;
        }
        if (GetComponentInParent<Bucket_Trigger_Script>())
        {
            return false;
        }
        if (GetComponentInParent<Key_Trigger_Script>())
        {
            return false;
        }
        if (GetComponentInParent<Chest_Trigger_Script>())
        {
            return false;
        }
        if (GetComponentInParent<Bag_Trigger_Script>())
        {
            return false;
        }

        return true;
    }
}
