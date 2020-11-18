using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing_Script : MonoBehaviour
{

    Vector3 moveTo, turnVector;
    float position1, position2, offSet;
    public float boatBobbingSpeed = 0.0025f;
    public float wreckageBobbingSpeed = 1;
    public float xRotation = 0.7f;
    public float zRotation = 0.4f;
    private int randRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (tag == "Ship")
        {
            offSet = 1;
        }
        else
        {
            offSet = 2;
        }

        randRotation = Random.Range(1, 3);

        position1 = transform.position.y;
        position2 = transform.position.y - offSet;

        turnVector = new Vector3(-xRotation, 0, zRotation);

    }

    // Update is called once per frame
    void Update()
    {
        VerticalMovement();

        RotationalMovement();
    }

    private void RotationalMovement()
    {
        if (tag == "Ship")
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
        }
        else // FLOATING WRECKAGE
        {
            if(randRotation <= 1)
            {
                turnVector = new Vector3(0, 8, 0);
            }
            else if (randRotation >= 2)
            {
                turnVector = new Vector3(0, -8, 0);
            }                    
        }
        transform.Rotate(turnVector * Time.deltaTime);
    }

    private void VerticalMovement()
    {
        if (transform.position.y >= position1)
        {
            moveTo = new Vector3(transform.position.x, position2 - 5, transform.position.z);
        }
        if (transform.position.y <= position2)
        {
            moveTo = new Vector3(transform.position.x, position1 + 5, transform.position.z);
        }

        if (tag == "Ship")
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo, boatBobbingSpeed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo, wreckageBobbingSpeed * Time.deltaTime);
        }
    }
}
