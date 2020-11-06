using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PointToPoint_Script : MonoBehaviour
{
    public Animator animator;
    public int speed;
    public bool switchDirection;
    public GameObject[] movingPoints; // Only create new Empty GameObjects as Children to the enemy to add new moving points.(Using its transform)    

    Vector3 targetDirection, currentMoveSpot;

    Vector3[] moveSpots;

    int nrOfMoveSpots, currentMoveSpotNr;

    float distToMoveSpot, minDist;

    void Start()
    {
        CreatingMovingDestiationsFromGameObjects();
        minDist = 0.5f;
        currentMoveSpotNr = 0;
        animator.SetBool("isRunningInFear", true);
    }

    void Update()
    {
        ChangingPointToMoveTowards();

        targetDirection = currentMoveSpot;
        transform.forward = targetDirection - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetDirection, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!other.isTrigger)
            {
                other.GetComponent<PlayerManagement>().PlayerRespawn();
            }
        }
    }
    private void ChangingPointToMoveTowards()
    {
        distToMoveSpot = Vector3.Distance(transform.position, currentMoveSpot);

        if (distToMoveSpot < minDist)
        {
            if (currentMoveSpotNr >= moveSpots.Length - 1)
            {
                currentMoveSpotNr = 0;
            }
            else
            {
                currentMoveSpotNr++;
            }

            if (switchDirection) // This only applies when the bool "Switch directions" is active in the inspector
            {
                int rnd = Random.Range(1, 5);
                if (rnd > 3)
                {
                    Vector3[] reversedList = new Vector3[moveSpots.Length];
                    int index = moveSpots.Length - 1;
                    for (int i = 0; i < moveSpots.Length; i++)
                    {
                        reversedList[i] = moveSpots[index];
                        index--;
                    }
                    moveSpots = reversedList;

                    if (currentMoveSpotNr % 2 != 0)
                    {
                        currentMoveSpotNr = 0;
                    }
                }              
            }
        }
        currentMoveSpot = moveSpots[currentMoveSpotNr];
    }
    private void CreatingMovingDestiationsFromGameObjects()
    {
        for (int i = 0; i < movingPoints.Length; i++)
        {
            nrOfMoveSpots++;
        }

        moveSpots = new Vector3[nrOfMoveSpots];

        for (int i = 0; i < moveSpots.Length; i++)
        {
            moveSpots[i] = movingPoints[i].transform.position;
        }
    }
}
