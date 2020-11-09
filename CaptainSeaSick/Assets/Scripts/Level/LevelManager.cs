using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    string spawnEnemyString = "SpawnEnemy";
    string spawnCliffString = "SpawnCliff";

    public GameObject obstacleSpawner;

    public ShipLevel currentLevel;
    ProgressBar_Script progressBar;

    Queue<Obstacle> levelObstacles;
    Obstacle currentObstacle;

    List<GameObject> spawners;

    // Start is called before the first frame update
    void Awake()
    {
        progressBar = GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>();
        EnqueObstaces();
        progressBar.SetIndicatorsOnTimeLine(currentLevel.obstacles);
        spawners = new List<GameObject>();

        InstantiateShipObjects();
    }

    private void EnqueObstaces()
    {
        levelObstacles = new Queue<Obstacle>();
        foreach (Obstacle o in currentLevel.obstacles)
        {
            o.status = TimeLineObstacleStatus.unknown;
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
                currentObstacle = levelObstacles.Dequeue();
                currentObstacle.status = TimeLineObstacleStatus.known;
                GameObject spawner =  Instantiate(obstacleSpawner);
                spawner.GetComponent<ObstacleSpawner>().StartSpawner(currentObstacle);
                spawners.Add(spawner);
            }
        }

        if (spawners != null)
        {
            foreach (var item in spawners)
            {
                ObstacleSpawner oS = item.GetComponent<ObstacleSpawner>();
                if (oS.isDepleted)
                {
                    oS.obstacle.status = TimeLineObstacleStatus.expired;
                    Destroy(item);
                    spawners.Remove(item);
                    break;
                }
            }
        }
       
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

    public void InstantiateShipObjects()
    {

        Spawn(GameAssets.instance.cannonPrefab, GameAssets.instance.numberOfCannons, GameAssets.instance.cannonSpawnPos);
        Spawn(GameAssets.instance.swordPrefab, GameAssets.instance.numberOfSwords, GameAssets.instance.swordSpawnPos);

    }

    public void Spawn(GameObject item, int numberOfObjects, List<Vector3> positions)
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Instantiate(item, positions[i] + GameAssets.instance.gameObject.transform.position, Quaternion.identity);
        }
    }
}
