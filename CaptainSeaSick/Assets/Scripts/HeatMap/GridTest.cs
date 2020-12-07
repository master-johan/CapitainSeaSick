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
        grid = new Grid(22, 10, 3, new Vector3(-50,10,-5));
        a = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players != null)
        {
            for (int i = 0; i < players.Length; i++)
            {
                grid.SetValue(new Vector3(players[i].transform.position.x, 0, players[i].transform.position.z), Time.deltaTime);
            }
        }
    }

    public void PrintData()
    {

        string text = grid.ToString();
        System.IO.File.WriteAllText(FileName(), text);
    }

    private string FileName()
    {
        return string.Format("{0}/Snapshot/grid{1}.json",
            Application.dataPath,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
}
