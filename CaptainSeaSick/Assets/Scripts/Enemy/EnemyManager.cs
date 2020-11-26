using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    List<Vector3> enemySpawnPosList;

    public GameObject enemyShip;

    Vector3 tempVector;

    private UnityAction spawnListener;

    private string spawnEnemyString = "SpawnEnemy";

    public GameObject[] triggerSpots = new GameObject[8];

    private void Awake()
    {
        spawnListener = new UnityAction(SpawnEnemy);
    }

    private void OnEnable()
    {
        EventManager.StartSubscribe(spawnEnemyString, spawnListener);
    }

    private void OnDisable()
    {
        EventManager.StopSubscribe(spawnEnemyString,spawnListener);
    }
    /// <summary>
    /// Random between different vectors comming later in the script.
    /// Then removes that vector from a vector list including all the different set locations.
    /// </summary>
    private void SpawnEnemy()
    {
        int rand = Random.Range(0, enemySpawnPosList.Count - 1);
        if (enemySpawnPosList.Count > 0)
        {
            tempVector = enemySpawnPosList[rand];

            Instantiate(enemyShip, tempVector, Quaternion.identity);
            enemySpawnPosList.RemoveAt(rand);
            EventManager.TriggerEvent("battle");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(triggerSpots[0].name);
        GenerateSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    /// <summary>
    /// Here are the different vectors in the list
    /// </summary>
    private void GenerateSpawnPos()
    {
        enemySpawnPosList = new List<Vector3>();
        enemySpawnPosList.Add(triggerSpots[0].transform.position + triggerSpots[0].transform.forward * 60); //L1
        enemySpawnPosList.Add(triggerSpots[1].transform.position + triggerSpots[1].transform.forward * 60); //L2
        enemySpawnPosList.Add(triggerSpots[2].transform.position + triggerSpots[2].transform.forward * 60); //L3
        enemySpawnPosList.Add(triggerSpots[3].transform.position + triggerSpots[3].transform.forward * 60); //L4
        enemySpawnPosList.Add(triggerSpots[4].transform.position + triggerSpots[4].transform.forward * 60); //R1
        enemySpawnPosList.Add(triggerSpots[5].transform.position + triggerSpots[5].transform.forward * 60); //R2
        enemySpawnPosList.Add(triggerSpots[6].transform.position + triggerSpots[6].transform.forward * 60); //R3
        enemySpawnPosList.Add(triggerSpots[7].transform.position + triggerSpots[7].transform.forward * 60); //R4
    }

    public void AddBackDeadShipPosition(Vector3 temp)
    {
        enemySpawnPosList.Add(temp);
    }
}
