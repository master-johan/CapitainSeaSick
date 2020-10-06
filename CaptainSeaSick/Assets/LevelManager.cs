using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    string spawnEnemyString = "SpawnEnemy";
    string spawnCliffString = "SpawnCliff";

    public ShipLevel currentLevel;
    ProgressBar_Script progressBar;

    Queue<Obstacle> levelObstacles;
    Obstacle currentObstacle;

    // Start is called before the first frame update
    void Start()
    {
        progressBar = GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>();
        EnqueObstaces();
    }

    private void EnqueObstaces()
    {
        levelObstacles = new Queue<Obstacle>();
        foreach (Obstacle o in currentLevel.obstacles)
        {
            levelObstacles.Enqueue(o);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelObstacles.Count > 0)
        {
            if (levelObstacles.Peek().whenToSpawn == progressBar.progress)
            {
                Debug.Log("Spawner kallas");
                Spawner();
            }
        }
    }

    private void Spawner()
    {
        currentObstacle = levelObstacles.Dequeue();
        int nrOfSpawn = currentObstacle.numberOfSpawns;
        string typeToSpawn = "";
        typeToSpawn = GetSpawnType(currentObstacle, typeToSpawn);

        StartCoroutine(waitForSeconds(nrOfSpawn, currentObstacle.timeBetweenSpawn, typeToSpawn));
    }

    IEnumerator waitForSeconds(int nrOfSpawn,float time, string typeToSpawn)
    {
        float timeLeft = time;
        while (timeLeft > 0)
        {
            Debug.Log(timeLeft);
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        nrOfSpawn--;
        if (nrOfSpawn > 0)
        {
            StartCoroutine(waitForSeconds(nrOfSpawn, currentObstacle.timeBetweenSpawn, typeToSpawn));
        }
        EventManager.TriggerEvent(typeToSpawn);
    }

    private string GetSpawnType(Obstacle currentObstacle, string typeToSpawn)
    {
        if (currentObstacle.type == TypeOfSpawn.ship)
        {
            typeToSpawn = spawnEnemyString;
        }
        if (currentObstacle.type == TypeOfSpawn.cliff)
        {
            typeToSpawn = spawnCliffString;
        }
        if (currentObstacle.type == TypeOfSpawn.random)
        {
            //  typeToSpawn = RandomType();
        }

        return typeToSpawn;
    }
}
