using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BoatMovement : MonoBehaviour
{
    private GameObject shipPivot,ship, cliffIndicator;
    public Vector3 turnVector, indicatorPosition;
    Vector3 velocity;
    

    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
        shipPivot = GameObject.FindGameObjectWithTag("ShipContainer");
        cliffIndicator = GameObject.FindGameObjectWithTag("IndicatorImage");
        velocity = new Vector3(-GameAssets.instance.cliffSpeed, 0, 0);
    }
    void Update()
    {
        SteeringTheShip();
    }

    private void SteeringTheShip()
    {
       
        //Move the cliffs toward the boat
        //transform.position -= new Vector3(GameAssets.instance.cliffSpeed, 0, 0) * Time.deltaTime;

        //If a player is in the right spot then move the cliffs either up or down depending on which way the player rotates the ship.

        if (ship.GetComponentInChildren<SteeringScript>().GetSteeringBool())
        {
            Debug.Log("EULER X = " + shipPivot.transform.rotation.eulerAngles.x);
            if (shipPivot.transform.rotation.eulerAngles.x >= 10 && shipPivot.transform.rotation.eulerAngles.x <= 45)
            {
                turnVector = new Vector3(0, 0, -GameAssets.instance.cliffSpeed);
            }
            else if (shipPivot.transform.rotation.eulerAngles.x >= 270 && shipPivot.transform.rotation.eulerAngles.x <= 350)
            {
                turnVector = new Vector3(0, 0, GameAssets.instance.cliffSpeed);
            }
        }

        //Dont turn if the ship is not rotated enough.
        if (shipPivot.transform.rotation.eulerAngles.x <= 10 || shipPivot.transform.rotation.eulerAngles.x >= 350)
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
        transform.position += (turnVector + velocity) * Time.deltaTime;
    }
    private void OnDestroy()
    {
        //Move away the indicator if the cliff is destoryed.
        cliffIndicator.transform.position = new Vector3(600, 200, 200);
    }
}
