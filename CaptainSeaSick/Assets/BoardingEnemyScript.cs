using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using UnityEngine;

public class BoardingEnemyScript : MonoBehaviour
{
    GameObject[] players;
    float[] distToPlayer;
    float temp = float.MaxValue;
    int index = 5;
    int playerIndex;
    GameObject inputManager;
    public Animator animator;

    Vector3 targetDirection;

    void Start()
    {
        playerIndex = PlayerManagement.playerIndex - 1;

        distToPlayer = new float[playerIndex];
        players = new GameObject[playerIndex];


        players = GameObject.FindGameObjectsWithTag("Player");


        Debug.Log(players.Length);
        Debug.Log(distToPlayer.Length);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", false);

        for (int i = 0; i < players.Length; i++)
        {
            distToPlayer[i] = Vector3.Distance(transform.position, players[i].transform.position);

            if (distToPlayer[i] < temp)
            {
                temp = distToPlayer[i];
                index = i;
            }
        }

        if (temp <= 10)
        {
            if (index != 5)
            {
                animator.SetBool("isRunning", true);

                targetDirection = players[index].transform.position;
                transform.forward = targetDirection - transform.position;
                transform.position = Vector3.MoveTowards(transform.position, targetDirection, 4 * Time.deltaTime);

            }
        }
        else
        {
            index = 5;
        }
        temp = float.MaxValue;



    }
}
