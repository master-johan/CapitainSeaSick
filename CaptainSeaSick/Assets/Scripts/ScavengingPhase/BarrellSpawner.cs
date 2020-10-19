using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrellSpawner : MonoBehaviour
{
    public GameObject barrell;
    private GameObject tempBarrell;
    public float timer = 6;

    void Start()
    {
        tempBarrell = barrell;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        //Spawn a barrell every 10 seconds at the position for the BarrellSpawner.
        if (timer <= 0)
        {
           
            tempBarrell = Instantiate(barrell);
            tempBarrell.transform.position = transform.position;

            timer = 6;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RollingBarrell")
        {
            //Destroy the save value in tempBarrell and NOT the prefab.
            Destroy(tempBarrell);
        }
    }
}
