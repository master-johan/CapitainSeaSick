using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBehaviour : MonoBehaviour
{
    public float healthPoint = 10f;
    public GameObject cannonBall;
    public float timer = 5f;
    private Vector3 target;
    private GameObject tempCannonBall;
    void Start()
    {
        //transform.forward = new Vector3(0, 0, 0);
        
        if (transform.position == new Vector3(-59, -4, 51) || transform.position == new Vector3(-90, -4, -51)) // L1 & R1
        {
            target = new Vector3(-23, -5, -0.5f);
        }
        else if (transform.position == new Vector3(-13, -4, 85) || transform.position == new Vector3(-13, -4, -85)) //L2 & R2
        {
            target = new Vector3(-13, -5, -0.5f);
        }
        else
        {
            target = new Vector3(0, -5, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cannonBall != null)
        {
            
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                tempCannonBall = Instantiate(cannonBall, transform.position, Quaternion.identity);

                timer = 5f;
            }

            if(tempCannonBall != null)
            {
                tempCannonBall.transform.position = Vector3.MoveTowards(tempCannonBall.transform.position, target, 0.2f);

                if (tempCannonBall.GetComponent<EnemyCannonBallScript>().cannonBallHit)
                {
                    Destroy(tempCannonBall);
                }
            }
 

        }

    }
}
