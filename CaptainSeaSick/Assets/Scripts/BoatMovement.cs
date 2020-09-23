using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoatMovement : MonoBehaviour
{
    public InputAction move;
    private Vector2 inputVector;
    private Quaternion rotationDirection, zeroQuaternion;
    private GameObject ship;
    private float speed = 4f;

    void Start()
    {
        move.Enable();

        ship = GameObject.FindGameObjectWithTag("Ship");

        zeroQuaternion = new Quaternion(0, 0, 0, ship.transform.rotation.w);
    }
    void Update()
    {
        inputVector = move.ReadValue<Vector2>();
        rotationDirection = ship.transform.rotation;
        float step = Time.deltaTime * speed;

        transform.position += new Vector3(0.05f, 0, 0);

        if (ship.GetComponentInChildren<SteeringScript>().GetSteeringBool())
        {
            transform.position += new Vector3(0, 0, inputVector.y * 0.1f);
            ship.transform.Rotate(new Vector3(inputVector.y * 0.05f, 0, 0));
        }
        else if (!ship.GetComponentInChildren<SteeringScript>().GetSteeringBool())
        {
            ship.transform.rotation = Quaternion.RotateTowards(rotationDirection, zeroQuaternion, step);
          
        }
    }
}
