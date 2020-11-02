using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BarrellSpawner : MonoBehaviour
{
    private GameObject tempBarrell;
    public bool spawnBarrel;
    public float timer;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(spawnBarrel)
        {
            SpawnRollingBarrel();
        }
    }

    private void SpawnRollingBarrel()
    {
        tempBarrell = Instantiate(GameAssets.instance.rollingBarrelPrefab);
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
