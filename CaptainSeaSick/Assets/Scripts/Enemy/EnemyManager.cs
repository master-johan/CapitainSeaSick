using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<Vector3> EnemySpawnPosList;
    float spawnTimer;
    public GameObject enemyShip;
    

    // Start is called before the first frame update
    void Start()
    {
        GenerateSpawnPos();
        spawnTimer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(spawnTimer < 0)
        {
            int rand = Random.Range(0, EnemySpawnPosList.Count - 1);
            spawnTimer = 2;
            Instantiate(enemyShip, EnemySpawnPosList[rand], Quaternion.identity);
            EnemySpawnPosList.RemoveAt(rand);
        }
    }

    private void GenerateSpawnPos()
    {
        EnemySpawnPosList = new List<Vector3>();
        EnemySpawnPosList.Add(new Vector3(-2, -4, -85));
        EnemySpawnPosList.Add(new Vector3(-13, -4, -85));
        EnemySpawnPosList.Add(new Vector3(-13, -4, 85));
        EnemySpawnPosList.Add(new Vector3(-2, -4, 85));
        EnemySpawnPosList.Add(new Vector3(-90, -4, -51));
        EnemySpawnPosList.Add(new Vector3(-59, -4, 51));
        EnemySpawnPosList.Add(new Vector3(85, 0, -6.5f));
        EnemySpawnPosList.Add(new Vector3(85, 0, 5.5f));
    }
}
