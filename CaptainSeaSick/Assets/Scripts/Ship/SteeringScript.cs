using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SteeringScript : MonoBehaviour
{
    public bool inSteeringPosition;
    Vector2 inputVector;
    Quaternion zeroQuaternion;
    public GameObject controllingPlayer, debris, water;

    GameObject player;
    GameObject ship;
    GameObject wheel;

    Vector3 turnVector;

    public GameObject shipPivot;

    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
        zeroQuaternion = new Quaternion(0, 0, 0, shipPivot.transform.rotation.w);
        wheel = GameObject.Find("SteeringWheel");
    }
    void FixedUpdate()
    {
        if (IsControlled())
        {
            inputVector = controllingPlayer.GetComponent<PlayerActions>().GetPlayerAxisInput();

            //If the player is in the right spot the ship will rotate in the direction of the inputVector.
            if (System.Math.Round(shipPivot.transform.rotation.eulerAngles.x) <= 10 || System.Math.Round(shipPivot.transform.rotation.eulerAngles.x) >= 350)
            {
                shipPivot.transform.Rotate(new Vector3(inputVector.y * 0.1f, 0, 0));
                wheel.transform.Rotate(new Vector3(0, -inputVector.y * 1f, 0));
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

            MoveWaterAndDebris();
        }
        if (water != null)
        {
            water.transform.position += (turnVector) * Time.deltaTime;
        }
        foreach (var item in debris.GetComponent<SceneDecor_Functionality>().TempDecorList)
        {
            item.transform.position += (turnVector) * Time.deltaTime;
        }


        //Rotate the ship back if a no/ very little input is given from the controller.
        if (System.Math.Abs(inputVector.y) <= 0.1f)
        {
            shipPivot.transform.rotation = Quaternion.RotateTowards(shipPivot.transform.rotation, zeroQuaternion, (Time.deltaTime * 5));
            wheel.transform.rotation = Quaternion.RotateTowards(wheel.transform.rotation, new Quaternion(0,0,0.7f,0.7f), (Time.deltaTime * 70));
        }

    }

    private void MoveWaterAndDebris()
    {
        if (shipPivot.transform.rotation.eulerAngles.x >= 10 && shipPivot.transform.rotation.eulerAngles.x <= 45)
        {
            turnVector = new Vector3(0, 0, -10);
        }
        else if (shipPivot.transform.rotation.eulerAngles.x >= 270 && shipPivot.transform.rotation.eulerAngles.x <= 350)
        {
            turnVector = new Vector3(0, 0, 10);
        }
        if (shipPivot.transform.rotation.eulerAngles.x <= 10 || shipPivot.transform.rotation.eulerAngles.x >= 350)
        {
            turnVector = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inSteeringPosition = true;

            player = other.gameObject;
            other.GetComponent<PlayerActions>().SetFocus(transform.gameObject, 0, 0);

            Debug.Log("Gamla script " + inSteeringPosition);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inSteeringPosition = false;
            player = null;
            other.GetComponent<PlayerActions>().SetFocus(null, 0, 0);
        }
    }
    public bool GetSteeringBool()
    {
        return inSteeringPosition;
    }

    private bool IsControlled()
    {
        if (controllingPlayer != null)
        {
            return true;
        }
        return false;
    }
}
