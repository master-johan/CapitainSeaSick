using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionsScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] spawnPositionArray = new GameObject[6];
    public GameObject leak;
    GameObject tempLeak;
    GameObject tempGameObject;
    bool allSpawnPositionUsed = false;
    void Start()
    {

    }
    /// <summary>
    /// When an enemyShip has hit, if one spot is open then continue to check what spawnposition is empty. 
    /// Then spawn a leak on that position
    /// </summary>
    public void SpawnLeak()
    {
        for (int i = 0; i < spawnPositionArray.Length; i++)
        {
            if (spawnPositionArray[i].GetComponent<Spawn_Script>().isUsed)
            {
                allSpawnPositionUsed = true;
            }
            else
            {
                allSpawnPositionUsed = false;
                break;
            }
        }
        if (!allSpawnPositionUsed)
        {
            do
            {
                tempGameObject = spawnPositionArray[Random.Range(0, 6)];
            } while (tempGameObject.GetComponent<Spawn_Script>().isUsed);

            tempGameObject.GetComponent<Spawn_Script>().isUsed = true;
            Vector3 center = tempGameObject.transform.position;

            tempLeak = Instantiate(leak, center, leak.transform.rotation);

            tempLeak.transform.parent = tempGameObject.transform;

            tempLeak.GetComponent<BigLeakScript>().SaveSpawnPosition(tempGameObject);

        }
        else
        {
            GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipHealth>().ModifyHealth(-10);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
