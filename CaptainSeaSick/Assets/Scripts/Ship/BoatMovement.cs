using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BoatMovement : MonoBehaviour
{
    public InputAction move;
    private Vector2 inputVector;
    private Quaternion rotationDirection, zeroQuaternion;
    private GameObject ship, cliffIndicator;
    private float stepSpeed, shipSpeed, shipSpeedBasedOnRotation, rotSpeed;
    public Vector3 turnVector, indicatorPosition;
    private float timer = 2;

    private GameObject levelManager;

    void Start()
    {
        move.Enable();
        stepSpeed = 5f;
        shipSpeed = 0.1f;
        rotSpeed = 0.1f;

        levelManager = GameObject.Find("LevelManager");
        ship = GameObject.FindGameObjectWithTag("Ship");
        cliffIndicator = GameObject.FindGameObjectWithTag("IndicatorImage");
        zeroQuaternion = new Quaternion(0, 0, 0, ship.transform.rotation.w);

        indicatorPosition = new Vector3(-34, 0, transform.position.z);

    }
    void Update()
    {

        shipSpeedBasedOnRotation = System.Math.Abs(ship.transform.rotation.x);


        inputVector = move.ReadValue<Vector2>();
        rotationDirection = ship.transform.rotation;
        float step = Time.deltaTime * stepSpeed;

        transform.position += new Vector3(0.1f, 0, 0);


        if (ship.GetComponentInChildren<SteeringScript>().GetSteeringBool())
        {
            ship.transform.Rotate(new Vector3(inputVector.y * rotSpeed, 0, 0));

            if (ship.transform.rotation.eulerAngles.x >= 10 && ship.transform.rotation.eulerAngles.x <= 45)
            {
                turnVector = new Vector3(0, 0, -1.5f * shipSpeedBasedOnRotation);

            }
            else if (ship.transform.rotation.eulerAngles.x >= 270 && ship.transform.rotation.eulerAngles.x <= 350)
            {
                turnVector = new Vector3(0, 0, 1.5f * shipSpeedBasedOnRotation);
            }
        }
        else if (!ship.GetComponentInChildren<SteeringScript>().GetSteeringBool())
        {
            ship.transform.rotation = Quaternion.RotateTowards(rotationDirection, zeroQuaternion, step);
        }
        if (ship.transform.rotation.eulerAngles.x <= 10 || ship.transform.rotation.eulerAngles.x >= 350)
        {    
            turnVector = new Vector3(0, 0, 0);
        }


        indicatorPosition = new Vector3(-34, 0, transform.position.z);
        cliffIndicator.transform.position = indicatorPosition;
        transform.position += turnVector;
    }
    private void OnDestroy()
    {
        cliffIndicator.transform.position = new Vector3(200, 200, 200);
    }
}
