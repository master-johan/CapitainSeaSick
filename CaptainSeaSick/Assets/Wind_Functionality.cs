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
        NewWindDirection();
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
                    if (item.GetComponent<PlayerActions>().isBoosting || item.GetComponent<PlayerActions>().isStunned)
                    {
                    }
                    else
                    {
                        item.GetComponent<Rigidbody>().AddForce(windDirection * 3, ForceMode.VelocityChange);
                    }
                }
            }
        }

    }


    public void NewWindDirection()
    {
        windDirection = new Vector3(Random.Range(1f, -1f), 0, Random.Range(1f, -1f));
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
