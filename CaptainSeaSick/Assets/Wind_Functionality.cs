using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Functionality : MonoBehaviour
{

    GameObject[] players;

    void Start()
    {
    }

    void Update()
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
                    item.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.VelocityChange);
                }



                //item.GetComponent<Rigidbody>().velocity += transform.forward;
            }

        }
    }
}
