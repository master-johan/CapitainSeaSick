using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    GameObject[] players;
    int a;
    private Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(10, 2, 10f);
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        a += 1;
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players != null)
        {
            grid.SetValue(new Vector3(players[0].transform.position.x, players[0].transform.position.z, 0), a);
            Debug.Log(players[0].transform.position);
        }
    }
}
