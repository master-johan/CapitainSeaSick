using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Functionality : MonoBehaviour
{

    GameObject[] players;
    Vector3 windDirection;

    bool activeWind;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
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
                            item.GetComponent<Rigidbody>().AddForce(windDirection * 3, ForceMode.VelocityChange);
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
    }

    public void ActivateWind()
    {
        if (!activeWind)
        {
            NewWindDirection();
            activeWind = true;
        }

    }
    public void DeactivateWind()
    {
        activeWind = false;
    }
}
