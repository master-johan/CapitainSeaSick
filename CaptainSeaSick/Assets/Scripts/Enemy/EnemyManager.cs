using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    List<Vector3> enemySpawnPosList;
    float spawnTimer;
    public GameObject enemyShip;
    public Canvas enemyIndicator;
    Vector3 tempVector;


    // Start is called before the first frame update
    void Start()
    {    
        GenerateSpawnPos();
        spawnTimer = 15;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            int rand = Random.Range(0, enemySpawnPosList.Count - 1);
            spawnTimer = 15;
            if (enemySpawnPosList.Count > 0)
            {
                Instantiate(enemyShip, enemySpawnPosList[rand], Quaternion.identity);
                tempVector = enemySpawnPosList[rand];
                enemySpawnPosList.RemoveAt(rand);
            }
            EventManager.TriggerEvent("battle");

            GenerateIndicators();
        }
    }


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
