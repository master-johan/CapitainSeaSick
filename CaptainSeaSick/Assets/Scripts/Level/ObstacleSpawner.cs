using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    int nrOfSpwan;
    float timeBetweenSpawn;
    [HideInInspector]
    public Obstacle obstacle;
    string typeToSpawn;
    string spawnEnemyString = "SpawnEnemy";
    string spawnCliffString = "SpawnCliff";
    public bool isDepleted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartSpawner(Obstacle obstacle)
    {
        this.obstacle = obstacle;
        nrOfSpwan = obstacle.numberOfSpawns;
        typeToSpawn = GetSpawnType(obstacle);
        timeBetweenSpawn = obstacle.timeBetweenSpawn;
        StartCoroutine(waitForSeconds());
    }

    IEnumerator waitForSeconds()
    {
        float timeLeft = timeBetweenSpawn;
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        nrOfSpwan--;
        if (nrOfSpwan >0)
        {
            StartCoroutine(waitForSeconds());
        }
        EventManager.TriggerEvent(typeToSpawn);

        if (nrOfSpwan == 0)
        {
            isDepleted = true;
        }
    }

    private string GetSpawnType(Obstacle currentObstacle)
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
