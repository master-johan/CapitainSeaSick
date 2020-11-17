using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing_Script : MonoBehaviour
{

    Vector3 pos1, pos2, offSet, moveTo, turnVector, turnVelocity;
    public float verticalMoveSpeed = 0.0025f;
    public float xRotation = 0.7f;
    public float zRotation = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        offSet = Vector3.down;
        pos1 = transform.position;
        pos2 = transform.position + offSet;

        turnVector = new Vector3(-xRotation, 0, zRotation);

    }

    // Update is called once per frame
    void Update()
    {
        if(tag == "Ship")
        {
            VerticalMovement();
        }

        RotationalMovement();

    }

    private void RotationalMovement()
    {
        // Z-Rotation 
        if (transform.rotation.eulerAngles.z >= 2 && transform.rotation.eulerAngles.z <= 45)
        {
            turnVector = new Vector3(turnVector.x, 0, -zRotation);
        }
        else if (transform.rotation.eulerAngles.z <= 358 && transform.rotation.eulerAngles.z >= 270)
        {
            turnVector = new Vector3(turnVector.x, 0, zRotation);
        }

        // X-Rotation
        if (transform.rotation.eulerAngles.x >= 1 && transform.rotation.eulerAngles.x <= 45)
        {
            turnVector = new Vector3(-xRotation, 0, turnVector.z);
        }
        else if (transform.rotation.eulerAngles.x <= 356 && transform.rotation.eulerAngles.x >= 270)
        {
            turnVector = new Vector3(xRotation, 0, turnVector.z);
        }

        transform.Rotate(turnVector * Time.deltaTime);
        
    }

    private void VerticalMovement()
    {
        if (transform.position == pos1)
        {
            moveTo = pos2;
        }
        if (transform.position == pos2)
        {
            moveTo = pos1;
        }

        transform.position = Vector3.MoveTowards(transform.position, moveTo, verticalMoveSpeed);
    }
}
