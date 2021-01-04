using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PointToPoint_Script : MonoBehaviour
{
    public Animator animator;
    public int speed;
    public bool switchDirection;
    public GameObject[] movingPoints; // Only create new Empty GameObjects as Children to the enemy to add new moving points.(Using its transform)  
    public bool boardingEnemy;

    Vector3 targetDirection, currentMoveSpot;

    Vector3[] moveSpots;

    int nrOfMoveSpots, currentMoveSpotNr;

    float distToMoveSpot, minDist;

    void Start()
    {
        if(boardingEnemy)
        {

            if(transform.gameObject.name == "Enemy_Left(Clone)")
            {
                movingPoints = new GameObject[GameObject.FindGameObjectsWithTag("MovespotLeft").Length];
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("MovespotLeft").Length; i++)
                {
                    movingPoints[i] = GameObject.FindGameObjectsWithTag("MovespotLeft")[i];
                }
            }
            if (transform.gameObject.name == "Enemy_Right(Clone)")
            {
                movingPoints = new GameObject[GameObject.FindGameObjectsWithTag("MovespotRight").Length];
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("MovespotRight").Length; i++)
                {
                    movingPoints[i] = GameObject.FindGameObjectsWithTag("MovespotRight")[i];
                }
            }
            if (transform.gameObject.name == "Enemy_Top(Clone)")
            {
                movingPoints = new GameObject[GameObject.FindGameObjectsWithTag("MovespotTop").Length];
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("MovespotTop").Length; i++)
                {
                    movingPoints[i] = GameObject.FindGameObjectsWithTag("MovespotTop")[i];
                }
            }

        }
        
        

        NumberOfMoveSpots();
        
        minDist = 0.5f;
        currentMoveSpotNr = 0;
        animator.SetBool("isRunningInFear", true);
    }

    void Update()
    {
        UpdatingMovingDestiationsFromGameObjects();
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
                other.GetComponent<PlayerManagement>().PlayerScavRespawn();
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
    private void UpdatingMovingDestiationsFromGameObjects()
    {

        moveSpots = new Vector3[nrOfMoveSpots];

        for (int i = 0; i < moveSpots.Length; i++)
        {
            moveSpots[i] = movingPoints[i].transform.position;
        }
    }

    private void NumberOfMoveSpots()
    {
        for (int i = 0; i < movingPoints.Length; i++)
        {
            nrOfMoveSpots++;
        }
    }
}
