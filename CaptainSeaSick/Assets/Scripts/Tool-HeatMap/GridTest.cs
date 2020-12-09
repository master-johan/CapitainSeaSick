using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridTest : MonoBehaviour
{
    GameObject[] players;
    private Grid grid;
    string scene;
    ShipLevel level;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {

            grid = new Grid(22, 10, 3, new Vector3(-5, 30, -30));
            scene = "Scav";
            Debug.Log("Scav");
        }
        else
        {
            grid = new Grid(22, 10, 3, new Vector3(-50, 10, -5));
            scene = "Ship";
            Debug.Log("Ship");
        }
        if (GameObject.Find("LevelManager"))
        {
            level = GameObject.Find("LevelManager").GetComponent<LevelManager>().currentLevel;
        }
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
        string levelName;

        if (level != null)
        {
            levelName = level.name;
        }
        else
        {
            levelName = SceneManager.GetActiveScene().name;
        }

        string text = grid.ToString(scene, levelName);
        System.IO.File.WriteAllText(FileName(), text);
    }

    private string FileName()
    {
        return string.Format("{0}/Snapshot/grid{1}.json",
            Application.dataPath,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
}