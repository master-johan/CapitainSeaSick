using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SteeringScript : MonoBehaviour
{
    public bool inSteeringPosition;
    public InputAction move;
    Vector2 inputVector;
    Quaternion zeroQuaternion;
    Steering_Trigger_Script steeringTrigger;

    GameObject player;
    //GameObject ship;

    public GameObject shipPivot;

    void Start()
    {
        move.Enable();
        //ship = GameObject.FindGameObjectWithTag("Ship");
        zeroQuaternion = new Quaternion(0, 0, 0, shipPivot.transform.rotation.w);
        steeringTrigger = GetComponent<Steering_Trigger_Script>();
    }
    void Update()
    {
        //Reads the value from the rightstick
        inputVector = move.ReadValue<Vector2>();

        if (inSteeringPosition)
        {
            move.Enable();
            //If the player is in the right spot the ship will rotate in the direction of the inputVector.
            if (System.Math.Round(shipPivot.transform.rotation.eulerAngles.x) <= 10 || System.Math.Round(shipPivot.transform.rotation.eulerAngles.x) >= 350)
            {
                shipPivot.transform.Rotate(new Vector3(inputVector.y * 0.1f, 0, 0));
            }

            //Keeps the ship from rotating further than the limit values
            else if (System.Math.Round(shipPivot.transform.rotation.eulerAngles.x) == 11)
            {
                shipPivot.transform.Rotate(new Vector3(-0.01f, 0, 0));
            }
            else if (System.Math.Round(shipPivot.transform.rotation.eulerAngles.x) == 349)
            {
                shipPivot.transform.Rotate(new Vector3(0.01f, 0, 0));
            }
        }
        if(!inSteeringPosition)
        {
            move.Disable();
        }
        //Rotate the ship back if a no/ very little input is given from the controller.
        if (System.Math.Abs(inputVector.y) <= 0.1f)
        {
            shipPivot.transform.rotation = Quaternion.RotateTowards(shipPivot.transform.rotation, zeroQuaternion, (Time.deltaTime * 5));
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inSteeringPosition = true;
            Debug.Log("Gamla script " + inSteeringPosition);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inSteeringPosition = false;

        }
    }
    public bool GetSteeringBool()
    {
        return inSteeringPosition;
    }
}
