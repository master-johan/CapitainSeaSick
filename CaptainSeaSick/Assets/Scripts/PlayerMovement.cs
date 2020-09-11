using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    GameObject target;

    private Vector3 cannonBallOffset;
    private Rigidbody rb;
    private bool pickedUp;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        cannonBallOffset = new Vector3(1, 1, 0);
    }


    // Update is called once per frame
    public void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 tempVect = new Vector3(h, 0, v);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + tempVect);

        if (pickedUp)
        {
            target.transform.position = transform.position + cannonBallOffset;

            if (Input.GetButtonUp("Jump"))
            {
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
        if (target != null)
        {
            if (Input.GetButtonDown("Jump") && !pickedUp)
            {
                pickedUp = true;
                target.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }

        }

    }
}
