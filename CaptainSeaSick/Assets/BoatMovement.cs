using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoatMovement : MonoBehaviour
{
    public SteeringScript steeringScript;
    public InputActionMap shipActionInput;
    // Start is called before the first frame update
    void Start()
    {
        shipActionInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //if(steeringScript.GetPlayer() != null)
        //{
           // Debug.Log(steeringScript.GetPlayer());

            if (shipActionInput.FindAction("StickToSteeringPos").triggered && steeringScript.GetSteeringBool())
            {
                //steeringScript.GetPlayer().transform.SetParent(transform);

                if (shipActionInput.FindAction("MoveUp").triggered && steeringScript.GetSteeringBool())
                {
                    gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0, 0, 1));

                }
                if (shipActionInput.FindAction("MoveDown").triggered && steeringScript.GetSteeringBool())
                {
                    gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0, 0, -1));

                }
            }
        //}
         
    }

}
