using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoatMovement : MonoBehaviour
{
    public InputAction move;
    private Vector2 inputVector;
    private GameObject ship;

    void Start()
    {
        move.Enable();

        ship = GameObject.FindGameObjectWithTag("Ship");        
    }
    void Update()
    {
        inputVector = move.ReadValue<Vector2>();

        transform.position += new Vector3(0.05f, 0, 0);

        if (ship.GetComponentInChildren<SteeringScript>().GetSteeringBool())
        {
            transform.position += new Vector3(0, 0, inputVector.y * 0.1f);
        }
    }
}
