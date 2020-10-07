using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BoatMovement : MonoBehaviour
{
    private GameObject ship, cliffIndicator;
    private float shipSpeedBasedOnRotation;
    public Vector3 turnVector, indicatorPosition;
    private float timer = 2;

    void Start()
    {

        ship = GameObject.FindGameObjectWithTag("Ship");
        cliffIndicator = GameObject.FindGameObjectWithTag("IndicatorImage");

        indicatorPosition = new Vector3(-34, 0, transform.position.z);

    }
    void Update()
    {

        shipSpeedBasedOnRotation = System.Math.Abs(ship.transform.rotation.x);

        transform.position += new Vector3(0.03f, 0, 0);

        if (ship.GetComponentInChildren<SteeringScript>().GetSteeringBool())
        {
            if (ship.transform.rotation.eulerAngles.x >= 10 && ship.transform.rotation.eulerAngles.x <= 45)
            {
                turnVector = new Vector3(0, 0, -0.1f * shipSpeedBasedOnRotation);
            }
            else if (ship.transform.rotation.eulerAngles.x >= 270 && ship.transform.rotation.eulerAngles.x <= 350)
            {
                turnVector = new Vector3(0, 0, 0.1f * shipSpeedBasedOnRotation);
            }
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
