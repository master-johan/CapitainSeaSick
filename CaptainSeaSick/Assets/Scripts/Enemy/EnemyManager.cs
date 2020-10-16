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
        if (tempVector == new Vector3(-2, -4, -85))
        {
            enemyIndicator.transform.Find("R3image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == new Vector3(-13, -4, -85))
        {
            enemyIndicator.transform.Find("R2image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == new Vector3(-13, -4, 85))
        {
            enemyIndicator.transform.Find("L2image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == new Vector3(-2, -4, 85))
        {
            enemyIndicator.transform.Find("L3image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == new Vector3(-90, -4, -51))
        {
            enemyIndicator.transform.Find("R1image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == new Vector3(-59, -4, 51))
        {
            enemyIndicator.transform.Find("L1image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == new Vector3(85, 0, -6.5f))
        {
            enemyIndicator.transform.Find("R4image").GetComponent<Image>().enabled = true;
        }
        if (tempVector == new Vector3(85, 0, 5.5f))
        {
            enemyIndicator.transform.Find("L4image").GetComponent<Image>().enabled = true;
        }
    }
    /// <summary>
    /// Here are the different vectors in the list
    /// </summary>
    private void GenerateSpawnPos()
    {
        enemySpawnPosList = new List<Vector3>();
        enemySpawnPosList.Add(new Vector3(-2, -4, -85)); //R3
        enemySpawnPosList.Add(new Vector3(-13, -4, -85)); // R2
        enemySpawnPosList.Add(new Vector3(-13, -4, 85)); //L2
        enemySpawnPosList.Add(new Vector3(-2, -4, 85)); //L3
        enemySpawnPosList.Add(new Vector3(-90, -4, -51)); //R1
        enemySpawnPosList.Add(new Vector3(-59, -4, 51)); //L1
        enemySpawnPosList.Add(new Vector3(85, 0, -6.5f)); //R4
        enemySpawnPosList.Add(new Vector3(85, 0, 5.5f)); //L4
    }
    /// <summary>
    /// Removes the indicators depending on where an enemyship has died, and added on that vector to the list so an enemy can be spawned on that position again.
    /// </summary>
    /// <param name="temp"></param>
    public void RemoveIndicators(Vector3 temp)
    {
        if (temp == new Vector3(-2, -4, -85))
        {
            enemyIndicator.transform.Find("R3image").GetComponent<Image>().enabled = false;
        }
        if (temp == new Vector3(-13, -4, -85))
        {
            enemyIndicator.transform.Find("R2image").GetComponent<Image>().enabled = false;
        }
        if (temp == new Vector3(-13, -4, 85))
        {
            enemyIndicator.transform.Find("L2image").GetComponent<Image>().enabled = false;
        }
        if (temp == new Vector3(-2, -4, 85))
        {
            enemyIndicator.transform.Find("L3image").GetComponent<Image>().enabled = false;
        }
        if (temp == new Vector3(-90, -4, -51))
        {
            enemyIndicator.transform.Find("R1image").GetComponent<Image>().enabled = false;
        }
        if (temp == new Vector3(-59, -4, 51))
        {
            enemyIndicator.transform.Find("L1image").GetComponent<Image>().enabled = false;
        }
        if (temp == new Vector3(85, 0, -6.5f))
        {
            enemyIndicator.transform.Find("R4image").GetComponent<Image>().enabled = false;
        }
        if (temp == new Vector3(85, 0, 5.5f))
        {
            enemyIndicator.transform.Find("L4image").GetComponent<Image>().enabled = false;
        }
        enemySpawnPosList.Add(temp);
    }
}
