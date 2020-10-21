using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    public float currenthealth;
    private GameObject spawnPositions;


    public event Action <float> healthPctChanged = delegate { };
    private void OnEnable()
    {
        currenthealth = maxHealth;
        spawnPositions = GameObject.FindGameObjectWithTag("SpawnPositions");

    }

    /// <summary>
    /// Method to be called to modify the health value of the ship 
    /// (This method does not modify the fill in the healthbar that happends in the healthbar script)
    /// </summary>
    /// <param name="amount"></param>
    public void ModifyHealth(float amount)
    {
        currenthealth += amount;
        float currentHeathPct = currenthealth / maxHealth;
        healthPctChanged(currentHeathPct);
    }
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cliff")
        {
            Destroy(other.gameObject);
            spawnPositions.GetComponent<SpawnPositionsScript>().SpawnLeak();
            Debug.Log(spawnPositions.GetComponent<SpawnPositionsScript>().allSpawnPositionUsed);
        }
        if(other.tag == "EnemyCannonball")
        {
            ModifyHealth(-1);
        }
    }

}
