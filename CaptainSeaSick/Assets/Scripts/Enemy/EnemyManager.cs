using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    List<Vector3> enemySpawnPosList;

    public GameObject enemyShip;
    public Canvas enemyIndicator;

    Vector3 tempVector;

    private UnityAction spawnListener;

    private string spawnEnemyString = "SpawnEnemy";

    public GameObject[] tempTriggerSpots = new GameObject[8];

    private GameObject[] triggerSpots = new GameObject[8];

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
        GenerateIndicators();
    }

    // Start is called before the first frame update
    void Start()
    {
        triggerSpots = tempTriggerSpots;
        Debug.Log(triggerSpots[0].name);
        GenerateSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Litterally generate indicators depending on where a ship is
    /// </summary>
    private void GenerateIndicators()
    {
        if (tempVector == triggerSpots[0].transform.position + triggerSpots[0].transform.right * 50)
        {
            enemyIndicator.transform.Find("L1image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == triggerSpots[1].transform.position + triggerSpots[1].transform.right * 50)
        {
            enemyIndicator.transform.Find("L2image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == triggerSpots[2].transform.position + triggerSpots[2].transform.right * 50)
        {
            enemyIndicator.transform.Find("L3image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == triggerSpots[3].transform.position + triggerSpots[3].transform.right * 50)
        {
            enemyIndicator.transform.Find("L4image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == triggerSpots[4].transform.position + triggerSpots[4].transform.right * 50)
        {
            enemyIndicator.transform.Find("R1image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == triggerSpots[5].transform.position + triggerSpots[5].transform.right * 50)
        {
            enemyIndicator.transform.Find("R2image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == triggerSpots[6].transform.position + triggerSpots[6].transform.right * 50)
        {
            enemyIndicator.transform.Find("R3image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == triggerSpots[7].transform.position + triggerSpots[7].transform.right * 50)
        {
            enemyIndicator.transform.Find("R4image").GetComponent<Image>().enabled = true;
        }
    }
    /// <summary>
    /// Here are the different vectors in the list
    /// </summary>
    private void GenerateSpawnPos()
    {
        enemySpawnPosList = new List<Vector3>();
        enemySpawnPosList.Add(triggerSpots[0].transform.position + triggerSpots[0].transform.right * 50); //L1
        enemySpawnPosList.Add(triggerSpots[1].transform.position + triggerSpots[1].transform.right * 50); //L2
        enemySpawnPosList.Add(triggerSpots[2].transform.position + triggerSpots[2].transform.right * 50); //L3
        enemySpawnPosList.Add(triggerSpots[3].transform.position + triggerSpots[3].transform.right * 50); //L4
        enemySpawnPosList.Add(triggerSpots[4].transform.position + triggerSpots[4].transform.right * 50); //R1
        enemySpawnPosList.Add(triggerSpots[5].transform.position + triggerSpots[5].transform.right * 50); //R2
        enemySpawnPosList.Add(triggerSpots[6].transform.position + triggerSpots[6].transform.right * 50); //R3
        enemySpawnPosList.Add(triggerSpots[7].transform.position + triggerSpots[7].transform.right * 50); //R4
    }
    /// <summary>
    /// Removes the indicators depending on where an enemyship has died, and added on that vector to the list so an enemy can be spawned on that position again.
    /// </summary>
    /// <param name="temp"></param>
    public void RemoveIndicators(Vector3 temp)
    {
        if (tempVector == triggerSpots[0].transform.position + triggerSpots[0].transform.right * 50)
        {
            enemyIndicator.transform.Find("L1image").GetComponent<Image>().enabled = false;
        }
        if (tempVector == triggerSpots[1].transform.position + triggerSpots[1].transform.right * 50)
        {
            enemyIndicator.transform.Find("L2image").GetComponent<Image>().enabled = false;
        }
        if (tempVector == triggerSpots[2].transform.position + triggerSpots[2].transform.right * 50)
        {
            enemyIndicator.transform.Find("L3image").GetComponent<Image>().enabled = false;
        }
        if (tempVector == triggerSpots[3].transform.position + triggerSpots[3].transform.right * 50)
        {
            enemyIndicator.transform.Find("L4image").GetComponent<Image>().enabled = false;
        }
        if (tempVector == triggerSpots[4].transform.position + triggerSpots[4].transform.right * 50)
        {
            enemyIndicator.transform.Find("R1image").GetComponent<Image>().enabled = false;
        }
        if (tempVector == triggerSpots[5].transform.position + triggerSpots[5].transform.right * 50)
        {
            enemyIndicator.transform.Find("R2image").GetComponent<Image>().enabled = false;
        }
        if (tempVector == triggerSpots[6].transform.position + triggerSpots[6].transform.right * 50)
        {
            enemyIndicator.transform.Find("R3image").GetComponent<Image>().enabled = false;
        }
        if (tempVector == triggerSpots[7].transform.position + triggerSpots[7].transform.right * 50)
        {
            enemyIndicator.transform.Find("R4image").GetComponent<Image>().enabled = false;
        }
        enemySpawnPosList.Add(temp);
    }
}
