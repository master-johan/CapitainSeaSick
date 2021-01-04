using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Functionality : MonoBehaviour
{
    public GameObject windPointer;
    GameObject tempPointer;
    GameObject[] players;
    public Vector3 windDirection;

    bool activeWind;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
        Debug.Log(windDirection);
        if (activeWind)
        {
            players = GameObject.FindGameObjectsWithTag("Player");



            if (GameAssets.instance.windActivated)
            {

                foreach (var item in players)
                {
                    if (item.GetComponent<PlayerActions>().playerState == PlayerState.climbing)
                    {
                    }
                    else
                    {
                        if (item.GetComponent<PlayerActions>().isGrounded())
                        {
                            item.GetComponent<Rigidbody>().AddForce(windDirection, ForceMode.VelocityChange);
                        }
                        if (item.GetComponent<PlayerInputs>().LeftStick == Vector2.zero || item.GetComponent<PlayerActions>().isStunned)
                        {
                            item.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(item.GetComponent<Rigidbody>().velocity, 3);
                        }
                    }
                }
            }
        }

    }


    public void NewWindDirection()
    {
        windDirection = new Vector3(UnityEngine.Random.Range(1f, -1f), 0, UnityEngine.Random.Range(1f, -1f));
        windDirection.Normalize();
    }

    public void ActivateWind()
    {
        if (!activeWind)
        {
            tempPointer = Instantiate(windPointer, new Vector3(18, 3, 41), Quaternion.identity);
            NewWindDirection();
            activeWind = true;
        }

    }
    public void DeactivateWind()
    {
        activeWind = false;
        Destroy(tempPointer);
    }
}
