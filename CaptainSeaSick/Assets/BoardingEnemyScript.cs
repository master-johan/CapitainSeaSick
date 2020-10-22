using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class BoardingEnemyScript : MonoBehaviour
{
    GameObject[] players;
    float[] distToPlayer;
    float temp = float.MaxValue;
    int index = 5;
    GameObject inputManager;

    Vector3 targetDirection;

    void Start()
    {
        players = new GameObject[PlayerManagement.playerIndex - 1];
        distToPlayer = new float[PlayerManagement.playerIndex - 1];

        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
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
                targetDirection = players[index].transform.position;
            }
        }
        else
        {
            index = 5;
        }
        temp = float.MaxValue;

        transform.position = Vector3.MoveTowards(transform.position, targetDirection, 4 * Time.deltaTime);
        Debug.Log(transform.position + " bollens pos");
    }
}
