using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using UnityEngine;

public class BoardingEnemyScript : MonoBehaviour
{
    GameObject[] players;
    public ParticleSystem DeathEffect;
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
                if (distToPlayer[i] < 2 && !players[i].GetComponent<PlayerActions>().stunImmunity)
                {
                    players[i].GetComponent<PlayerActions>().StunPlayer();
                }
                if (!players[i].GetComponent<PlayerActions>().isStunned)
                {
                    temp = distToPlayer[i];
                    index = i;
                }
            }
        }

        if (temp <= 200)
        {
            if (index != 5)
            {
                animator.SetBool("isRunning", true);

                targetDirection = players[index].transform.position;
                transform.forward = new Vector3(targetDirection.x - transform.position.x, 0, targetDirection.z - transform.position.z);
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
