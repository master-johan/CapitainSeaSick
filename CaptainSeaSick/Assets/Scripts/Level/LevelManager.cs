using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    string spawnEnemyString = "SpawnEnemy";
    string spawnCliffString = "SpawnCliff";

    string rainString = "rain";
    string lightString = "light";
    string cloudString = "cloud";
    string windString = "wind";

    string startString = "Start";
    string stopString = "Stop";

    public GameObject obstacleSpawner;

    public ShipLevel currentLevel;
    ProgressBar_Script progressBar;

    Queue<Obstacle> levelObstacles;
    Obstacle currentObstacle;

    List<Weather> weathers;
    

    List<GameObject> spawners;

    // Start is called before the first frame update
    void Awake()
    {
        progressBar = GameObject.Find("TimeLine").GetComponentInChildren<ProgressBar_Script>();
        EnqueObstaces();
        progressBar.SetIndicatorsOnTimeLine(currentLevel.obstacles);
        spawners = new List<GameObject>();

        weathers = currentLevel.weathers;
        for (int i = 0; i < weathers.Count; i++)
        {
            weathers[i].active = false;
        }

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
        Debug.Log("Am i called? updateloop");

        for (int i = 0; i < weathers.Count; i++)
        {
            
            Weather w = weathers[i];
            Debug.Log("Am i called? weatherloop" + w.whenToSpawn + " " + w.active);
            if (w.whenToSpawn == progressBar.progress && !w.active)
            {
                string toStart = GetWeatherType(w);
                toStart += startString;
                w.active = true;
                Debug.Log("Event to trigger " + toStart);
                EventManager.TriggerEvent(toStart);
            }
            else if (w.whenToStop >= progressBar.progress && w.active)
            {
                string toStop = GetWeatherType(w);
                toStop += stopString;
                w.active = false;
                Debug.Log("Event to trigger " + toStop);
                EventManager.TriggerEvent(toStop);
            }
         
          
        }
       
    }
    //private string GetSpawnType(Obstacle currentObstacle, string typeToSpawn) --- - Ta bort?
    //{
    //    if (currentObstacle.type == TypeOfSpawn.ship)
    //    {
    //        typeToSpawn = spawnEnemyString;
    //    }
    //    if (currentObstacle.type == TypeOfSpawn.cliff)
    //    {
    //        typeToSpawn = spawnCliffString;
    //    }
    //    if (currentObstacle.type == TypeOfSpawn.random)
    //    {
    //        //  typeToSpawn = RandomType();
    //    }

    //    return typeToSpawn;
    //}

    private string GetWeatherType(Weather weather)
    {
        switch (weather.weather)
        {
            case TypeOfWeather.rain:
                return rainString;
                break;
            case TypeOfWeather.light:
                return lightString;
                break;
            case TypeOfWeather.cloud:
                return cloudString;
                break;
            case TypeOfWeather.wind:
                return windString;
                break;
            default:
                break;
        }
        return "null";
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
