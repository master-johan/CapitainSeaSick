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

    void Start()
    {
        
        ship = GameObject.FindGameObjectWithTag("Ship");
        cliffIndicator = GameObject.FindGameObjectWithTag("IndicatorImage");

    }
    void Update()
    {
        //Take the value of the rotation and save it.
        shipSpeedBasedOnRotation = System.Math.Abs(ship.transform.rotation.x);

        //Move the cliffs toward the boat
        transform.position -= new Vector3(GameAssets.instance.cliffSpeed, 0, 0) * Time.deltaTime;

        //If a player is in the right spot then move the cliffs either up or down depending on which way the player rotates the ship.

        if (ship.GetComponentInChildren<SteeringScript>().GetSteeringBool())
        {
            if (ship.transform.rotation.eulerAngles.x >= 10 && ship.transform.rotation.eulerAngles.x <= 45)
            {
                turnVector = new Vector3(0, 0, -0.15f * shipSpeedBasedOnRotation);
            }
            else if (ship.transform.rotation.eulerAngles.x >= 270 && ship.transform.rotation.eulerAngles.x <= 350)
            {
                turnVector = new Vector3(0, 0, 0.15f * shipSpeedBasedOnRotation);
            }
        }

        //Dont turn if the ship is not rotated enough.
        if (ship.transform.rotation.eulerAngles.x <= 10 || ship.transform.rotation.eulerAngles.x >= 350)
        {    
            turnVector = new Vector3(0, 0, 0);
        }

        //Move the indicator to the cliff
        indicatorPosition = new Vector3(14, 0, transform.position.z);
        if (cliffIndicator != null)
        {
            cliffIndicator.transform.position = indicatorPosition;
        }

        //Used to move the cliff up or down.
        transform.position += turnVector;
    }
    private void OnDestroy()
    {
        //Move away the indicator if the cliff is destoryed.
        cliffIndicator.transform.position = new Vector3(600, 200, 200);
    }
}
