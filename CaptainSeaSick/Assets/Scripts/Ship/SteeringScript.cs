using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SteeringScript : MonoBehaviour
{
    bool inSteeringPosition;
    public InputAction move;
    Vector2 inputVector;
    Quaternion zeroQuaternion;

    GameObject player;
    GameObject ship;

    void Start()
    {
        move.Enable();
        ship = GameObject.FindGameObjectWithTag("Ship");
        zeroQuaternion = new Quaternion(0, 0, 0, ship.transform.rotation.w);
    }
    void Update()
    {
        inputVector = move.ReadValue<Vector2>();
        Debug.Log(inputVector);
        if (inSteeringPosition)
        {
            if (System.Math.Round(ship.transform.rotation.eulerAngles.x) <= 20 || System.Math.Round(ship.transform.rotation.eulerAngles.x) >= 340)
            {
                ship.transform.Rotate(new Vector3(inputVector.y * 0.1f, 0, 0));
            }
            else if (System.Math.Round(ship.transform.rotation.eulerAngles.x) == 21)
            {
                ship.transform.Rotate(new Vector3(-0.01f, 0, 0));
            }
            else if (System.Math.Round(ship.transform.rotation.eulerAngles.x) == 339)
            {
                ship.transform.Rotate(new Vector3(0.01f, 0, 0));
            }
        }
        if(inputVector == new Vector2(0,0))
        {
            ship.transform.rotation = Quaternion.RotateTowards(ship.transform.rotation, zeroQuaternion, (Time.deltaTime * 5));
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inSteeringPosition = true;
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
