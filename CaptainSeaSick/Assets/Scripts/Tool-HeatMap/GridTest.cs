using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridTest : MonoBehaviour
{
    public ProgressBar_Script timeline;
    public ScavengingManager scavManager;
    float timeLeft;
    GameObject[] players;
    GameObject[] enemies;
    public Grid grid;
    string scene;
    ShipLevel level;
    string levelName;
    bool once;
    bool useScav;
    bool isScav;

    // Start is called before the first frame update
    void Start()
    {
        char[] sceneName = SceneManager.GetActiveScene().name.ToCharArray();
        string scavString = "Scav";

        for (int i = 0; i < scavString.Length; i++)
        {
            if (sceneName[i] == scavString[i])
            {
                isScav = true;
            }
            else
            {
                isScav = false;
            }
        }

        if (isScav)
        {

            grid = new Grid(22, 10, 5, 3, new Vector3(-5, 50, -30));
            scene = SceneManager.GetActiveScene().name;
            Debug.Log("Scav");
        }
        else
        {
            grid = new Grid(22, 10, 5, 3, new Vector3(-50, 10, -5));
            scene = "Ship";
            Debug.Log("Ship");
        }
        if (GameObject.Find("LevelManager"))
        {
            level = GameObject.Find("LevelManager").GetComponent<LevelManager>().currentLevel;
        }

        if (scavManager != null)
        {
            useScav = true;
        }
        else
        {
            useScav = false;
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
                grid.SetValue(new Vector3(players[i].transform.position.x, 0, players[i].transform.position.z),(int)HeatMapLayer.playerPos, Time.deltaTime);
            }
        }

        enemies = GameObject.FindGameObjectsWithTag("BoardingEnemy");
        if (enemies != null)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                grid.SetValue(new Vector3(enemies[i].transform.position.x, 0, enemies[i].transform.position.z), (int)HeatMapLayer.enemyPos, Time.deltaTime);
            }
        }

        if (useScav)
        {
            timeLeft = scavManager.GetTimeleft();
        }
        else
        {
            timeLeft = timeline.timeLeft;
        }

        if (!once)
        {
            if (timeLeft <= 1)
            {
                PrintData();
                once = true;
            }
        }
    }

    public void PrintData()
    {

        if (level != null)
        {
            levelName = level.name;
        }
        else
        {
            levelName = SceneManager.GetActiveScene().name;
        }
        

        string text = grid.ToString(scene, levelName, players.Length);
        System.IO.File.WriteAllText(FileName(), text);
    }

    private string FileName()
    {
        return string.Format("{0}/Snapshot/{1}{2}.json",
            Application.dataPath,
            levelName,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
}