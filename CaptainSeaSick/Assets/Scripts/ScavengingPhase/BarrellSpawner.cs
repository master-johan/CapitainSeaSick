using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BarrellSpawner : MonoBehaviour
{
    private GameObject tempBarrell;
    public GameObject targetObject;
    public bool spawnBarrel, spawnWithTimer;
    public float timer;
    private float actualTimer;

    void Start()
    {
        actualTimer = timer;

    }
    // Update is called once per frame
    void Update()
    {

        if (spawnWithTimer) //If the timer bool is checked in the inspector, the barrels will spawn using a timer instead of a trigger
        {
            actualTimer -= Time.deltaTime;
            if (actualTimer <= 0)
            {
                SpawnRollingBarrel();
                actualTimer = timer;
            }
        }

        if (spawnBarrel)
        {
            SpawnRollingBarrel();
        }
    }

    private void SpawnRollingBarrel()
    {
        tempBarrell = Instantiate(GameAssets.instance.rollingBarrelPrefab, transform);
        tempBarrell.transform.position = transform.position;
        spawnBarrel = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RollingBarrell")
        {
            //Destroy the save value in tempBarrell and NOT the prefab.
            Destroy(other.gameObject);
        }
    }
}
